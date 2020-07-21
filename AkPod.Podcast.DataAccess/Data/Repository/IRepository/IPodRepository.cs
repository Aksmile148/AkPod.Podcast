using Podcast.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Podcast.DataAccess.Data.Repository.IRepository
{
    public interface IPodRepository
    {
        void Update(Pod pod);
    }
}
