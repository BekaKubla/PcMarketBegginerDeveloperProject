using PcMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcMarket.Repositories
{
   public interface IPcPartOrderRepo
    {
        IEnumerable<PcPartOrder> GetAllOrder();
        IEnumerable<PcPartOrder> GetOrderOnlyPart();
        IEnumerable<PcPartOrder> GetOrderOnlyBuild();
        void CreateOrder(PcPartOrder pcPartOrder);
        void DeleteOrder(PcPartOrder pcPartOrder);
        PcPartOrder GetOrderById(int id);
        bool SaveChange();

    }
}
