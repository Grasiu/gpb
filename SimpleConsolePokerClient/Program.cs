using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GrasiuPokerBot;

namespace SimpleConsolePokerClient
{
    class Program
    {
        static void Main(string[] args)
        {
            PokerAI ai = new PokerAI();
            ai.LoadHand();
            ai.PlayHand();
            Console.ReadKey();
        }
    }
}
