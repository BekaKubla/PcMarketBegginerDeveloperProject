﻿using PcMarket.Data;
using PcMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcMarket.Repositories
{
    public class PcPartOrderRepo : IPcPartOrderRepo
    {
        private readonly AppDbContext _context;

        public PcPartOrderRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreateOrder(PcPartOrder pcPartOrder)
        {
            _context.GetOrders.Add(pcPartOrder);
        }

        public void DeleteOrder(PcPartOrder pcPartOrder)
        {
            _context.GetOrders.Remove(pcPartOrder);
        }

        public IEnumerable<PcPartOrder> GetAllOrder()
        {
            return _context.GetOrders;
        }

        public PcPartOrder GetOrderById(int id)
        {
            return _context.GetOrders.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<PcPartOrder> GetOrderOnlyBuild()
        {
            var getAllOrder = _context.GetOrders;
            var linq = getAllOrder.Where(e => e.PartOrBuild == PartOrBuild.Build);
            return linq;
        }

        public IEnumerable<PcPartOrder> GetOrderOnlyPart()
        {
            var getAllOrder = _context.GetOrders;
            var linq = getAllOrder.Where(e => e.PartOrBuild == PartOrBuild.Part);
            return linq;
        }

        public bool SaveChange()
        {
            return (_context.SaveChanges()>= 0);
        }
    }
}
