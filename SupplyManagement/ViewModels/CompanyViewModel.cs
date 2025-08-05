namespace API.ViewModels
{
    public class CompanyViewModel
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyPhone { get; set; }
        public string? Photo { get; set; }
        public int StatusId { get; set; }

    }
}
