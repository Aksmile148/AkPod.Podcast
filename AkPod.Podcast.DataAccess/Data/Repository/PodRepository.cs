using Podcast.DataAccess.Data.Repository.IRepository;
using Podcast.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Podcast.DataAccess.Data.Repository
{
    public class PodRepository : Repository<Pod>, IPodRepository
    {
        private readonly ApplicationDbContext _context;
        public PodRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Pod pod)
        {
            var objFrom = _context.Pods.FirstOrDefault(c => c.Id == pod.Id);

            objFrom.Title = pod.Title;
            objFrom.AudioFile = pod.AudioFile;
            objFrom.dateUploaded = pod.dateUploaded;
            objFrom.Description = pod.Description;
            objFrom.Tag = pod.Tag;

            _context.SaveChanges();
        }
    }
}
