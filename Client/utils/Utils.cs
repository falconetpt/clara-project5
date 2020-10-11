using System;

namespace Client.utils
{
    public class Utils
    {
        public static String AskInput(string Message)
        {
            Console.WriteLine(Message);
            return Console.ReadLine();
        }
    }
}