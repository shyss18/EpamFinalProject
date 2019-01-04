using EC.Entities.Entities;

namespace EC.BusinessLogic.Services.Interfaces
{
    public interface IPhotoService
    {
        void CreatePhoto(Photo photo);
        void UpdatePhoto(Photo photo);
        void DeletePhoto(int? id);
        Photo GetById(int? id);
        Photo GetUserPhoto(int? userId);
    }
}
