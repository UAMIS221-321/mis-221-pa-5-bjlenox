namespace mis_221_pa_5_bjlenox
{
    public class TrainerUtility
    {
        private Trainer[] trainers;

        public TrainerUtility(Trainer[] trainers)
        {
            this.trainers = trainers;
        }
        public void GetAllTrainersFromFile()
        {
            StreamReader inFile = new StreamReader("trainers.txt");//open
            //process
            Trainer.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null)
            {
                string[] temp = line.Split('#');
                trainers[Trainer.GetCount()] = new Trainer(int.Parse(temp[0]), temp[1], temp[2], temp[3], bool.Parse(temp[4]));
                Trainer.IncCount();
                line = inFile.ReadLine();
            }


            inFile.Close();//close
        }
        public void AddTrainer()//maxid
        {
            System.Console.WriteLine("What is the trainer's name?");
            string tempName = Console.ReadLine();
            System.Console.WriteLine("What is their home address?");
            string tempAddy = Console.ReadLine();
            System.Console.WriteLine("What is their email address?");
            string tempEmail = Console.ReadLine();
            Trainer addtrainer = new Trainer(tempName, tempAddy, tempEmail);
            trainers[Trainer.GetCount()] = addtrainer;
            Trainer.IncCount();
            Sort();
            Save();

        }
        public void DeleteTrainer()
        {
            System.Console.WriteLine("What is the name of the trainer you would like to delete?");
            string searchVal = Console.ReadLine();
            int foundIndex = Find(searchVal);
            if (foundIndex != -1)
            {
                trainers[foundIndex].SetDeleted(true);
                
                System.Console.WriteLine($"{searchVal} has been deleted.");
            }
            else
            {
                System.Console.WriteLine("Trainer not found.");
            }
        }
        private void Save()
        {
            StreamWriter outfile = new StreamWriter("trainers.txt");
            for (int i = 0; i < Trainer.GetCount(); i++)
            {
                outfile.WriteLine(trainers[i].ToFile());
            }
            outfile.Close();
        }
        public int Find(string searchVal)
        {
            for (int i = 0; i < Trainer.GetCount(); i++)
            {
                if(trainers[i].GetTrainerName().ToUpper() == searchVal.ToUpper())
                {
                    return i;
                }
            }
            return -1;
        }

        public void UpdateTrainer()
        {
            System.Console.WriteLine("What is the name of the trainer you would like to edit?");
            string searchVal = Console.ReadLine();
            int foundIndex = Find(searchVal);
            if(foundIndex != -1)
            {
                System.Console.WriteLine("What is the trainer's name?");
                trainers[foundIndex].SetTrainerName(Console.ReadLine());
                System.Console.WriteLine("What is the trainer's address?");
                trainers[foundIndex].SetTrainerAddress(Console.ReadLine());
                System.Console.WriteLine("What is the trainer's email?");
                trainers[foundIndex].SetTrainerEmail(Console.ReadLine());
                Save();
                Sort();
            }
            else
            {
                System.Console.WriteLine("Trainer not found.");
            }
        }
        public void Sort()//sort by trainer name
        {
            for(int i = 0; i < Trainer.GetCount() - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < Trainer.GetCount(); j++)
                {
                    if(trainers[min].GetTrainerName().CompareTo(trainers[j].GetTrainerName()) < 0)
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
            Trainer temp = trainers[x];
            trainers[x] = trainers[y];
            trainers[y] = temp;
        }
        public void PrintAllTrainers()
        {
            for (int i = 0; i < Trainer.GetCount(); i++)
            {
                System.Console.WriteLine(trainers[i].ToString());
            }
        }

    }
}