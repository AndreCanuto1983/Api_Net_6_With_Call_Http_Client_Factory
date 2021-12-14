namespace Http.Client.Factory.Application.Domains.Responses
{
    public class LoginContractOutput
    {
        public string Authorization { get; set; }
        public DateTime? Expires { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
