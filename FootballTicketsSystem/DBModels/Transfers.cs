namespace FootballTicketsSystem.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Transfers
    {
        [Key]
        public int IdTransfer { get; set; }

        public int? PlayerId { get; set; }

        [StringLength(255)]
        public string FromTeamName { get; set; }

        public int? ToTeamId { get; set; }

        public decimal? Price { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateTransfer { get; set; }

        public virtual Players Players { get; set; }

        public virtual Teams Teams { get; set; }
    }
}
