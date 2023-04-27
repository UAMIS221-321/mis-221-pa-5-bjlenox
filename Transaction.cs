namespace mis_221_pa_5_bjlenox
{
    public class Transaction
    {
        private int listingId;
        private int trainerId;
        private string trainerName;
        private string customerName;
        private string customerEmail;
        private int year;
        private int month;
        private int day;
        private int hour;
        private int cost;
        private bool deleted;
        private static int count;

        public Transaction(int listingId, int trainerId, string trainerName, string customerName, string customerEmail, int year, int month, int day, int hour, int cost, bool deleted)//from file
        {
            this.listingId = listingId;
            this.trainerId = trainerId;
            this.trainerName = trainerName;
            this.customerName = customerName;
            this.customerEmail = customerEmail;
            this.year = year;
            this.month = month;
            this.day = day;
            this.hour = hour;
            this.cost = cost;
            this.deleted = deleted;
        }

        public void SetListingId(int listingId)
        {
            this.listingId = listingId;
        }
        public int GetListingId()
        {
            return listingId;
        }
        public void SetTrainerId(int trainerId)
        {
            this.trainerId = trainerId;
        }
        public int GetTrainerId()
        {
            return trainerId;
        }
        public void SetTrainerName(string trainerName)
        {
            this.trainerName = trainerName;
        }
        public string GetTrainerName()
        {
            return trainerName;
        }
        public void SetCustomerName(string customerName)
        {
            this.customerName = customerName;
        }
        public string GetCustomerName ()
        {
            return customerName;
        }
        public void SetCustomerEmail (string customerEmail)
        {
            this.customerEmail = customerEmail;
        }
        public string GetCustomerEmail()
        {
            return customerEmail;
        }
        public void SetYear (int year)
        {
            this.year = year;
        }
        public int GetYear()
        {
            return year;
        }
        public void SetMonth(int month)
        {
            this.month = month;
        }
        public int GetMonth()
        {
            return month;
        }
        public void SetDay(int day)
        {
            this.day = day;
        }
        public int GetDay()
        {
            return day;
        }
        public void SetHour(int hour)
        {
            this.hour = hour;
        }
        public int GetHour()
        {
            return hour;
        }
        public void SetCost(int cost)
        {
            this.cost = cost;
        }
        public int GetCost()
        {
            return cost;
        }
        public bool GetDeleted()
        {
            return deleted;
        }
        public void SetDeleted(bool deleted)
        {
            this.deleted = deleted;
        }
        static public void SetCount(int count)
        {
            Transaction.count = count;
        }
        static public void IncCount()
        {
            count++;
        }
        static public int GetCount()
        {
            return count;
        }
        public string ToFile()
        {
            return $"{listingId}#{trainerId}#{trainerName}#{customerName}#{customerEmail}#{year}#{month}#{day}#{hour}#{cost}#{deleted}";
        }
        public override string ToString()
        {
            return $"{listingId} was hosted by {trainerName} on {day}/{month}/{year} and cost ${cost}.This session was taken by {customerName}";
        }
        public string ToStringEmail()
        {
            return $"{listingId} was hosted by {trainerName} on {day}/{month}/{year} and cost ${cost}.";
        }

    }
}