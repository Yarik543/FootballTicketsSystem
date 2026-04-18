namespace FootballTicketsSystem.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tickets
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tickets()
        {
            UserTickets = new HashSet<UserTickets>();
        }

        [Key]
        public int IdTicket { get; set; }

        public int? MatchId { get; set; }

        [StringLength(255)]
        public string Sector { get; set; }

        public int? Row { get; set; }

        public int? SeatNumber { get; set; }

        public decimal? Price { get; set; }

        public bool? IsSold { get; set; }

        public virtual Matches Matches { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserTickets> UserTickets { get; set; }
    }
}
