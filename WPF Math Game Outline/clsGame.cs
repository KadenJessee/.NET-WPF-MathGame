using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Math_Game_Outline
{
    internal class clsGame
    {
        /// <summary>
        /// defines the game type of addition
        /// subtractions, multiplication, or division
        /// </summary>
        public enum GameType { Add, Subtract, Mult, Divide };
        /// <summary>
        /// allows for allocating what game
        /// type is being played
        /// </summary>
        private static GameType gameType;
        
        /// <summary>
        /// getter/setter for the Game Type
        /// </summary>
        public GameType GetSetGameType
        {
            get { return gameType; }
            set { gameType = value; }
        }
        
        /// <summary>
        /// generates question to display for the user
        /// </summary>
        /// <returns></returns>
        public MathGameQuestion GenerateQuestion()
        {
            MathGameQuestion question = new MathGameQuestion();

            Random random = new Random();
            //Use the gameType enum to generate a question of the MathGameQuestion type and return it
            if (gameType == GameType.Add)//add game
            {
                //set left and right numbers
                question.getLeft = random.Next(1, 11);
                question.getRight = random.Next(1, 11);
                //set added answer to those numbers
                question.getAnswer = question.getLeft + question.getRight;

                
            }else if(gameType == GameType.Subtract)//subtraction
            {
                int num1 = random.Next(1, 11);
                int num2 = random.Next(1, 11);
                //set right and left numbers
                if(num1 > num2)
                {
                    question.getLeft = num1;
                    question.getRight = num2;
                }
                else
                {
                    question.getLeft = num2;
                    question.getRight = num1;
                }
                

                //handling for no negatives, if left is greater/equal, subtract right from left (left - right)
                if(question.getLeft >= question.getRight)
                {
                    question.getAnswer = question.getLeft - question.getRight;
                }
                else //else subtract left from right (right - left)
                {
                    question.getAnswer = question.getRight - question.getLeft;
                }

            }else if (gameType == GameType.Mult) //multiplication
            {
                //left, right set
                question.getLeft = random.Next(1, 11);
                question.getRight = random.Next(1, 11);
                //set product of left/right
                question.getAnswer = question.getLeft * question.getRight;

            }else if(gameType == GameType.Divide) //division
            {
                //random between 1-10
                int leftNumber = random.Next(1, 11);
                int rightNumber = random.Next(1, 11);

                //multiply to get firstNumber
                int firstNumber = leftNumber * rightNumber;

                //set question class
                question.getLeft = firstNumber;
                question.getRight = leftNumber;
                question.getAnswer = rightNumber;

            }
            return question;
        }

        /// <summary>
        /// validates the users guess
        /// </summary>
        /// <param name="iUserguess"></param>
        /// <returns></returns>
        public bool ValidateUserGuess(int iUserguess, int answer)
        {
            bool isCorrect = (iUserguess == answer);
            return isCorrect;
        }
    }

    /// <summary>
    /// holds variables for each math
    /// question
    /// </summary>
    public class MathGameQuestion
    {
        /// <summary>
        /// the left number of the question
        /// </summary>
        private static int leftNumber;
        /// <summary>
        /// the right number of the question
        /// </summary>
        private static int rightNumber;
        /// <summary>
        /// the answer for the question
        /// </summary>
        private static int answer;

        /// <summary>
        /// getter/setter for the left number
        /// </summary>
        public int getLeft
        {
            get { return leftNumber; }
            set { leftNumber = value; }
        }

        /// <summary>
        /// getter/setter for the right number
        /// </summary>
        public int getRight
        {
            get { return rightNumber; }
            set { rightNumber = value; }
        }

        /// <summary>
        /// getter/setter for the answer
        /// </summary>
        public int getAnswer
        {
            get { return answer; }
            set { answer = value; }
        }
    }
}
