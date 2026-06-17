namespace FootballTicketsSystem.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Players
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Players()
        {
            Transfers = new HashSet<Transfers>();
        }

        [Key]
        public int IdPlayer { get; set; }

        [Required]
        [StringLength(255)]
        public string FullName { get; set; }

        public int? Number { get; set; }

        [StringLength(255)]
        public string Position { get; set; }

        public int? TeamId { get; set; }

        public int? Age { get; set; }

        public int? Height { get; set; }

        [StringLength(255)]
        public string WorkingLeg { get; set; }

        [StringLength(255)]
        public string Country { get; set; }

        public int? YellowCard { get; set; }

        public int? RedCard { get; set; }

        public string Description { get; set; }

        public string Photo { get; set; }

        public bool IsCaptain { get; set; }

        public virtual Teams Teams { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transfers> Transfers { get; set; }
    }
}
