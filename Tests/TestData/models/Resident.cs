
namespace TestProject.TestData.models
{
    public class Resident
    {
        public Resident() { }

        public Resident(Payment payment)
        {
            Payment = payment;
        }

        public string Name { get; set; }
        public string Comunity { get; set; }
        public double StatementBalance { get; set; }
        public double RemainingStatementBalance { get; set; }
        public Payment Payment { get; set; }

    }
}
