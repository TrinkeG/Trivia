using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UglyTrivia;

namespace Trivia
{
    public class Program
    {
        public static void Main(String[] args)
        {
            var gameRunner = new GameRunner();
            gameRunner.PlayGame(new Random());
        }
    }

}

