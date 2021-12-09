using Microsoft.AspNetCore.Http;

namespace DominicsPizza.Services.Interfaces
{
    public interface IFileHelper
    {
        void DeleteFile(string imageUrl);

        string UploadFile(IFormFile file);
    }
}
