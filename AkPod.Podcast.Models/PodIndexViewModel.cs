using System;
using System.Collections.Generic;
using System.Text;

namespace Podcast.Models
{
    public class PodIndexViewModel
    {
        public IEnumerable<Pod> Pods { get; set; }

        public Pod  Pod { get; set; }

        public PodcastViewModel PodcastViewModel { get; set; }



    }
}
