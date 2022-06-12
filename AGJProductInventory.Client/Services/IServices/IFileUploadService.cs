using AGJProductInventory.Client.Helpers;
using Microsoft.AspNetCore.Components.Forms;

namespace AGJProductInventory.Client.Services.IServices
{
    public interface IFileUploadService
    {
        Task<string> UploadFile(ProgressiveStreamContent streamContent);

        bool DeleteFile(string filePath);
    }
}
