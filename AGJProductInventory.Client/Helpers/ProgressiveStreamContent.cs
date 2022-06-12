using System.Net;

namespace AGJProductInventory.Client.Helpers
{
    public class ProgressiveStreamContent : StreamContent
    {
        private readonly Stream _fileStream;
        private readonly int _maxBuffer;

        public ProgressiveStreamContent(Stream stream, int maxBuffer, Action<long, double> onProgress) : base(stream)
        {
            _fileStream = stream;
            _maxBuffer = maxBuffer;
            OnProgress += onProgress;
        }

        public event Action<long, double> OnProgress;

        protected async override Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            // Define an array of bytes with the the length of the maximum amount of bytes to be pushed per time
            var buffer = new byte[_maxBuffer];
            var totalLength = _fileStream.Length;
            // Variable that holds the amount of uploaded bytes
            long uploaded = 0;

            // Create an while loop that we will break it internally when all bytes uploaded to the server
            while (true)
            {
                using (_fileStream)
                {
                    // In this part of code here in every loop we read a chunk of bytes and write them to the stream of the HttpContent
                    var length = await _fileStream.ReadAsync(buffer, 0, _maxBuffer);
                    // Check if the amount of bytes read recently, if there is no bytes read break the loop
                    if (length <= 0)
                    {
                        break;
                    }

                    // Add the amount of read bytes to uploaded variable
                    uploaded += length;
                    // Calculate the percntage of the uploaded bytes out of the total remaining
                    var percentage = Convert.ToDouble(uploaded * 100 / _fileStream.Length);

                    // Write the bytes to the HttpContent stream
                    await stream.WriteAsync(buffer);

                    // Fire the event of OnProgress to notify the client about progress so far
                    OnProgress?.Invoke(uploaded, percentage);

                    // Add this delay over here just to simulate to notice the progress, because locally it's going to be so fast that you can barely notice it
                    await Task.Delay(250);
                }
            }
        }
    }
}
