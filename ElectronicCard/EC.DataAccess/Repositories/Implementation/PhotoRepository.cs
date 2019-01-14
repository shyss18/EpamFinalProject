using EC.Common.Helpers;
using EC.Common.Helpers.Interface;
using EC.DataAccess.Repositories.Interfaces;
using EC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace EC.DataAccess.Repositories.Implementation
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly ISqlFactory _factory;

        public PhotoRepository(ISqlFactory factory)
        {
            _factory = factory;
        }

        public void Create(Photo item)
        {
            var imageParameter = _factory.CreateParameter("image", item.Image, DbType.Binary);
            var typeParameter = _factory.CreateParameter("imageType", item.ImageType, DbType.String);
            var userParameter = _factory.CreateParameter("userId", item.UserId, DbType.Int32);

            _factory.CreateConnection()
                .CreateCommand(DbConstants.CREATE_PHOTO)
                .AddParameters(imageParameter, typeParameter, userParameter)
                .ExecuteQuery();
        }

        public void Update(Photo item)
        {
            var idParameter = _factory.CreateParameter("id", item.Id, DbType.Int32);
            var imageParameter = _factory.CreateParameter("image", item.Image, DbType.Binary);
            var typeParameter = _factory.CreateParameter("imageType", item.ImageType, DbType.String);
            var userParameter = _factory.CreateParameter("userId", item.UserId, DbType.Int32);

            _factory.CreateConnection()
                .CreateCommand(DbConstants.UPDATE_PHOTO)
                .AddParameters(idParameter, imageParameter, typeParameter, userParameter)
                .ExecuteQuery();
        }

        public void Delete(int? id)
        {
            var idParameter = _factory.CreateParameter("id", id, DbType.Int32);

            _factory.CreateConnection()
                .CreateCommand(DbConstants.DELETE_PHOTO)
                .AddParameters(idParameter)
                .ExecuteQuery();
        }

        public Photo GetById(int? id)
        {
            var idParameter = _factory.CreateParameter("id", id, DbType.Int32);

            var reader = _factory.CreateConnection()
                .CreateCommand(DbConstants.GET_PHOTO_BY_ID)
                .AddParameters(idParameter)
                .ExecuteReader();

            Photo photo = null;

            foreach (var item in reader)
            {
                photo = new Photo
                {
                    Id = (int)item["Id"],
                    Image = (byte[])item["Image"],
                    ImageType = (string)item["ImageType"]
                };
            }

            return photo;
        }

        public Photo GetUserPhoto(int? userId)
        {
            var idParameter = _factory.CreateParameter("userId", userId, DbType.Int32);

            var reader = _factory.CreateConnection()
                .CreateCommand(DbConstants.GET_USER_PHOTO)
                .AddParameters(idParameter)
                .ExecuteReader();

            Photo photo = null;

            foreach (var item in reader)
            {
                photo = new Photo
                {
                    Id = (int) item["Id"],
                    Image = (byte[])item["Image"],
                    ImageType = (string)item["ImageType"],
                    UserId = (int)item["UserId"]
                };
            }

            return photo;
        }

        public IReadOnlyCollection<Photo> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
