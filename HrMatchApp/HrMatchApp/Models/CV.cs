using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrMatch.Models
{
    public class CV
    {
        [Key]
        [ForeignKey("User")]
        public int UserID { get; set; }
        public User User { get; set; }

        public Category Category { get; set; }
        [Required]
        public int CategoryID { get; set; }

        public City City { get; set; }
        [Required]
        public int CityID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        [Required]
        [StringLength(50)]
        public string Gender { get; set; }

        [Required]
        public byte Age { get; set; }

        [Required]
        [StringLength(50)]
        public string Education { get; set; }

        [Required]
        [StringLength(50)]
        public string Experience { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        [StringLength(50)]
        public string PhoneNumber { get; set; }


        private CV()
        {
        
        }


        public CV(int userID,int categoryID,int cityID, string name,string surname,string gender,byte age,string education,string experience,decimal salary,string phoneNumber)
        {
            UserID = userID;
            CategoryID = categoryID;
            CityID = cityID;
            Name = name;
            Surname = surname;
            Gender = gender;
            Age = age;
            Education = education;
            Experience = experience;
            Salary = salary;
            PhoneNumber = phoneNumber;
        }

    }

}
