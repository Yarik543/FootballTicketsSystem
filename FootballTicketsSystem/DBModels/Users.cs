namespace FootballTicketsSystem.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            UserTickets = new HashSet<UserTickets>();
        }

        public bool IsAdmin()
        {
            return this.Roles.RoleName == "Администратор";
        }

        [Key]
        public int IdUser { get; set; }

        [StringLength(255)]
        public string FullName { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(255)]
        public string PasswordSalt { get; set; }

        [StringLength(255)]
        public string PasswordHash { get; set; }

        [StringLength(255)]
        public string Phone { get; set; }

        public int? RoleId { get; set; }

        [StringLength(255)]
        public string PhotoProfil { get; set; }

        public int? Ballance { get; set; }

        public virtual Roles Roles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserTickets> UserTickets { get; set; }
    }
}
