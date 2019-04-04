using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SacramentPlanner.Models
{
    public class Meeting
    {
        public int ID { get; set; }
        public int MemberID { get; set; }

        public int HymnID { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public string Conductor { get; set; }

        [Display(Name = "Opening Hymn")]
        public int OpeningHymn { get; set; }

        [Display(Name = "Opening Prayer")]
        [Required]
        public string OpeningPrayer { get; set; }

        [Display(Name = "Sacrament Hymn")]
        public int SacramentHymn { get; set; }

        [Display(Name = "Intermediate Song")]
        public string IntermediateSong { get; set; }

        [Display(Name = "Closing Hymn")]
        public int ClosingHymn { get; set; }
        
        [Display(Name = "Closing Prayer")]
        [Required]
        public string ClosingPrayer { get; set; }

        public virtual ICollection<Member> Members { get; set; }
        public virtual ICollection<Hymn> Hymns { get; set; }


    }
}
