namespace MainBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter your name: ");
            String name = Console.ReadLine();
            Console.WriteLine("Hello " + name);

            Console.Write("Please make an initial deposit with a min $1000: ");
            decimal initialBalance = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Your starting Balance is $: " + initialBalance);

            var account = new BankAccount(name, initialBalance);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");

            // Transactions
            account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
            account.MakeDeposit(100, DateTime.Now, "Friend paid me back");


            Console.WriteLine(account.GetAccountHistory());

            // Test that the initial balances must be positive.
            BankAccount invalidAccount;
            try
            {
                invalidAccount = new BankAccount("invalid", -55);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught creating account with negative balance");
                Console.WriteLine(e.ToString());
                return;
            }

            // Test for a negative balance.
            try
            {
                account.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception caught trying to overdraw");
                Console.WriteLine(e.ToString());
            }



        }


    }


}