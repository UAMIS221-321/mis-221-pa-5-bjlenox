namespace mis_221_pa_5_bjlenox
{
    public class Trainer
    {
        private int trainerId;
        private string trainerName;
        private string trainerAddress;
        private string trainerEmail;
        static private int count;
        private bool deleted;

        public Trainer (string trainerName, string trainerAddress, string trainerEmail)//adding one
        {
            trainerId = (File.ReadAllLines("trainers.txt").Length) + 1;
            this.trainerName = trainerName;
            this.trainerAddress = trainerAddress;
            this.trainerEmail = trainerEmail;
            this.deleted = false;
        }
        public Trainer (int trainerId, string trainerName, string trainerAddress, string trainerEmail, bool deleted)//from file
        {
            this.trainerId = trainerId;
            this.trainerName = trainerName;
            this.trainerAddress = trainerAddress;
            this.trainerEmail = trainerEmail;
            this.deleted = deleted;
        }
        public void SetTrainerName(string trainerName)
        {
            this.trainerName = trainerName;
        }
        public string GetTrainerName()
        {
            return trainerName;
        }
        public void SetTrainerAddress(string trainerAddress)
        {
            this.trainerAddress = trainerAddress;
        }
        public string GetTrainerAddress()
        {
            return trainerAddress;
        }
        public int GetTrainerId()
        {
            return trainerId;
        }
        public void SetTrainerEmail(string trainerEmail)
        {
            this.trainerEmail = trainerEmail;
        }
        public string GetTrainerEmail()
        {
            return trainerEmail;
        }

        static public void SetCount(int count)
        {
            Trainer.count = count;
        }
        public bool GetDeleted()
        {
            return deleted;
        }
        public void SetDeleted(bool deleted)
        {
            this.deleted = deleted;
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
            return $"{trainerId}#{trainerName}#{trainerAddress}#{trainerEmail}#{deleted}";
        }


    }
}