using System.ComponentModel.DataAnnotations;

namespace DoctorClinicApplication.Models
{
    public class Patient
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Patient name is manditory")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Patient's phone number is manditory")]
        [RegularExpression(@"^(\+91[\-\s]?)?[0]?(91)?[789]\d{9}$", ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }

        [RegularExpression(@"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$", ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Patient's age has to be provided")]
        [Range(0, 100, ErrorMessage = "Invalid number for age")]
        public int Age { get; set; }
        public override bool Equals(object? obj)
        {
            Patient d1, d2;
            d1 = (Patient)obj;
            d2 = this;
            if (d1.Id == d2.Id)
                return true;
            return false;
        }
    }

}