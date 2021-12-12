namespace Http.Client.Factory.Application.Domains
{
    public class LoginContractInput
    {
        public string email { get; set; }
        public string password { get; set; }

        public bool IsValid()
        {
            return (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password));
        }
    }
}
