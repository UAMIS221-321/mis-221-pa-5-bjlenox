namespace mis_221_pa_5_bjlenox
{
    public class TransactionReport
    {
        Transaction[] transactions;

        public TransactionReport(Transaction[] transactions)
        {
            this.transactions = transactions;
        }
        public void PrintAllTransactions()
        {
            for (int i = 0; i < Transaction.GetCount(); i++)
            {
                System.Console.WriteLine(transactions[i].ToString());
            }
        }
        public void PrintWriteAllTransactions(string whichFile)
        {
            StreamWriter outfile = new StreamWriter(whichFile);
            for (int i = 0; i < Transaction.GetCount(); i++)
            {
                System.Console.WriteLine(transactions[i].ToString());
                transactions[i].ToFile();
            }
            outfile.Close();  
        }
        public void PrintIncomeYearMonth()
        {
            int currMonth = transactions[0].GetMonth();
            int currYear = transactions[0].GetYear();
            int countMonth = transactions[0].GetCost();
            int countYear = transactions[0].GetCost();
            for (int i = 1; i < Transaction.GetCount(); i++)
            {
                if (transactions[i].GetMonth() == currMonth && transactions[i].GetYear() == currYear)
                {
                    countMonth += transactions[i].GetCost();
                    countYear += transactions[i].GetCost();
                }
                else if (transactions[i].GetYear() == currYear)
                {
                    ProcessBreakMonth(ref currMonth, currYear, ref countMonth, transactions[i]);
                }
                else
                {
                    ProcessBreakYear(ref currYear, ref currMonth, ref countYear, ref countMonth, transactions[i]);
                }
            }
        }
        public void PrintWriteIncomeYearMonth(string whichFile)//save to file
        {
            int currMonth = transactions[0].GetMonth();
            int currYear = transactions[0].GetYear();
            int countMonth = transactions[0].GetCost();
            int countYear = transactions[0].GetCost();
            for (int i = 1; i < Transaction.GetCount(); i++)
            {
                if (transactions[i].GetMonth() == currMonth && transactions[i].GetYear() == currYear)
                {
                    countMonth += transactions[i].GetCost();
                    countYear += transactions[i].GetCost();
                }
                else if (transactions[i].GetYear() == currYear)
                {
                    ProcessBreakMonth(ref currMonth, currYear, ref countMonth, transactions[i], whichFile);
                }
                else
                {
                    ProcessBreakYear(ref currYear, ref currMonth, ref countYear, ref countMonth, transactions[i], whichFile);
                }
            }
        }
        public void ProcessBreakMonth(ref int currMonth, int currYear, ref int countMonth, Transaction newTransaction)
        {
            System.Console.WriteLine($"Income for {currMonth}/{currYear} was {countMonth}");
            currMonth = newTransaction.GetMonth();
            countMonth = newTransaction.GetCost();
        }
        public void ProcessBreakYear(ref int currYear, ref int currMonth, ref int countYear, ref int countMonth, Transaction newTransaction)
        {
            System.Console.WriteLine("");
            System.Console.WriteLine($"Income for {currYear} was {countYear}");
            currMonth = newTransaction.GetMonth();
            countMonth = newTransaction.GetCost();
            currYear = newTransaction.GetYear();
            countYear = newTransaction.GetCost();
        }
        public void ProcessBreakMonth(ref int currMonth, int currYear, ref int countMonth, Transaction newTransaction, string whichFile)//save to file
        {
            System.Console.WriteLine($"Income for {currMonth}/{currYear} was {countMonth}");
            StreamWriter outfile = new StreamWriter(whichFile);
            outfile.WriteLine($"Income for {currMonth}/{currYear} was {countMonth}");
            outfile.Close();
            currMonth = newTransaction.GetMonth();
            countMonth = newTransaction.GetCost();
        }
        public void ProcessBreakYear(ref int currYear, ref int currMonth, ref int countYear, ref int countMonth, Transaction newTransaction, string whichFile)//save to file
        {
            System.Console.WriteLine("");
            System.Console.WriteLine($"Income for {currYear} was {countYear}");
            StreamWriter outfile = new StreamWriter(whichFile);
            outfile.WriteLine($"Income for {currYear} was {countYear}");
            outfile.Close();
            currMonth = newTransaction.GetMonth();
            countMonth = newTransaction.GetCost();
            currYear = newTransaction.GetYear();
            countYear = newTransaction.GetCost();
        }
        public void PrintByEmail(string email)//one customer, sorted by email
        {
            for(int i = 0; i < Transaction.GetCount(); i++)
            {
                if (email == transactions[i].GetCustomerEmail())
                {
                System.Console.WriteLine(transactions[i].ToStringEmail());
                }


            }
        }
        public void PrintWriteByEmail(string email, string whichFile)
        {
            StreamWriter outFile = new StreamWriter(whichFile);
            for(int i = 0; i < Transaction.GetCount(); i++)
            {
                if (email == transactions[i].GetCustomerEmail())
                {
                System.Console.WriteLine(transactions[i].ToStringEmail());
                outFile.WriteLine(transactions[i].ToStringEmail());
                }


            }
            outFile.Close();
        }
        public void PrintCustomerYearMonth()
        {
            string currName = transactions[0].GetCustomerName();
            System.Console.WriteLine($"Appointment history for {currName}:");
            int count = 0;
            for (int i = 1; i < Transaction.GetCount(); i++)
            {
                if (transactions[i].GetCustomerName() == currName)
                {
                    count++;
                    System.Console.WriteLine(transactions[i].ToString());
                }
                else
                {
                    ProcessBreak(ref currName, ref count, transactions[i]);
                }
            
            }
        }
        public void ProcessBreak(ref string currName, ref int count, Transaction newTransaction)
        {
            System.Console.WriteLine($"{currName} has had {count} appointments.");
            currName = newTransaction.GetCustomerName();
            System.Console.WriteLine($"\nAppointments for {currName}: ");

        }
        public void PrintWriteCustomerYearMonth(string whichFile)
        {
            string currName = transactions[0].GetCustomerName();
            System.Console.WriteLine($"Appointment history for {currName}:");
            int count = 0;
            for (int i = 1; i < Transaction.GetCount(); i++)
            {
                if (transactions[i].GetCustomerName() == currName)
                {
                    count++;
                    System.Console.WriteLine(transactions[i].ToString());
                }
                else
                {
                    ProcessBreak(ref currName, ref count, transactions[i], whichFile);
                }
            
            }
        }
        public void ProcessBreak(ref string currName, ref int count, Transaction newTransaction, string whichFile)
        {
            System.Console.WriteLine($"{currName} has had {count} appointments.");
            StreamWriter outfile = new StreamWriter(whichFile);
            outfile.WriteLine($"{currName} has had {count} appointments.");
            outfile.Close();
            currName = newTransaction.GetCustomerName();
            System.Console.WriteLine($"\nAppointments for {currName}: ");
        }
        
    
    }
}