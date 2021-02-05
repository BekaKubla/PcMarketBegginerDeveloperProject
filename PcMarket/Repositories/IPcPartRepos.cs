using PcMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcMarket.Repositories
{
    public interface IPcPartRepos
    {
        bool SaveChange();
        IEnumerable<PcPartProp> GetAllParts(Category? category);
        PcPartProp GetPartByID(int id);
        PcPartProp CreatePart(PcPartProp pcPartProp);
        void DeletePart(PcPartProp pcPartProp);
        void UpdatePart(PcPartProp pcPartProp);

    }
}
