using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AkPod.Podcast.Models
{
    public class PodcastViewModel
    {
        [Required(ErrorMessage = "Please enter title")]
        [StringLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter description")]
        [StringLength(500)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter tag")]
        [StringLength(100)]
        public string Tag { get; set; }


        public DateTime dateUploaded { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Please choose profile image")]
        [Display(Name = "Profile Picture")]
        public IFormFile ProfileImage { get; set; }
    }
}
