using PcMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcMarket.Repositories
{
    public interface IPcBuildRepo
    {
        bool SaveChange();
        IEnumerable<PcComputerProp> GetAllPc();
        PcComputerProp GetBuildById(int id);
        void CreatePcBuild(PcComputerProp pcBuildProp);
        void EditPcBuild(PcComputerProp pcBuildProp);
        void DeletePcBuild(PcComputerProp pcBuildProp);
    }
}
