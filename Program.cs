using System;
using System.Collections.Generic;
using System.Linq;

namespace BankManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            // Call the transact method that performs all the operation of the project
            TransactCustomer();           
        }
        
        // Gets the Details of the Customer i.e the AccountNumber and the Amount to be transacted
        // This method then calls the WriteCustomer method that WriteLines the customers infor whose transaction has been done
        public static void TransactCustomer()
        {
             // Get Customer AccountNumber, in Practice, the AccountNumber will be gotten by the system after swiping your card
            Console.WriteLine("Enter Customer AccountNumber");
            long customerAccountNumber = long.Parse(Console.ReadLine());
            
            //Same as in Practice where you are need to key in the Amount you need to WithDraw
            Console.WriteLine("Enter the Amount to Withdraw");
            decimal customerAmountWithDraw = decimal.Parse(Console.ReadLine());
            WriteCustomer(AddCustomers(customerAccountNumber, customerAmountWithDraw));

        }
        
       // Gets a list of Customers as Parameters and WiteLines the customers important information
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
        
        //This method simulates A database where we have a list of customers, each with their information.
        //The Customer whose BankAccount is given will have their Bank Balance deducted by the recent transaction
        //The method then returns the customer in previous line comment
        public static List<Customer> AddCustomers(long CustomerAccountNo, decimal CustomerMoneySpend)
        {
            // list with two customers
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

            // Loops through each customer and fine the customer whose AccountNo is same as the supplied account number
            //Then the transactions are done such that the amount ot  be deducted is done here
            foreach (var customer in customers)
            {
                if (customer.AccountNumber == CustomerAccountNo )
                {
                    // Actual transaction is doen here 
                    customer.Transaction.Balance = customer.Transaction.Balance - CustomerMoneySpend;
                                                          
                }
                               
            }
            
            //Filtering out the exact customer whose transactiton have been done and return it in the next line
            var currentCustomer = customers.Where(c => c.AccountNumber == CustomerAccountNo).ToList();
            return currentCustomer;
        }
    }

    
    //Contains the properties for the customer with Relationships like Branch, Transactions and The Agent
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
    
    // Contains the properties for transactions like Date, Balance e.t.c
    class Transactions
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public Branch Location { get; set; }
        public Agent MyProperty { get; set; }
        public decimal Balance { get; set; }


    }
    
    // The physical loaction for the Bank, 
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

    
    // The Agent who served the customer
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
