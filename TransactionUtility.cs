namespace mis_221_pa_5_bjlenox
{
    public class TransactionUtility
    {
        private Transaction[] transactions;

        public TransactionUtility(Transaction[] transactions)
        {
            this.transactions = transactions;
        }
        public void GetAllTransactionsFromFile()
        {
            StreamReader inFile = new StreamReader("transactions.txt");//open
            //process
            Transaction.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null)
            {
                string[] temp = line.Split('#');
                transactions[Transaction.GetCount()] = new Transaction(int.Parse(temp[0]), int.Parse(temp[1]), temp[2], temp[3], temp[4], int.Parse(temp[5]), int.Parse(temp[6]), int.Parse(temp[7]), int.Parse(temp[8]), int.Parse(temp[9]), bool.Parse(temp[10]));
                Transaction.IncCount();
                line = inFile.ReadLine();
            }     
            inFile.Close();//close       
        }
        public void AddTransaction(int listingId, int trainerId, string trainerName, string customerName, string customerEmail, int year, int month, int day, int hour, int cost)
        {
            Transaction addTransaction = new Transaction(listingId, trainerId, trainerName, customerName, customerEmail, year, month, day, hour, cost, false);
            transactions[Transaction.GetCount()] = addTransaction;
            Transaction.IncCount();
            SortYearMonth();
            Save();
        }
        public void Save()
        {
            StreamWriter outfile = new StreamWriter("transactions.txt");
            for (int i = 0; i < Transaction.GetCount(); i++)
            {
                outfile.WriteLine(transactions[i].ToFile());
            }
            outfile.Close();
        }
        public void SortYearMonth()
        {
            for(int i = 0; i < Transaction.GetCount() - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < Trainer.GetCount(); j++)
                {
                    if(transactions[j].GetYear().CompareTo(transactions[min].GetYear()) < 0 || (transactions[j].GetYear() == transactions[min].GetYear() && transactions[j].GetMonth() < transactions[min].GetMonth()))
                    {
                        min = j;
                    }
                }
                if(min != i)
                {
                    Swap(min, i);
                }
            }
        }
        public void SortCustomerYearMonth()
        {
            for(int i = 0; i < Transaction.GetCount() - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < Trainer.GetCount(); j++)
                {
                    DateTime dateTimeJ = new DateTime(transactions[j].GetYear(), transactions[j].GetMonth(), transactions[j].GetDay(), transactions[j].GetHour(), 0, 0);
                    DateTime dateTimeMin = new DateTime(transactions[min].GetYear(), transactions[min].GetMonth(), transactions[min].GetDay(), transactions[min].GetHour(), 0, 0);
                    if(transactions[j].GetCustomerName().CompareTo(transactions[min].GetCustomerName()) < 0 || (transactions[j].GetCustomerName() == transactions[min].GetCustomerName() && dateTimeJ < dateTimeMin))
                    {
                        min = j;
                    }
                }
                if(min != i)
                {
                    Swap(min, i);
                }
            }
        }
        public void SortCustomerEmail()
        {
            for(int i = 0; i < Transaction.GetCount() - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < Trainer.GetCount(); j++)
                {
                    
                    if(transactions[j].GetCustomerEmail().CompareTo(transactions[min].GetCustomerEmail().ToUpper()) < 0)
                    {
                        min = j;
                    }
                }
                if(min != i)
                {
                    Swap(min, i);
                }
            }
        }
        private void Swap(int x, int y)
        {
            Transaction temp = transactions[x];
            transactions[x] = transactions[y];
            transactions[y] = temp;
        }
    }
}