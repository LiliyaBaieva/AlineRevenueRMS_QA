
namespace TestProject.TestData.models
{
    public class Resident
    {
        public Resident() { }

        public Resident(string name, string community, double statementBalance, double remainingStatementBalance, Payment payment)
        { 
            Name = name;
            community = community;
            StatementBalance = statementBalance;
            RemainingStatementBalance = remainingStatementBalance;
            Payment = payment;
        }

        public Resident(Payment payment)
        {
            Payment = payment;
        }
        
        public Resident(string community, Payment payment)
        {
            Community = community;
            Payment = payment;
        }

        public string Name { get; set; }
        public string Community { get; set; }
        public double StatementBalance { get; set; }
        public double RemainingStatementBalance { get; set; }
        public Payment Payment { get; set; }

    }
}
