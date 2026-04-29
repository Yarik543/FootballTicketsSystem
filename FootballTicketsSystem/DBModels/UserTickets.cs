namespace FootballTicketsSystem.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserTickets
    {
        [Key]
        public int IdUserTickets { get; set; }

        public int? UserId { get; set; }

        public int? TicketId { get; set; }

        public virtual Tickets Tickets { get; set; }

        public virtual Users Users { get; set; }
    }
}
