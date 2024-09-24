using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class UserDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
        public int? FailedAttempt { get; set; } = 0;
        public DateTime? LoginTime { get; set; }
        public DateTime? LockoutEnd { get; set; }
        public bool? LockoutEnabled { get; set; } = false;
        public byte? LoggedIn { get; set; } = 0;
        public string? Token { get; set; }
        public bool? Validate { get; set; } = false;
        public string? IpAddress { get; set; }
        public string? BrowserName { get; set; }
        public string? BrowserVersion { get; set; }
        public DateTime? HeartBeat { get; set; }

        // public int RoleId { get; set; }
    }
}
