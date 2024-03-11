using System;
using System.Media;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace WPF_Math_Game_Outline
{
    /// <summary>
    /// Interaction logic for wndGame.xaml
    /// </summary>
    public partial class wndGame : Window
    {
        /// <summary>
        /// Variable to hold the high scores form.
        /// </summary>
        private wndHighScores wndCopyHighScores;

        /// <summary>
        /// object of clsGame
        /// </summary>
        clsGame clsGame;

        /// <summary>
        /// Property to get and set the high scores.
        /// </summary>
        public wndHighScores CopyHighScores
        {
            get { return wndCopyHighScores; }
            set { wndCopyHighScores = value; }
        }

        /// <summary>
        /// initalizes the window, sets objects
        /// </summary>
        public wndGame()
        {
            InitializeComponent();

            //set MyTimer object
            MyTimer = new DispatcherTimer();
            //make timer go off every second
            MyTimer.Interval = TimeSpan.FromSeconds(1);
            //which method will run
            MyTimer.Tick += new EventHandler(Timer_Tick);
            //set clsGame object
            clsGame = new clsGame();
        }

        /// <summary>
        /// ends the game and goes to the main menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdEndGame_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //quit the timer
                MyTimer.Stop();
                //hide the page
                this.Hide();
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// goes out of the game window and shows the scores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdHighScores_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Hide the game form
                this.Hide();
                //Show the high scores
                wndCopyHighScores.ShowDialog();
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// closes the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                this.Hide();
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// which question is the user on 1-10
        /// </summary>
        int iCurrentGameQuestion;
        /// <summary>
        /// how many seconds have elapsed in the game
        /// </summary>
        int iSeconds;
        /// <summary>
        /// for the timers
        /// </summary>
        DispatcherTimer MyTimer;

        /// <summary>
        /// begins the game, sets the timer and displays the question.
        /// Hides the begin game button as well
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdBeginGame_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //start the timer
                MyTimer.Start();
                //set iSeconds to 0
                iSeconds = 0;
                //hide the begin game button
                cmdBeginGame.Visibility = Visibility.Hidden;

                //show the submit button
                cmdSubmitAnswer.Visibility = Visibility.Visible;

                //show the text box
                txtUserGuess.Visibility = Visibility.Visible;
                //change header
                lblGameHeader.Content = "The force is strong with this one";

                //check if it should be a while or a for loop
                iCurrentGameQuestion = 1;
                MathGameQuestion question = clsGame.GenerateQuestion();
                //display the questions
                if (clsGame.GetSetGameType == clsGame.GameType.Add)
                {
                    lblQuestion.Content = $"{question.getLeft} + {question.getRight} = ?";
                }
                else if (clsGame.GetSetGameType == clsGame.GameType.Subtract)
                {
                    lblQuestion.Content = $"{question.getLeft} - {question.getRight} = ?";
                }
                else if (clsGame.GetSetGameType == clsGame.GameType.Mult)
                {
                    lblQuestion.Content = $"{question.getLeft} * {question.getRight} = ?";
                }
                else if (clsGame.GetSetGameType == clsGame.GameType.Divide)
                {
                    lblQuestion.Content = $"{question.getLeft} / {question.getRight} = ?";
                }
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// updates the timer and displays it for the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                iSeconds++;
                lblMyTimer.Content = $"{iSeconds}";
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// keeps track of the total correct
        /// </summary>
        int iNumberCorrect = 0;

        /// <summary>
        /// validates the users guess and updates
        /// the iNumberCorrect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSubmitAnswer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //to store the guess to validate
                int guess;

                //get the question for the answer
                MathGameQuestion question = new MathGameQuestion();

                //make sure it's a number
                if (Int32.TryParse(txtUserGuess.Text, out guess))
                {
                    bool isCorrect = clsGame.ValidateUserGuess(guess, question.getAnswer);
                    if (isCorrect)
                    {
                        lblRightWrong.Content = "Correct!";
                        iNumberCorrect++;
                    }
                    else
                    {
                        lblRightWrong.Content = "Incorrect";
                    }
                    //check if it's the last question
                    if (iCurrentGameQuestion == 10)
                    {
                        //call EndGameContent()
                        EndGameContent();
                        //update final window labels
                        UpdateFinalWindow();
                        this.Hide();
                        wndCopyHighScores.ShowDialog();
                    }
                    else
                    {
                        //clear the text box after each guess
                        txtUserGuess.Text = "";
                        //increment the current game question
                        iCurrentGameQuestion++;
                        //generate a new question
                        question = clsGame.GenerateQuestion();

                        //display the questions
                        if (clsGame.GetSetGameType == clsGame.GameType.Add)//add
                        {
                            lblQuestion.Content = $"{question.getLeft} + {question.getRight} = ?";
                        }
                        else if (clsGame.GetSetGameType == clsGame.GameType.Subtract)//subtract
                        {
                            lblQuestion.Content = $"{question.getLeft} - {question.getRight} = ?";
                        }
                        else if (clsGame.GetSetGameType == clsGame.GameType.Mult)//multiplication
                        {
                            lblQuestion.Content = $"{question.getLeft} * {question.getRight} = ?";
                        }
                        else if (clsGame.GetSetGameType == clsGame.GameType.Divide)//division
                        {
                            lblQuestion.Content = $"{question.getLeft} / {question.getRight} = ?";
                        }
                    }
                }
                else//if it's not a number, don't allow the entry to move on
                {
                    lblRightWrong.Content = "Invalid, enter a number";
                    return;
                }
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

        }

        /// <summary>
        /// calls cmdSubmitAnswer_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUserGuess_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                if (e.Key == System.Windows.Input.Key.Enter)
                {
                    cmdSubmitAnswer_Click(sender, e);
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// clears all of the info in the game window
        /// </summary>
        private void EndGameContent()
        {
            try
            {
                //stop the timer
                MyTimer.Stop();
                //hide the text box
                txtUserGuess.Visibility = Visibility.Hidden;
                //hide the submit button
                cmdSubmitAnswer.Visibility = Visibility.Hidden;
                //hide the lblRightWrong
                lblRightWrong.Content = "";
                //Clear the question label
                lblQuestion.Content = "";
                //clear the myTimer
                lblMyTimer.Content = "";
                //clear the textbox
                txtUserGuess.Text = "";
                //set the game seconds and number correct
                clsUser.GameSeconds = iSeconds;
                clsUser.INumberCorrect = iNumberCorrect;

                //clear iSeconds and iNumberCorrect
                iSeconds = 0;
                iNumberCorrect = 0;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// updates all of the labels in the final score window
        /// </summary>
        private void UpdateFinalWindow()
        {
            try
            {
                //get the numwrong
                int numWrong = 10 - clsUser.INumberCorrect;
                //update all of the labels
                wndCopyHighScores.lblFinalName.Content = "Name: " + clsUser.Name;
                wndCopyHighScores.lblFinalAge.Content = "Age: " + clsUser.Age.ToString();
                wndCopyHighScores.lblFinalCorrect.Content = "Number of correct answers: " + clsUser.INumberCorrect.ToString();
                wndCopyHighScores.lblFinalWrong.Content = "Number of incorrect answers: " + numWrong.ToString();
                wndCopyHighScores.lblFinalTime.Content = "Seconds taken to complete: " + clsUser.GameSeconds;

                if (clsUser.INumberCorrect >= 9)
                {
                    wndCopyHighScores.lblRanking.Content = "You are on the Council and ranked a Master!";
                    wndCopyHighScores.lblRanking.Foreground = Brushes.LightGreen;
                }
                else if (clsUser.INumberCorrect < 9 && clsUser.INumberCorrect > 4)
                {
                    wndCopyHighScores.lblRanking.Content = "You are on the Council but not ranked a Master.";
                    wndCopyHighScores.lblRanking.Foreground = Brushes.Yellow;
                }
                else if (clsUser.INumberCorrect < 5)
                {
                    wndCopyHighScores.lblRanking.Content = "You are not on the council or ranked a Master...";
                    wndCopyHighScores.lblRanking.Foreground = Brushes.Red;
                }
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }


        /// <summary>
        /// Handle the error.
        /// </summary>
        /// <param name="sClass">The class in which the error occurred in.</param>
        /// <param name="sMethod">The method in which the error occurred in.</param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                //Would write to a file or database here.
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine +
                                             "HandleError Exception: " + ex.Message);
            }
        }
    }
}
