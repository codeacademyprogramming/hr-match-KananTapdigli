using HrMatchApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrMatch.Models
{
    public class Announcement
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public User User { get; set; }
        public int UserID { get; set; }
        public Category Category { get; set; }
        public int CategoryID { get; set; }
        public City City { get; set; }
        public int CityID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string CompanyName { get; set; }

        [Required]
        public string Information { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        public byte Age { get; set; }

        [Required]
        [StringLength(50)]
        public string Education { get; set; }

        [Required]
        [StringLength(50)]
        public string Experience { get; set; }

        [Required]
        [StringLength(50)]
        public string PhoneNumber { get; set; }

        private Announcement()
        {

        }

        public Announcement(int userID,string name, string companyName, int categoryID, string information, int cityID, byte age, string education, string experience, decimal salary, string phoneNumber)
        {
            UserID = userID;
            Name = name;
            CompanyName = companyName;
            CategoryID = categoryID;
            Information = information;
            CityID = cityID;
            Age = age;
            Education = education;
            Experience = experience;
            Salary = salary;
            PhoneNumber = phoneNumber;
        }

        public ICollection<WorkersAnnouncements> workersAnnouncements { get; set; }

    }
}
