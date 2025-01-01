/*
 Write an instance of a customer to a file (a disk) and read it back.
 */

using System.Text.Json;
using System.Text.Json.Serialization;


namespace SaveToDisk
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // instantial 3 customers
            // save each customer to its own file in JSON format with [firstname]-[lastname].json
            Customer[] customers = [
                new Customer() { FirstName = "Andy", LastName = "Aaa", Accounts = new List<BankAccount>()},
                new Customer() { FirstName = "Bobby", LastName = "Bbb", Accounts = new List<BankAccount>()},
                new Customer() { FirstName = "Cathy", LastName = "Ccc", Accounts = new List<BankAccount>()},
            ];

            //now add some initial actual data into each customer
            customers[0].Accounts.Add(new SavingsAccount(customers[0]) { AccountNumber="BS10001", Balance=10000, APR=3.2m});
            customers[0].Accounts.Add(new CheckingAccount(customers[0]) { AccountNumber="BS10002", Balance=10000, MinimumBalance=500});
            
            customers[1].Accounts.Add(new SavingsAccount(customers[1]) { AccountNumber="AA10001", Balance=8000, APR=3.2m});
            customers[1].Accounts.Add(new CheckingAccount(customers[1]) { AccountNumber="AA10002", Balance=7000, MinimumBalance = 500 });
            
            customers[2].Accounts.Add(new SavingsAccount(customers[2]) { AccountNumber="CB10001", Balance=500, APR=3.2m});
            customers[2].Accounts.Add(new CheckingAccount(customers[2]) { AccountNumber="CB10002", Balance=60, MinimumBalance = 500 });

            foreach (var customer in customers) {
                string fileName = $"{customer.FirstName}-{customer.LastName}.json";
                if (File.Exists(fileName)) 
                    File.Delete(fileName );
                
                var sw = new StreamWriter(File.Create(fileName));
                sw.WriteLine(JsonSerializer.Serialize(customer));
                sw.Close();
            }

            string folderPath = Directory.GetCurrentDirectory();
            string[] jsonFiles = Directory.GetFiles(folderPath, "*-*.json");

            // save each customer to its own file in
            // JSON format with [firstname]-[lastname].json
            //1. serialize the obj to Json
            //string jsonName = JsonSerializer.Serialize(customer1);
            //string nameFile1 =  $"[{ customer1.FirstName}]-[{customer1.LastName }.json]";
            //string nameFile2 =  $"[{ customer2.FirstName}]-[{customer2.LastName }.json]";
            //string nameFile3 =  $"[{ customer3.FirstName}]-[{customer3.LastName }.json]";

          

            // load 3 customers from files: means deserialize from json to object



        }
    }


    public class Customer
    {
        // public property FirstName, LastName
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        // public property List<BankAccount>
        public required List<BankAccount> Accounts { get; set; }
    }

    //[JsonDerivedType(typeof(BankAccount), typeDiscriminator: "base")]
    [JsonDerivedType(typeof(SavingsAccount), typeDiscriminator:"savings")]
    [JsonDerivedType(typeof(CheckingAccount), typeDiscriminator:"checking")]


    /* abstract bank account class*/
    public abstract class BankAccount //use abstract class to prevent instantiate, if it is not abstract, the JSON deserializer will attempt to instantiate
                                      //this bank account. Because deserializer is a process of convert json to obj, so when deserializer instantiate it, it
                                      //will throw an exception.
    {
        // Balance
        public required decimal Balance { get; set; }
        // AccountNumber
        public required string AccountNumber { get; set; }
        // Owner
        public Customer Owner { get; set; }
    }


    /* SavingsAccount class inherits BankAccount */
    // has Interest in APR % e.g. 3.1 float
    public class SavingsAccount : BankAccount { 
        public required decimal APR { get; set; }
        public SavingsAccount(Customer owner)
        {
            this.Owner = owner;
        }
    }



    /* CheckingAccount class inherits BankAccount*/
    // has MinimumBalance
    public class CheckingAccount : BankAccount { 
        public required decimal MinimumBalance { get; set; }
        public CheckingAccount(Customer owner){

            this.Owner = owner;
        }
    }

}

