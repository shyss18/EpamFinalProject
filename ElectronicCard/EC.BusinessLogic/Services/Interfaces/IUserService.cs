﻿using EC.Entities.Entities;
using System.Collections.Generic;

namespace EC.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int? id);
        User GetUserById(int? id);
        IReadOnlyCollection<User> GetAllUsers();
        IReadOnlyCollection<Patient> GetAllPatients();
        IReadOnlyCollection<Doctor> GetAllDoctors();
    }
}