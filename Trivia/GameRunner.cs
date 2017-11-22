using System;
using UglyTrivia;

namespace Trivia
{
    public class GameRunner
    {
        private bool _notAWinner;
        private readonly Game _game;

        public GameRunner(): this(new Game())
        {
        }

        public GameRunner(Game game)
        {
            _game = game;
        }

        public void PlayGame(Random rand)
        {
            _game.Add(new Player("Chet"));
            _game.Add(new Player("Pat"));
            _game.Add(new Player("Sue"));

            do
            {
                _game.Roll(rand.Next(5) + 1);

                if (rand.Next(9) == 7)
                {
                    _notAWinner = _game.WrongAnswer();
                }
                else
                {
                    _notAWinner = _game.WasCorrectlyAnswered();
                }
            } while (_notAWinner);
        }
    }
}