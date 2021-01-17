using PcMarket.Data;
using PcMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcMarket.Repositories
{
    public class PartRepos : IPcPartRepos
    {
        private readonly AppDbContext _dbContext;

        public PartRepos(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public PcPartProp CreatePart(PcPartProp pcPartProp)
        {
            _dbContext.GetPcParts.Add(pcPartProp);
            return pcPartProp;
        }

        public void DeletePart(PcPartProp pcPartProp)
        {
            _dbContext.GetPcParts.Remove(pcPartProp);
        }

        public IEnumerable<PcPartProp> GetAllParts()
        {
            return _dbContext.GetPcParts;
        }

        public PcPartProp GetPartByID(int id)
        {
            var getPartById = _dbContext.GetPcParts.Find(id);
            return getPartById;
        }

        public bool SaveChange()
        {
            return (_dbContext.SaveChanges() >= 0);
        }

        public void UpdatePart(PcPartProp pcPartProp)
        {
            //nothing
        }
    }
}
