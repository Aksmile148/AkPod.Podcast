using Podcast.DataAccess.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Podcast.DataAccess.Data.Repository
{
    public class UnitOfWork : IUnitOfWork 
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Pod = new PodRepository(_context);
        }
        public IPodRepository Pod { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
