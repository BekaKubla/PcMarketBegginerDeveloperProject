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
        IEnumerable<PcPartProp> GetAllParts();
        PcPartProp GetPartByID(int id);
        PcPartProp CreatePart(PcPartProp pcPartProp);
        PcPartProp DeletePart(int id);
        PcPartProp UpdatePart(PcPartProp pcPartProp);

    }
}
