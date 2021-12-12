namespace Http.Client.Factory.Application.Domains
{
    public class LoginContractOutput
    {
        public string authorization { get; set; }
        public DateTime? expires { get; set; }
        public string email { get; set; }
        public string name { get; set; }
    }
}
