namespace FootballTicketsSystem.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Coaches
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdCoach { get; set; }

        [Required]
        [StringLength(255)]
        public string FullName { get; set; }

        public int TeamId { get; set; }

        [Required]
        [StringLength(255)]
        public string Country { get; set; }

        public string Description { get; set; }

        public int? Age { get; set; }

        public int? Experience { get; set; }

        [StringLength(255)]
        public string SchemeGame { get; set; }

        public string Photo { get; set; }

        public virtual Teams Teams { get; set; }
    }
}
