namespace Http.Client.Factory.Application.Domains.Requests
{
    public class LoginContractInput
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public bool IsValid()
        {
            return (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password));
        }
    }
}
