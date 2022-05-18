using System.ComponentModel.DataAnnotations;

namespace FootballServerCapstone.API.Models
{
    public class DateOfBirthAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value is DateTime)
                {
                    DateTime date = Convert.ToDateTime(value);

                    if (date <= DateTime.Parse("1982-05-10") && date >= DateTime.Parse("2002-05-10"))
                    {
                        return new ValidationResult("Date must be between 5/10/82 and 5/10/02");
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
