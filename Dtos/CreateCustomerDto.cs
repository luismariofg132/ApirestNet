using System.ComponentModel.DataAnnotations;

namespace ApirestNet.Dtos
{
    public class CreateCustomerDto
    {
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        // Regular expression for the email validation
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email is not valid")]
        public string Email { get; set; }
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Phone is not valid")]
        public string Phone { get; set; }
    }
}
