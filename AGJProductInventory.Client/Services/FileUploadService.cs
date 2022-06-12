using AGJProductInventory.Client.Helpers;
using AGJProductInventory.Client.Services.IServices;
using Microsoft.AspNetCore.Components.Forms;

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

        public async Task<string> UploadFile(ProgressiveStreamContent streamContent)
        {
            var response = await _http.PostAsync("api/files", streamContent);
            return response.Content.ToString();
        }
    }
}
