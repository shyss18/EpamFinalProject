﻿using EC.Entities.Entities;

namespace EC.DataAccess.Repositories.Interfaces
{
    public interface IPromotionRepository : IRepository<Promotion>
    {
        string TestConnection();
    }
}