namespace HalfMarathon.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Result")]
    public partial class Result
    {
        public int Id { get; set; }

        [Required]
        //[RegularExpression(@"(^([0-1]?\d|2[0-3]):([0-5]?\d):([0-5]?\d)$)|(^([0-5]?\d):([0-5]?\d)$)|(^[0-5]?\d$)")]
        [RegularExpression(@"([0-1]?\d|2[0-3]):([0-5]?\d):([0-5]?\d)", ErrorMessage = "The time must be in hh:mm:ss format")]
        public TimeSpan Time { get; set; }

        [Required]
        [Range(2000, 2016, ErrorMessage = "Birth year have to be in range 1900-2016")]
        public int Year { get; set; }

        public int Participant_Id { get; set; }

        public virtual Participant Participant { get; set; }
    }
}
