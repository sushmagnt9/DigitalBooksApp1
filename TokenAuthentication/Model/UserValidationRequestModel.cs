namespace TokenAuthentication.Model
{
    public class UserValidationRequestModel
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? UserRole { get; set; }
    }
}
