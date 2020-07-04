using HrMatchApp.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrMatch.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public CV CV { get; set; }

        [Required]
        [StringLength(50)]
        [Index(IsUnique = true)]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }


        private User()
        {

        }

        public User(int id,string Username,string Email,string Status, string Password)
        {
            this.ID = id;
            this.Username = Username;
            this.Email = Email;
            this.Status = Status;
            this.Password = Password;
        }
        public User(string Username, string Email, string Status, string Password)
        {
            this.Username = Username;
            this.Email = Email;
            this.Status = Status;
            this.Password = Password;
        }


        public ICollection<Announcement> Announcements { get; set; }

        public ICollection<WorkersAnnouncements> workersAnnouncements { get; set; }

    }
}
