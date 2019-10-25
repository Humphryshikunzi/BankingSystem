using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BankManagement
{
    class Program
    {
        static void Main()
        {
            // Call the TransactCustomer method that performs all the operation of the project
            TransactCustomer();
        }

        // Gets the Details of the Customer i.e the AccountNumber and the Amount to be transacted
        // This method then calls the WriteCustomer method that WriteLines the customers infor whose transaction has been done
        public static void TransactCustomer()
        {
            // initialise variables
            long customerAccountNumber, tranferAccountNumber;
            int typeofTransactiion;
            decimal customerAmountWithDraw;

            // WriteLines list of Types of Transactions from which the Customer will select the type of transaction
            Console.WriteLine("Please Select the Type of Transction");
            Console.WriteLine("1. WithDraw");
            Console.WriteLine("2. Depost");
            Console.WriteLine("3. Check Balance");
            Console.WriteLine("4. Transfer");
            typeofTransactiion = int.Parse(Console.ReadLine());

            // Get Customer AccountNumber, in Practice, the AccountNumber will be gotten by the system after swiping your card
            Console.WriteLine("Enter Customer AccountNumber");
            customerAccountNumber = long.Parse(Console.ReadLine());
          
            
            // Checks for WithDrawing money
            if(typeofTransactiion ==1)
            {
                Console.WriteLine("Enter the Amount to WithDraw");
                customerAmountWithDraw = decimal.Parse(Console.ReadLine());
                WriteCustomer(AddCustomers(customerAccountNumber, customerAmountWithDraw, typeofTransactiion));
            }

            //Checks for Depositing Money
            else if(typeofTransactiion == 2)
            {
                Console.WriteLine("Enter the Amount To Deposit");
                customerAmountWithDraw = decimal.Parse(Console.ReadLine());
                WriteCustomer(AddCustomers(customerAccountNumber, customerAmountWithDraw, typeofTransactiion));
            }

            //Checks Balance
            else if(typeofTransactiion == 3)
            {
                customerAmountWithDraw = 0;
                WriteCustomer(AddCustomers(customerAccountNumber, customerAmountWithDraw, typeofTransactiion));
            }

            // Checks for Transfering money
            else if(typeofTransactiion == 4)
            {
                Console.WriteLine("Enter the Amount to Transfer");
                customerAmountWithDraw = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Account to Transfer Money To");
                tranferAccountNumber = long.Parse(Console.ReadLine());
                WriteCustomer(AddCustomers(customerAccountNumber, customerAmountWithDraw, typeofTransactiion));
            }
           
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
        public static List<Customer> AddCustomers(long CustomerAccountNo, decimal CustomerMoneySpend, int typeofTranaction)
        {
            // List with two customers
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

            // Loops through each customer and find the customer whose AccountNo is same as the supplied account number
            //Then the transactions are done such that the amount ot  be deducted is done here
            foreach (var customer in customers)
            {

                if ((customer.AccountNumber == CustomerAccountNo) &&(typeofTranaction == 1) )
                {
                    // WithDraw
                    customer.Transaction.Balance = customer.Transaction.Balance - CustomerMoneySpend;
                                                          
                }
                 else if ((customer.AccountNumber == CustomerAccountNo) && (typeofTranaction == 2))
                {
                    // Deposit
                    customer.Transaction.Balance = customer.Transaction.Balance + CustomerMoneySpend;

                }
                 else if ((customer.AccountNumber == CustomerAccountNo) && (typeofTranaction == 3))
                {
                    // Balance 
                    customer.Transaction.Balance = customer.Transaction.Balance ;

                }
               else if ((customer.AccountNumber == CustomerAccountNo) && (typeofTranaction == 4))
                {
                    // Transfer
                    //Code to transfer the cash will be written here
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
        [Key]
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
        [Key]
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
        [Key]
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
        [Key]
        public int Id { get; set; }
        public long NationalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        public string HudumaNumber { get; set; }

    }
}
