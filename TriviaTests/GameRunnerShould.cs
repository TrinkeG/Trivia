using System;
using Moq;
using NUnit.Framework;
using Trivia;
using UglyTrivia;

namespace TriviaTests
{
    [TestFixture]
    public class GameRunnerShould
    {
        [Test]
        public void CreatePlayers()
        {
            var gameMock = new Mock<Game>();
            new GameRunner(gameMock.Object).PlayGame(new Random(5));
            gameMock.Verify(game => game.Add(It.IsAny<Player>()));
            
        }
    }
}