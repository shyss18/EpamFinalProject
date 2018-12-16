using System;
using System.Collections.Generic;
using System.ServiceModel;
using EC.DataAccess.Repositories.Interfaces;
using EC.Entities.Entities;
using EC.DataAccess.PromotionService;

namespace EC.DataAccess.Repositories.Implementation
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly IPromotionService _service;

        public PromotionRepository()
        {
            var channelFactory = new ChannelFactory<IPromotionService>(new BasicHttpBinding(), "http://localhost/EC.PromotionService/PromotionService.svc");

            _service = channelFactory.CreateChannel();
        }

        public string TestConnection()
        {
            return _service.TestConnection();
        }

        public void Create(Promotion item)
        {
            throw new NotImplementedException();
        }

        public void Update(Promotion item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Promotion GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<Promotion> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
