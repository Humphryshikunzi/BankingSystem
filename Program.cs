using System;
using System.Collections.Generic;
using System.Linq;

namespace BankManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            TransactCustomer();           
        }
        public static void TransactCustomer()
        {

            Console.WriteLine("Enter Customer AccountNumber");
            long customerAccountNumber = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Amount to Withdraw");
            decimal customerAmountWithDraw = decimal.Parse(Console.ReadLine());
            WriteCustomer(AddCustomers(customerAccountNumber, customerAmountWithDraw));

        }

        public static void WriteCustomer(List<Customer> writecustomers)
        {
            foreach (var customer in writecustomers )
            {
                Console.WriteLine("Customer Name  :" + customer.FullName);
                Console.WriteLine("Account Number :" + customer.AccountNumber);
                Console.WriteLine("Agent Name     :" + customer.Agent.FullName);
                Console.WriteLine("Brach          :" + customer.Branch.BranchName);
                Console.WriteLine("Date           :" + customer.Transaction.Date.ToString() + " " + customer.Transaction.Time);
                Console.WriteLine("Balance        :" +customer.Transaction.Balance);
                Console.WriteLine();
            }
        }
        public static List<Customer> AddCustomers(long CustomerAccountNo, decimal CustomerMoneySpend)
        {
            List<Customer> customers =  new List<Customer>()
            {
                 new Customer()
            {
                FirstName = "Millicent",
                LastName = "Millie",
                AccountNumber = 4580476116779647,
                NationalId = 36058390,
                HudumaNumber = "HUMBFDFG",
                Branch = new Branch()
                {
                    BranchName = "Nyeri",
                    Manager = "Antony",
                    Country = "Kenya",
                    County = "Nyeri",
                    Lat = 12.5,
                    Lon = 47.6,
                    TownName = "Nyeri",
                }
                   ,
                Agent = new Agent()
                {
                    FirstName = "Janet",
                    LastName = "Medi",
                    HudumaNumber = "HUGFBNM",
                    NationalId = 36555520
                }
                    ,
                Transaction = new Transactions()
                {
                    Date = DateTime.Now,
                    Time = DateTime.Now.ToShortTimeString(),
                    Balance = 45000

                }
            } ,
                 new Customer()
                 {
                     FirstName = "Julia",
                     LastName = "Wambui",
                     AccountNumber = 4582455755634214,
                     NationalId = 35825854,
                     HudumaNumber = "HFBNKH",
                     Branch = new Branch()
                     {
                         BranchName = "Nakuru",
                         Manager = "Millie",
                         Country = "Kenya",
                         County = "Nakuru",
                         Lat = 12.5,
                         Lon = 47.6,
                         TownName = "Nakuru",
                     }
                    ,
                     Agent = new Agent()
                     {
                         FirstName = "Mercy",
                         LastName = "Melinda",
                         HudumaNumber = "HHJKDFGHJ",
                         NationalId = 7854266555
                     }
                    ,
                     Transaction = new Transactions()
                     {
                         Date = DateTime.Now,
                         Time = DateTime.Now.ToShortTimeString(),
                         Balance = 100000

                     }
                 }

            };

            foreach (var customer in customers)
            {
                if (customer.AccountNumber == CustomerAccountNo )
                {
                    customer.Transaction.Balance = customer.Transaction.Balance - CustomerMoneySpend;
                                                          
                }
                               
            }
            var currentCustomer = customers.Where(c => c.AccountNumber == CustomerAccountNo).ToList();
            return currentCustomer;
        }
    }

    class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        public long AccountNumber { get; set; }
        public long NationalId { get; set; }
        public Transactions Transaction { get; set; }
        public Branch Branch { get; set; }
        public string HudumaNumber { get; set; }
        public Agent Agent { get; set; }


    }
    class Transactions
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public Branch Location { get; set; }
        public Agent MyProperty { get; set; }
        public decimal Balance { get; set; }


    }
    class Branch
    {
        public int Id { get; set; }
        public string BranchName { get; set; }
        public string Manager { get; set; }
        public string Country { get; set; }
        public string County { get; set; }
        public double Lon { get; set; }
        public double Lat { get; set; }
        public string TownName { get; set; }
    }

    class Agent
    {
        public int Id { get; set; }
        public long NationalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        public string HudumaNumber { get; set; }

    }
}
