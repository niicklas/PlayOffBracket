namespace HalfMarathon.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Participant")]
    public partial class Participant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Participant()
        {
            Result = new HashSet<Result>();
        }

        public int Id { get; set; }

        [DisplayName("First name")]
        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "You must have at least 2 characters and maximum 30 characters")]
        public string FirstName { get; set; }

        [DisplayName("Last name")]
        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "You must have at least 2 characters and maximum 30 characters")]
        public string LastName { get; set; }

        [DisplayName("Birth year")]
        [Range(1900, 2016, ErrorMessage = "Birth year have to be in range 1900-2016")]
        public int BirthYear { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "You must have at least 2 characters and maximum 50 characters")]
        public string Club { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Result> Result { get; set; }
    }
}
