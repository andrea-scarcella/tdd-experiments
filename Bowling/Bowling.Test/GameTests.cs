using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bowling.Bl;
using NUnit.Framework;

namespace Bowling.Test
{
    [TestFixture]
    public class GameTests
    {
        private Game game = null;
        private int nFrames = 10;

        [SetUp]
        public void setup()
        {
            game = new Game();
        }

        [Test]
        public void TwoStrikes()
        {
            game.Roll(10);
            game.Roll(10);
            for (int i = 1; i < nFrames; i++)
            {
                game.Roll(0);
                game.Roll(0);
            }
            Assert.AreEqual(30, game.Score());
        }
        [Test]
        public void FourStrikes()
        {
            game.Roll(10);//10
            game.Roll(10);//20

            game.Roll(10);//20
            game.Roll(10);//20
            for (int i = 4; i < nFrames; i++)
            {
                game.Roll(0);
                game.Roll(0);
            }
            Assert.AreEqual(90, game.Score());
        }
        [Test]
        public void AllStrikes()
        {
            for (int i = 0; i < nFrames - 1; i++)
            {
                game.Roll(10);

            }
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            Assert.AreEqual(300, game.Score());
        }
        [Test]
        public void AllSplits()
        {
            for (int i = 0; i < nFrames - 1; i++)
            {
                game.Roll(5); game.Roll(5);

            }
            game.Roll(5);
            game.Roll(5);
            game.Roll(5);
            Assert.AreEqual(150, game.Score());
        }

    }
}
