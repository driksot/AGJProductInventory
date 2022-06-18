using AGJProductInventory.Application.Common;
using AGJProductInventory.Client.Services.IServices;
using AGJProductInventory.Client.Static;
using System.Net.Http.Json;

namespace AGJProductInventory.Client.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly HttpClient _http;

        public FileUploadService(HttpClient http)
        {
            _http = http;
        }

        public bool DeleteFile(string filePath)
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> UploadFile(UploadedImage uploadedImage)
        {
            return await _http.PostAsJsonAsync<UploadedImage>(APIEndpoints.s_fileUpload, uploadedImage);
        }
    }
}
