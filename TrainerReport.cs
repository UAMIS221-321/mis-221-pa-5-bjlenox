namespace mis_221_pa_5_bjlenox
{
    public class TrainerReport
    {
        Trainer[] trainers;

        public TrainerReport(Trainer[] trainers)
        {
            this.trainers = trainers;
        }
        public void PrintAllTrainers()
        {
            for (int i = 0; i < Trainer.GetCount(); i++)
            {
                System.Console.WriteLine(trainers[i].ToString());
            }
        }
        public void PrintWriteAllTrainers()
        {
            for (int i = 0; i < Trainer.GetCount(); i++)
            {
                System.Console.WriteLine(trainers[i].ToString());
            }
        }
    }
}