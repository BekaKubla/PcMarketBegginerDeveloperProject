using PcMarket.Data;
using PcMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcMarket.Repositories
{
    public class PcPartOrderRepo : IPcPartOrderRepo
    {
        private readonly AppDbContext _dbcontext;

        public PcPartOrderRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public void CreateOrder(PcPartOrder pcPartOrder)
        {
            _dbcontext.GetOrders.Add(pcPartOrder);
        }

        public void DeleteOrder(PcPartOrder pcPartOrder)
        {
            _dbcontext.GetOrders.Remove(pcPartOrder);
        }

        public IEnumerable<PcPartOrder> GetAllOrder()
        {
            return _dbcontext.GetOrders;
        }

        public PcPartOrder GetOrderById(int id)
        {
            var findOrder = _dbcontext.GetOrders.Find(id);
            return findOrder;
        }

        public bool SaveChange()
        {
            return (_dbcontext.SaveChanges() >=0);
        }
    }
}
