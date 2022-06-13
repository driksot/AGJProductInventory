using AGJProductInventory.Application.Common;

namespace AGJProductInventory.Client.Services.IServices
{
    public interface IFileUploadService
    {
        Task<HttpResponseMessage> UploadFile(UploadedImage uploadedImage);

        bool DeleteFile(string filePath);
    }
}
