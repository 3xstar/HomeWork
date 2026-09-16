namespace hw5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SavingsAccount savings = new SavingsAccount("SAV001", 1000);
            savings.DisplayBalance();
            savings.Deposit(500);
            Console.WriteLine("After depositing 500:");
            savings.DisplayBalance();
            savings.Withdraw(200);
            Console.WriteLine("After withdrawing 200:");
            savings.DisplayBalance();
            savings.Withdraw(1500);
            Console.WriteLine("After attempting to withdraw 1500:");
            savings.DisplayBalance();
            Console.WriteLine();

            CheckingAccount checking = new CheckingAccount("CHK001", 1000);
            checking.DisplayBalance();
            checking.Deposit(500);
            Console.WriteLine("After depositing 500:");
            checking.DisplayBalance();
            checking.Withdraw(200);
            Console.WriteLine("After withdrawing 200 (with 1% commission):");
            checking.DisplayBalance();
            checking.Withdraw(100);
            Console.WriteLine("After withdrawing another 100 (with 1% commission):");
            checking.DisplayBalance();
            Console.WriteLine();

            CreditAccount credit = new CreditAccount("CRD001", 500, -200);
            credit.DisplayBalance();
            credit.Deposit(300);
            Console.WriteLine("After depositing 300:");
            credit.DisplayBalance();
            credit.Withdraw(400);
            Console.WriteLine("After withdrawing 400:");
            credit.DisplayBalance();
            credit.Withdraw(400);
            Console.WriteLine("After attempting to withdraw another 400 (should fail):");
            credit.DisplayBalance();
            Console.WriteLine();
        }
    }

    abstract class BankAccount
    {
        public string AccountNumber;
        public double balance;

        public BankAccount(string accountNumber, double Balance)
        {
            AccountNumber = accountNumber;
            balance = Balance;
        }

        public virtual void Deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
            }
            else
            {
                Console.WriteLine("Error: invalid deposit amount");
            }
        }

        public virtual void Withdraw(double amount)
        {
            if (amount > 0)
            {
                balance -= amount;
            }
            else
            {
                Console.WriteLine("Error: invalid withdraw amount");
            }
        }

        public virtual void DisplayBalance()
        {
             Console.WriteLine("Current balance: " + balance);
        }
    }

    class SavingsAccount : BankAccount
    {
        public SavingsAccount(string accountNumber, double Balance) : base(accountNumber, Balance){}
        public override void Withdraw(double amount)
        {
            if (amount > 0 && balance >= amount)
            {
                balance -= amount;
            }
            else
            {
                Console.WriteLine("Error: invalid withdraw amount");
            }
        }
    }

    class CheckingAccount : BankAccount
    {
        public CheckingAccount(string accountNumber, double Balance) : base(accountNumber, Balance) { }
        public override void Withdraw(double amount)
        {
            if (amount > 0)
            {
                double commission = amount / 100;
                balance -= (amount + commission);
            }
            else
            {
                Console.WriteLine("Error: invalid withdraw amount");
            }
        }
    }

    class CreditAccount : BankAccount
    {
        public double limit;
        public CreditAccount(string accountNumber, double Balance, double Limit) : base(accountNumber, Balance)
        {
            limit = Limit;
        }
        public override void Withdraw(double amount)
        {
            double BalanceLimitCheck = balance -= amount;
            if (amount > 0 || BalanceLimitCheck >= limit)
            {
                balance -= (amount);
            }
            else
            {
                Console.WriteLine("Error: invalid withdraw amount");
            }
        }
    }
}