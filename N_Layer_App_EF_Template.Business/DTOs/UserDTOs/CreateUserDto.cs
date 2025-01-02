namespace N_Layer_App_EF_Template.Business.DTOs.UserDTOs;

public class UserCreateDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public string Password { get; set; }
    public string? PhoneNumber { get; set; }
}

