namespace mis_221_pa_5_bjlenox
{
    public class ListingUtility
    {
        private Listing[] listings;

        public ListingUtility(Listing[] listings, TrainerUtility trainerUtility, TransactionUtility transUtility)
        {
            this.listings = listings;
            this.TUtility = trainerUtility;
            this.transUtility = transUtility;
        }

        public Trainer[] trainers = new Trainer[999];
        public TrainerUtility TUtility;
        public Transaction[] transactions = new Transaction[999];
        public TransactionUtility transUtility;

        

        public void GetListingsFromFile()
        {
            StreamReader inFile = new StreamReader("listings.txt");//open
            //process
            Listing.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null)
            {
                string[] temp = line.Split('#');
                DateTime compDateTime = new DateTime (int.Parse(temp[3]), int.Parse(temp[4]), int.Parse(temp[5]), int.Parse(temp[6]), 0, 0);
                if (compDateTime < DateTime.Now)//compares date of appointment to current date
                {
                    temp[9] = "true";
                }
                else temp[9] = "false";
                listings[Listing.GetCount()] = new Listing(int.Parse(temp[0]), int.Parse(temp[1]), temp[2], int.Parse(temp[3]),int.Parse(temp[4]),int.Parse(temp[5]),int.Parse(temp[6]), int.Parse(temp[7]), bool.Parse(temp[8]), temp[9], temp[10], bool.Parse(temp[11]));
                Listing.IncCount();
                line = inFile.ReadLine();
            }     
            inFile.Close();       
        }
        public void AddListing()
        {
            System.Console.WriteLine("What is the name of the trainer?");
            string tempName = Console.ReadLine();
                int foundIndexTrainer = TUtility.Find(tempName);
                while (foundIndexTrainer == -1)
                {
                    System.Console.WriteLine("That trainer does not exist. Please enter an existing trainer. To add a new trainer, please visit the employee menu.");
                    tempName = Console.ReadLine();
                    foundIndexTrainer = TUtility.Find(tempName);
                }
            
            System.Console.WriteLine("What year is the appointment?");
            int tempYear = int.Parse(Console.ReadLine());
            System.Console.WriteLine("What month is the appointment?");
            int tempMonth = int.Parse(Console.ReadLine());
            System.Console.WriteLine("What day is the appointment?");
            int tempDate = int.Parse(Console.ReadLine());
            System.Console.WriteLine("What time is the appointment? Enter an hour 1-24.");
            int tempHour = int.Parse(Console.ReadLine());
            int tempTrainerId = trainers[foundIndexTrainer].GetTrainerId();
            Listing addListing = new Listing(tempTrainerId, tempName, tempYear, tempMonth, tempDate, tempHour);
            listings[Listing.GetCount()] = addListing;
            Listing.IncCount();
            SortCustomer();
            Save();
            

        }
        public void DeleteListing()
        {
            System.Console.WriteLine("What is the ID of the listing you would like to delete?");
            string searchVal = Console.ReadLine();
            int foundIndex = Find(searchVal);
            if (foundIndex != -1)
            {
                listings[foundIndex].SetDeleted(true);
                
                System.Console.WriteLine($"{searchVal} has been deleted.");
            }
            else
            {
                System.Console.WriteLine("Trainer not found.");
            }
        }
        public void UpdateListing()
        {
            System.Console.WriteLine("What is the ID of the listing you would like to edit?");
            string searchVal = Console.ReadLine();
            int foundIndex = Find(searchVal);
            if(foundIndex != -1)
            {
                System.Console.WriteLine("Who is the trainer of the session");
                searchVal = Console.ReadLine();
                int foundIndexTrainer = TUtility.Find(searchVal);
                while (foundIndexTrainer == -1)
                {
                    System.Console.WriteLine("That trainer does not exist. Please enter an existing trainer. To add a new trainer, please visit the employee menu.");
                    searchVal = Console.ReadLine();
                    foundIndexTrainer = TUtility.Find(searchVal);
                }
                listings[foundIndex].SetTrainerName(searchVal);
                int tempTrainerId = trainers[foundIndexTrainer].GetTrainerId();
                listings[foundIndex].SetTrainerId(tempTrainerId);
                System.Console.WriteLine("In what year is the session (yyyy)");
                listings[foundIndex].SetYear(int.Parse(Console.ReadLine()));
                System.Console.WriteLine("In what month is the session (mm)");
                listings[foundIndex].SetMonth(int.Parse(Console.ReadLine()));
                System.Console.WriteLine("On what date is the session(dd)");
                listings[foundIndex].SetDay(int.Parse(Console.ReadLine()));
                System.Console.WriteLine("At what time is the session (please enter an hour 0-23)");
                listings[foundIndex].SetHour(int.Parse(Console.ReadLine()));
                Save();
            }
            else
            {
                System.Console.WriteLine("Trainer not found.");
            }
        }
        private void Save()
        {
            StreamWriter outfile = new StreamWriter("listings.txt");
            for (int i = 0; i < Listing.GetCount(); i++)
            {
                outfile.WriteLine(listings[i].ToFile());
            }
            outfile.Close();
        }
        private int FindByName(string searchVal)
        {
            for (int i = 0; i < Listing.GetCount(); i++)
            {
                if(listings[i].GetTrainerName().ToUpper() == searchVal.ToUpper() && (listings[i].GetDeleted() == false))
                {
                    return i;
                }
            }
            return -1;
        }
        private int Find (string searchVal)
        {

            for (int i = 0; i < Listing.GetCount(); i++)
            {
                if( listings[i].GetListingId() == int.Parse(searchVal) && (listings[i].GetDeleted() == false))
                {
                    return i;
                }
            }
            return -1;
        }
        public void PrintAllListings()
        {
            for (int i = 0; i < Listing.GetCount(); i++)
            {
                if(listings[i].GetDeleted() == false)
                {
                System.Console.WriteLine(listings[i].ToString());
                }
            }
        }
        public void PrintAvailableListings()
        {
            for (int i = 0; i < Listing.GetCount(); i++)
            {
                bool displayQ = listings[i].GetTaken();
                if (displayQ == false && (listings[i].GetDeleted() == false))
                {
                System.Console.WriteLine(listings[i].ToString());
                }
            }
        }
        public void PrintCancellableListings(string customerName)
        {
           for (int i = 0; i < Listing.GetCount(); i++)
            {
                bool displayQ = listings[i].GetTaken();
                if (displayQ == true && (listings[i].GetDeleted() == false))
                {
                System.Console.WriteLine(listings[i].ToString());
                }
            } 
        }
        public void BookListing()//customer
        {
            System.Console.WriteLine("Would you like to see a list of all available listings? Enter 'YES' or 'NO'.");
            string printQ = Console.ReadLine().ToUpper();
            if (printQ == "YES")
            {
                PrintAvailableListings();
                System.Console.WriteLine("");//spacing
            }
            System.Console.WriteLine("\nWhat is the ID of the listing you would like to book?");
            string listingIdBook = Console.ReadLine();
            int foundListingId = Find(listingIdBook);
            if (foundListingId != -1)
            {
                System.Console.WriteLine("What is your name?");
                string customerName = Console.ReadLine();
                System.Console.WriteLine("What is your email?");
                string customerEmail = Console.ReadLine();
                listings[foundListingId].SetCustomerName(customerName);
                listings[foundListingId].SetCustomerEmail(customerEmail);
                listings[foundListingId].SetTaken(true);
                int bookedYear = listings[foundListingId].GetYear();
                int bookedMonth = listings[foundListingId].GetMonth();
                int bookedDay = listings[foundListingId].GetDay();
                System.Console.WriteLine($"Thank you for booking. Don't forget to attend your appointment on {bookedDay}/{bookedMonth}/{bookedYear}.\nYou will recieve a reminder email at {customerEmail}.");
                Save();
                transUtility.AddTransaction(listings[foundListingId].GetListingId(), listings[foundListingId].GetTrainerId(), listings[foundListingId].GetTrainerName(), customerName, customerEmail, bookedYear, bookedMonth, bookedDay, listings[foundListingId].GetHour(), listings[foundListingId].GetCost());
                transUtility.Save();
            }
            else
            {
                System.Console.WriteLine("Sorry, that listing does not exist.");
            }


        }
        public void CancelListing()//customer
        {
            System.Console.WriteLine("What is your name?");
            string customerName = Console.ReadLine().ToUpper();
            PrintCancellableListings(customerName);
            System.Console.WriteLine("Here are all of your appointments? What is the ID of the appointment you would like to cancel?");
            string listingIdCancel = Console.ReadLine();
            int foundListingId = Find(listingIdCancel);
            if (foundListingId != -1)
            {
                listings[foundListingId].SetTaken(false);
                listings[foundListingId].SetCustomerName("null");
                listings[foundListingId].SetCustomerEmail("null");
                System.Console.WriteLine("Your appointment has been cancelled.");
                Save();
                
            }
            else
            {
                System.Console.WriteLine("Sorry, that listing does not exist.");
            }
        }
        public void SortCustomer()//sort by customer name
        {
            for(int i = 0; i < Trainer.GetCount() - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < Trainer.GetCount(); j++)
                {
                    if(listings[min].GetCustomerName().CompareTo(listings[j].GetCustomerName()) < 0)
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
            Listing temp = listings[x];
            listings[x] = listings[y];
            listings[y] = temp;
        }
    }
}