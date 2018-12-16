using System;
using System.Collections.Generic;
using EC.Entities.Entities;

namespace EC.PromotionService
{
    public class PromotionService : IPromotionService
    {
        public string TestConnection()
        {
            return "Ok";
        }

        public void CreatePromotion(Promotion item)
        {
            throw new NotImplementedException();
        }

        public Promotion GetByIdPromotion(int? id)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<Promotion> GetAllPromotions()
        {
            throw new NotImplementedException();
        }

        public void DeletePromotion(int? id)
        {
            throw new NotImplementedException();
        }

        public void UpdatePromotion(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
