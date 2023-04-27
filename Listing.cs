namespace mis_221_pa_5_bjlenox
{
    public class Listing
    {
        private int listingId;
        private string trainerName;
        private int trainerId;
        private int year;
        private int month;
        private int day;
        private int hour;
        private int cost;
        private bool taken;
        static private int count;
        private bool deleted;
        private string customerName;
        private string customerEmail;

        public Listing(int trainerId, string trainerName, int year, int month, int day, int hour)//new
        {
            this.listingId = (File.ReadAllLines("listings.txt").Length) + 1;
            this.trainerId = trainerId;
            this.trainerName = trainerName;
            this.year = year;
            this.month = month;
            this.day = day;
            this.hour = hour;
            this.cost = 50;
            this.taken = false;
            this.deleted = false;
            this.customerName = "null";
            this.customerEmail = "null";
        }
        public Listing(int listingId, int trainerId, string trainerName, int year, int month, int day, int hour, int cost, bool taken, string customerName, string customerEmail, bool deleted)//from file
        {
            this.listingId = listingId;
            this.trainerId = trainerId;
            this.trainerName = trainerName;
            this.year = year;
            this.month = month;
            this.day = day;
            this.hour = hour;
            this.cost = cost;
            this.taken = taken;
            this.deleted = deleted;
            this.customerName = customerName;
            this.customerEmail = customerEmail;
        }
        public void SetTrainerName(string trainerName)
        {
            this.trainerName = trainerName;
        }
        public string GetTrainerName()
        {
            return trainerName;
        }
        public void SetYear(int year)
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
        public void SetTaken(bool taken)
        {
            this.taken = taken;
        }
        public bool GetTaken()
        {
            return taken;
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
            Listing.count = count;
        }
        static public void IncCount()
        {
            count++;
        }
        static public int GetCount()
        {
            return count;
        }
        public int GetListingId()
        {
            return listingId;
        }
        public string GetCustomerName()
        {
            return customerName;
        }
        
        public void SetCustomerName(string customerName)
        {
            this.customerName = customerName;
        }
        public string GetCustomerEmail()
        {
            return customerEmail;
        }
        public void SetCustomerEmail(string customerEmail)
        {
            this.customerEmail = customerEmail;
        }
        public int GetTrainerId()
        {
            return trainerId;
        }
        public void SetTrainerId(int trainerId)
        {
            this.trainerId = trainerId;
        }
        public string ToFile()
        {
            return $"{listingId}#{trainerId}#{trainerName}#{year}#{month}#{day}#{hour}#{cost}#{taken}#{customerName}#{customerEmail}#{deleted}";
        }
        public override string ToString()
        {
            return $"Listing {listingId} is hosted by {trainerName} on {day}/{month}/{year} and costs ${cost}";
        }
    }
    
}