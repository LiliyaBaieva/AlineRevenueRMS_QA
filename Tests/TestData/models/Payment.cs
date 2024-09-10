using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.TestData.models
{
    public class Payment
    {
        public Payment(double Amount, DateTime Date, string Description)
        {
            this.Amount = Amount;
            this.Date = Date;
            this.Description = Description;
        }

        public Payment(double Amount, string Description)
        {
            this.Amount = Amount;
            this.Description = Description;
        }

        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
