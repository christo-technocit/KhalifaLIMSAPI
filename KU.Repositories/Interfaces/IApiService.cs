
using System.IO;
using System.Threading.Tasks;
//namespace IC6.Xamarin.PictureUpload
namespace KU.WebAPI.PictureUpload
{
    public interface IApiService
    {
        Task UploadImageAsync(Stream image, string fileName);
    }
}