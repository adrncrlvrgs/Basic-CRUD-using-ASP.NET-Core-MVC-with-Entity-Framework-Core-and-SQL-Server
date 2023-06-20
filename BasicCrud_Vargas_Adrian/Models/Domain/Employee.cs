namespace BasicCrud_Vargas_Adrian.Models.Domain
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string ContactNum { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }

    }
}
