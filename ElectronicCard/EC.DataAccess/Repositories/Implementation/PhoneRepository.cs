using EC.Common.Helpers;
using EC.Common.Helpers.Interface;
using EC.DataAccess.Repositories.Interfaces;
using EC.Entities.Entities;
using System.Collections.Generic;
using System.Data;

namespace EC.DataAccess.Repositories.Implementation
{
    public class PhoneRepository : IPhoneRepository
    {
        private readonly ISqlFactory _factory;

        public PhoneRepository(ISqlFactory factory)
        {
            _factory = factory;
        }

        public void Create(Phone item)
        {
            var numberParameter = _factory.CreateParameter("phoneNumber", item.PhoneNumber, DbType.String);
            var userIdParameter = _factory.CreateParameter("userId", item.UserId, DbType.Int32);

            _factory.CreateConnection()
                .CreateCommand(DbConstants.CREATE_PHONE)
                .AddParameters(numberParameter, userIdParameter)
                .ExecuteQuery();
        }

        public void Update(Phone item)
        {
            var idParameter = _factory.CreateParameter("id", item.Id, DbType.Int32);
            var numberParameter = _factory.CreateParameter("phoneNumber", item.PhoneNumber, DbType.String);
            var userIdParameter = _factory.CreateParameter("userId", item.UserId, DbType.Int32);

            _factory.CreateConnection()
                .CreateCommand(DbConstants.UPDATE_PHONE)
                .AddParameters(idParameter, numberParameter, userIdParameter)
                .ExecuteQuery();
        }

        public void Delete(int? id)
        {
            var idParameter = _factory.CreateParameter("id", id, DbType.Int32);

            _factory.CreateConnection()
                .CreateCommand(DbConstants.DELETE_PHONE)
                .AddParameters(idParameter)
                .ExecuteQuery();
        }

        public IReadOnlyCollection<Phone> GetUserPhones(int? userId)
        {
            var userIdParameter = _factory.CreateParameter("userId", userId, DbType.Int32);

            var reader = _factory.CreateConnection()
                .CreateCommand(DbConstants.GET_USER_PHONES)
                .AddParameters(userIdParameter)
                .ExecuteReader();

            var userPhones = new List<Phone>();

            foreach (var item in reader)
            {
                userPhones.Add(new Phone
                {
                    Id = (int)item["Id"],
                    PhoneNumber = (string)item["PhoneNumber"],
                    UserId = (int)item["UserId"]
                });
            }

            return userPhones;
        }

        public Phone GetById(int? id)
        {
            var idParameter = _factory.CreateParameter("id", id, DbType.Int32);

            var reader = _factory.CreateConnection()
                .CreateCommand(DbConstants.GET_PHONE_BY_ID)
                .AddParameters(idParameter)
                .ExecuteReader();

            Phone phone = null;

            foreach (var item in reader)
            {
                phone = new Phone
                {
                    Id = (int)item["Id"],
                    PhoneNumber = (string)item["PhoneNumber"],
                    UserId = (int)item["UserId"]
                };
            }

            return phone;
        }

        public Phone GetPhoneByNumber(string number)
        {
            var numberParameter = _factory.CreateParameter("number", number, DbType.String);

            var reader = _factory.CreateConnection()
                .CreateCommand(DbConstants.GET_PHONE_BY_NUMBER)
                .AddParameters(numberParameter)
                .ExecuteReader();

            Phone phone = null;

            foreach (var item in reader)
            {
                phone = new Phone
                {
                    Id = (int)item["Id"],
                    PhoneNumber = (string)item["PhoneNumber"],
                    UserId = (int)item["UserId"]
                };
            }

            return phone;
        }

        public IReadOnlyCollection<Phone> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
