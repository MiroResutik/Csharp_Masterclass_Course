namespace TaskManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var emailTask = new EmailTask()
            {
                Message = "\nHello, this is a test email. ",
                Recipient = "example@example.co.uk"
            };

            var reportTask = new ReportTask()
            {
                ReportName = "\nAnnual Report!!!!"
            };


            var emialProcessor = new TaskProcessor<EmailTask, string>(emailTask);
            var reportProcessor = new TaskProcessor<ReportTask, string>(reportTask);

            Console.WriteLine(emialProcessor.Execute());
            Console.WriteLine(reportProcessor.Execute());

            Console.ReadKey();

        }
    }
}
