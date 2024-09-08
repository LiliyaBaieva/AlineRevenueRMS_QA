
namespace Core.models
{
    public class Resident
    {
        public string Name { get; set; }
        public string Comunity { get; set; }
        public double StatementBalance { get; set; }
        public double RemainingStatementBalance { get; set; }
        public Payment Payment { get; set; }

    }
}
