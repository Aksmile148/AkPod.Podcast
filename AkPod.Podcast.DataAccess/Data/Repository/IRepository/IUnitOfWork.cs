using System;
using System.Collections.Generic;
using System.Text;

namespace Podcast.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IPodRepository Pod { get; }
        void Save();
    }
}
