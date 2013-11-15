using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Bl
{
    public class Game
    {
        public Game()
        {
            rolled = 0;
            currentFrame = 1;
            currentFrameBalls = 0;
        }

        public void Roll(int pin)
        {
            rolled++;
            currentFrameBalls++;
            pinsPerBall[rolled] = pin;
            frames[rolled] = currentFrame;
            if (currentFrame < 10)
            {
                //scored a strike, move to next frame
                if (currentFrameBalls == 1 && pinsPerBall[rolled] == NPINS)
                {
                    currentFrameBalls = 0;
                    currentFrame++;
                };
                //rolled two balls, move to next frame
                if (currentFrameBalls == 2)
                {
                    currentFrameBalls = 0;
                    currentFrame++;
                }
            }

            //if (rolled % 2 == 0)
            //{
            //    currentFrame++;
            //}
            //if (pinsPerBall[rolled] == NPINS)
            //{
            //    currentFrame++;
            //}
            //if (multiplyBy[rolled] == 0)
            //{
            //    multiplyBy[rolled] = 1;
            //}
            ////first ball
            //if (rolled % 2 == 0)
            //{
            //    if (pin == NPINS)
            //    {
            //        if (rolled + 2 < multiplyBy.Length)
            //        {
            //            multiplyBy[rolled + 1] = 2;
            //        }
            //        if (rolled + 2 < multiplyBy.Length)
            //        {
            //            multiplyBy[rolled + 2] = 2;
            //        }
            //        rolled += 1;//i.e. only one ball if strike
            //    }
            //}

            ////second ball
            //if (rolled % 2 == 1)
            //{
            //}
            
        }
        public int Score()
        {
            int tmp = 0;
            for (int i = 1; i <= rolled; i++)
            {
                if (isStrike(i))
                {
                    tmp += computeStrikeBonus(i);
                }
                if (isSpare(i))
                {
                    tmp += computeSplitBonus(i);
                }
                tmp += pinsPerBall[i];
            }
            //for (int i = 0; i < rolled; i++)
            //{
            //    tmp += pinsPerBall[i] * multiplyBy[i];
            //}
            //for (int i = 0; i < rolled; i++)
            //{
            //    if (pins[i] == NPINS) { 
            //    }
            //}
            return tmp;
        }

        private int computeSplitBonus(int i)
        {
            if (frames[i] == 10) return 0;
            return pinsPerBall[i + 1];
            throw new NotImplementedException();
        }

        private bool isSpare(int i)
        {
            if (isFirstBallOfFrame(i))
            {
                return false;
            }
            else
            {
                return (pinsPerBall[i] + pinsPerBall[i - 1]) == NPINS;
            }

        }

        private int computeStrikeBonus(int i)
        {
            if (frames[i] == 10) return 0;
            return pinsPerBall[i + 1] + pinsPerBall[i + 2];
            //throw new NotImplementedException();
        }
        /*
         
         1: 1 1     no
         2: 0 10    no
         3: 10 x    yes
         * 
         * 
         * 1 1,  0 10
         * 1 1, 10 x
         *  10, 10
         *      10, 0 10
         */
        //
        private bool isStrike(int i)
        {
            if (pinsPerBall[i] == NPINS)
            {
                if (isFirstBallOfFrame(i)) return true;

                //if (i % 2 == 0)
                //{
                //    return true;
                //}
                //else
                //{
                //    return pinsPerBall[i - 1] == NPINS;
                //}
            }
            return false;
            //if (i % 2 == 1 && pinsPerBall[i] == NPINS) return false;
            //return i % 2 == 0 && pinsPerBall[i] == NPINS;
        }

        private bool isFirstBallOfFrame(int i)
        {
            if (i == 1)
            {
                return true;
            }
            if (i > 1)
            {
                return frames[i - 1] != frames[i];
            }
            return false;
            //throw new NotImplementedException();
        }

        private int[] pinsPerBall = new int[22];
        private int[] frames = new int[22];
        private int[] multiplyBy = new int[22];
        private int rolled { get; set; }
        private int NPINS = 10;

        public int currentFrame { get; set; }

        public int currentFrameBalls { get; set; }
    }
}
