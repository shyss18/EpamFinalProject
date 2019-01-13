using EC.BusinessLogic.Services.Interfaces;
using EC.DataAccess.Repositories.Interfaces;
using EC.Entities.Entities;

namespace EC.BusinessLogic.Services.Implementation
{
    public class PhotoService : IPhotoService
    {
        private readonly IPhotoRepository _photoRepository;
        private readonly IUserRepository _userRepository;

        public PhotoService(IPhotoRepository photoRepository, IUserRepository userRepository)
        {
            _photoRepository = photoRepository;
            _userRepository = userRepository;
        }

        public void CreatePhoto(Photo photo)
        {
            if (photo == null)
            {
                return;
            }

            _photoRepository.Create(photo);
        }

        public void UpdatePhoto(Photo photo)
        {
            if (photo == null)
            {
                return;
            }

            _photoRepository.Update(photo);
        }

        public void DeletePhoto(int? id)
        {
            if (id == null || id <= 0)
            {
                return;
            }

            _photoRepository.Delete(id);
        }

        public Photo GetById(int? id)
        {
            return id == null || id <= 0? null : _photoRepository.GetById(id);
        }

        public Photo GetUserPhoto(string login)
        {
            if (login == null)
            {
                return null;
            }

            var user = _userRepository.GetUserByLogin(login);

            return user == null ? null : _photoRepository.GetUserPhoto(user.Id);

        }
    }
}
