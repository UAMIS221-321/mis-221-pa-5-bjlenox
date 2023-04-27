namespace mis_221_pa_5_bjlenox
{
    public class ListingReport
    {
        Listing[] listings;

        public ListingReport(Listing[] listings)
        {
            this.listings = listings;
        }
        public void PrintAllListings()
        {
            for (int i = 0; i < Listing.GetCount(); i++)
            {
                System.Console.WriteLine(listings[i].ToString());
            }
        }
        public void PrintWriteAllListings(string whichFile)
        {
            StreamWriter outfile = new StreamWriter(whichFile);
            for (int i = 0; i < Listing.GetCount(); i++)
            {
                System.Console.WriteLine(listings[i].ToString());
                listings[i].ToFile();
            }
            outfile.Close();

        }
    }
}