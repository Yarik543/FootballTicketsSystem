namespace FootballTicketsSystem.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Matches
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Matches()
        {
            Tickets = new HashSet<Tickets>();
        }

        [Key]
        public int IdMatch { get; set; }

        public int? TeamHomeId { get; set; }

        public int? TeamAwayId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? MatchDate { get; set; }

        public int? StadiumId { get; set; }

        public int? ScoreHome { get; set; }

        public int? ScoreAway { get; set; }

        public decimal? RatingMatch { get; set; }

        [StringLength(255)]
        public string Stage { get; set; }

        public virtual Stadiums Stadiums { get; set; }

        public virtual Teams Teams { get; set; }

        public virtual Teams Teams1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tickets> Tickets { get; set; }
    }
}
