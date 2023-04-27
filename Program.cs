
using mis_221_pa_5_bjlenox;
Trainer[] trainers = new Trainer[999];
TrainerUtility tUtility = new TrainerUtility(trainers);
Listing[] listings = new Listing[999];
Transaction[] transactions = new Transaction[999];
TransactionUtility transUtility = new TransactionUtility(transactions);
ListingUtility lUtility = new ListingUtility(listings, tUtility, transUtility);
TransactionReport transReport = new TransactionReport(transactions);
ListingReport lReport = new ListingReport(listings);
TrainerReport tReport = new TrainerReport(trainers);
tUtility.GetAllTrainersFromFile();
lUtility.GetListingsFromFile();
transUtility.GetAllTransactionsFromFile();

DisplayMainMenu();
int menuChoice = AskMainMenuChoice();
if (menuChoice != 3)
{
    if (menuChoice == 1)
    {
        RoutingMethodCustomer(lUtility, tUtility);
        menuChoice = 3;
    }
    else if (menuChoice == 2)
    {
        EmployeePassword();
        RoutingMethodEmployee(tUtility, lUtility, transReport, lReport, tReport, transUtility);
        menuChoice = 3;
    }
}


//end main

static int AskMainMenuChoice()
{
    
    string menuChoice = System.Console.ReadLine();
     if (IsValidMainChoice(menuChoice))
    {
        return int.Parse(menuChoice);
    }
    else
    {
        return 0;
    }
}
static void DisplayMainMenu()
{
    System.Console.WriteLine("Welcome to the TLAC portal\nEnter 1 if you are a customer \nEnter 2 if you are an employee");
}
static bool IsValidMainChoice(string userInput)
{
    if (userInput=="1" || userInput=="2" ||userInput=="3")
    {
        return true;
    }
    return false;
}
static void RoutingMethodEmployee(TrainerUtility tUtility, ListingUtility LUtility, TransactionReport transReport, ListingReport lReport, TrainerReport tReport, TransactionUtility transUtility)
{
    int menuChoice = AskEmployeeMenuChoice();
    while (menuChoice != 8)
    {
    if (menuChoice == 1)//add trainer
    {
        tUtility.AddTrainer();;
    }
    else if (menuChoice == 2)//edit trainer
    {
        tUtility.UpdateTrainer();
    }
    else if (menuChoice == 3)//delete trainer
    {
        tUtility.DeleteTrainer();
    }
    else if (menuChoice == 4)//add listing
    {
        LUtility.AddListing();
    }
    else if (menuChoice == 5)//edit listing
    {
        LUtility.UpdateListing();
    }
    else if (menuChoice == 6)//delete listing
    {
        LUtility.DeleteListing();
    }
    else if (menuChoice == 7)//reports
    {
       ReportMenu(transReport, lReport, tReport, transUtility, tUtility);
    }
    else if (menuChoice == 0)
    {
        InvalidEntry();
    }
    menuChoice = AskEmployeeMenuChoice();
    }
}
static void RoutingMethodCustomer(ListingUtility LUtility, TrainerUtility TUtility)
{
    
    int menuChoice = AskCustomerMenuChoice();
    while(menuChoice != 3)
    {
        if (menuChoice == 1)
        {
            LUtility.BookListing();
        }
        else if (menuChoice == 2)
        {
           LUtility.CancelListing();
        }
        menuChoice = AskCustomerMenuChoice();
    }
}
static int AskCustomerMenuChoice()
{
    System.Console.WriteLine("Enter 1 to book a session\nEnter 2 to cancel an existing booking\nEnter 3 to exit.");
     string menuChoice = System.Console.ReadLine();
     if (IsValidCustomerChoice(menuChoice))
    {
        return int.Parse(menuChoice);
    }
    else
    {
        return 0;
    }   
}
static bool IsValidCustomerChoice(string menuChoice)
{
    if (menuChoice=="1" || menuChoice=="2" || menuChoice == "3")
    {
        return true;
    }
    return false;   
}
static void InvalidEntry()
{
    System.Console.WriteLine("Invalid entry");
}
static int AskEmployeeMenuChoice()
{
    System.Console.WriteLine("Enter 1 to add a trainer\nEnter 2 to edit an existing trainer\nEnter 3 to delete a trainer\nEnter 4 to add a listing\nEnter 5 to edit a listing\nEnter 6 to delete a listing\nEnter 7 to run reports\nEnter 8 to exit");
    string menuChoice = System.Console.ReadLine();
     if (IsValidEmployeeChoice(menuChoice))
    {
        return int.Parse(menuChoice);
    }
    else
    {
        return 0;
    }
}
static bool IsValidEmployeeChoice(string menuChoice)
{

    if (menuChoice=="1" || menuChoice=="2" ||menuChoice=="3"||menuChoice=="4"||menuChoice=="5"||menuChoice=="6"||menuChoice=="7" || menuChoice =="8")
    {
        return true;
    }
    return false;

}
static void EmployeePassword()
{
    System.Console.WriteLine("Please enter the password: ");
    string passAttempt = Console.ReadLine();
    while (passAttempt != "password")
    {
        System.Console.WriteLine("Sorry, incorrect password. Please try again.");
        passAttempt = Console.ReadLine();
    }
}
static void ReportMenu(TransactionReport transReport, ListingReport lReport, TrainerReport tReport, TransactionUtility transUtility, TrainerUtility tUtility)
{
    System.Console.WriteLine("Enter 1 to view all transactions\nEnter 2 to view all listings\nEnter 3 to view all trainers\nEnter 4 to view revenue by month and by year\nEnter 5 to view session history for one customer\nEnter 6 to view sessions by customer");
    string menuChoice = Console.ReadLine();
    bool reportToFile = ReportToFile();
    string whichFile = "";
    if(reportToFile)
    {
        whichFile = ReportToWhichFile();
    }
    if (menuChoice == "1" && reportToFile == true)
    {
        transReport.PrintWriteAllTransactions(whichFile);
    }
    else if (menuChoice == "1" && reportToFile == false)
    {
        transReport.PrintAllTransactions();
    }
    else if (menuChoice == "2" && reportToFile == false)
    {
        lReport.PrintAllListings();
    }
    else if (menuChoice == "2" && reportToFile == true)
    {
        lReport.PrintWriteAllListings(whichFile);
    }
    else if (menuChoice == "3" && reportToFile == false)//printalltrainers
    {
        tReport.PrintAllTrainers();
    }
    else if (menuChoice == "3" && reportToFile == true)//printwritealltrainers
    {
        tReport.PrintWriteAllTrainers();
    }
    else if (menuChoice == "4" && reportToFile == false)
    {
        transUtility.SortYearMonth();
        transReport.PrintIncomeYearMonth();
    }
    else if (menuChoice == "4" && reportToFile == true)
    {   
        transUtility.SortYearMonth();
        transReport.PrintWriteIncomeYearMonth(whichFile);
    }
    else if (menuChoice == "5" && reportToFile == false)//one customer, sorted by email
    {
        transUtility.SortCustomerEmail();
        System.Console.WriteLine("What is the email you would like a report of?");
        string email = Console.ReadLine().ToUpper();
        transReport.PrintByEmail(email);
    }
    else if (menuChoice == "5" && reportToFile == true)
    {
        transUtility.SortCustomerEmail();
        System.Console.WriteLine("What is the email you would like a report of?");
        string email = Console.ReadLine().ToUpper();
        transReport.PrintWriteByEmail(email, whichFile);
    }
    else if (menuChoice == "6" && reportToFile == false)//sessions per customer, list and count per
    {
        transUtility.SortCustomerYearMonth();
        transReport.PrintCustomerYearMonth();
    }
    else if (menuChoice == "6" && reportToFile == true)
    {
        transUtility.SortCustomerYearMonth();
        transReport.PrintWriteCustomerYearMonth(whichFile);
    }
}
static bool ReportToFile()
{
    System.Console.WriteLine("Would you like to write this report to a file? Enter 'yes' or 'no'.");
    string choice = Console.ReadLine();
    if (choice == "yes")
    {
        return true;
    }
    else return false;
}
static string ReportToWhichFile()
{
    System.Console.WriteLine("What is the name of the file you would like to save to?");
    string file = Console.ReadLine();
    return file;
}