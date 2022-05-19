using System.ComponentModel.DataAnnotations;

namespace FootballServerCapstone.API.Models
{
    public class DateOfBirthAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime min = DateTime.Now.AddYears(-40).Date; //1982-05-10
            DateTime max = DateTime.Now.AddYears(-20).Date; //2002-05-10

            if (value is DateTime)
            {
                DateTime date = Convert.ToDateTime(value);

                if (date < min || date > max)
                {
                    return new ValidationResult($"Date must be between {min:MM/dd/yyyy} and {max:MM/dd/yyyy}");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            else
            {
                return new ValidationResult("This attribute only works with DateTime objects");
            }
        }
    }
}
