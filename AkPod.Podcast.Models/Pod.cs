using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AkPod.Podcast.Models
{
    public class Pod
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter title")]
        [StringLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter description")]
        [StringLength(500)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter tag")]
        [StringLength(100)]
        public string Tag { get; set; }

        [Display(Name = "Date Uploaded")]
        public DateTime dateUploaded { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Please choose audio file")]
        public string AudioFile { get; set; }


        
    }
}
