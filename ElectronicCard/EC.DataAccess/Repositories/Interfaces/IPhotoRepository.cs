using EC.Entities.Entities;

namespace EC.DataAccess.Repositories.Interfaces
{
    public interface IPhotoRepository : IRepository<Photo>
    {
        Photo GetUserPhoto(int? userId);
    }
}
