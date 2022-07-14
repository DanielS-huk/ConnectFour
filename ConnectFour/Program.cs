using System;

namespace ConnectFour
{
    class Program
    {
        static void Main(string[] args)
        {
            GameInterface connectFour = new GameInterface();
            connectFour.StartGame();
        }
    }
}
