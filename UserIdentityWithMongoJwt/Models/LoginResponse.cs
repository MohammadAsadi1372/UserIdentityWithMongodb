namespace UserIdentityWithMongoJwt.Models
{
    public class LoginResponse
    {
        public LoginResponse(string token, string userName, string email)
        {
            Token = token;
            UserName = userName;
            Email = email;
        }

        public string Token { get; private set; }

        public string UserName { get; private set; }

        public string Email { get; private set; }
    }

    public class SignUpResponse
    {
        public SignUpResponse(string token, string userName, string email)
        {
            Token = token;
            UserName = userName;
            Email = email;
        }

        public string Token { get; private set; }

        public string UserName { get; private set; }

        public string Email { get; private set; }
    }

    public class UserDataResponse
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public string Email { get; set; }
    }
}
