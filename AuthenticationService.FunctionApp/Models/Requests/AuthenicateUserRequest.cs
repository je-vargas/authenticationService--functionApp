namespace AuthenticationService.FunctionApp.Models.Requests
{
    public class AuthenicateUserRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
