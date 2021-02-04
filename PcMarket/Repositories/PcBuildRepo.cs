using PcMarket.Data;
using PcMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcMarket.Repositories
{
    public class PcBuildRepo : IPcBuildRepo
    {
        private readonly AppDbContext _context;

        public PcBuildRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreatePcBuild(PcComputerProp pcBuildProp)
        {
            _context.GetComputers.Add(pcBuildProp);
        }

        public void DeletePcBuild(PcComputerProp pcBuildProp)
        {
             _context.GetComputers.Remove(pcBuildProp);
        }

        public void EditPcBuild(PcComputerProp pcBuildProp)
        {
            //Nothing
        }

        public IEnumerable<PcComputerProp> GetAllPc()
        {
            return _context.GetComputers;
        }

        public PcComputerProp GetBuildById(int id)
        {
            return _context.GetComputers.FirstOrDefault(e => e.ID == id);
        }

        public bool SaveChange()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
