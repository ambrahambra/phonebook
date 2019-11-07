namespace test.Models
{
    public class phonebookItem
    {
        public int? Id { get; set; }
        public string firstName { get; set; }
        public string secondName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string bDay { get; set; }
        public bool isWarn { get; }
    }
}