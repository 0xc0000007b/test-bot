using TelegaBot.Core;

namespace TelegaBot
{
    internal class Program
    {
       static Bot botCore = new Bot();
        public static void Main(string[] args)
        {
            botCore.Initialize();
        }
    }
}