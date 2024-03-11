using System.Windows;
using System.Reflection;
using System;

namespace WPF_Math_Game_Outline
{
    /// <summary>
    /// Interaction logic for wndMathMenu.xaml
    /// </summary>
    public partial class wndMathMenu : Window
    {
        /// <summary>
        /// Class that holds the high scores.
        /// </summary>
        wndHighScores wndHighScoresForm;

        /// <summary>
        /// Class that holds the user data.
        /// </summary>
        wndEnterUserData wndEnterUserDataForm;

        /// <summary>
        /// Class where the game is played.
        /// </summary>
        wndGame wndGameForm;

        /// <summary>
        /// initializes the main menu
        /// </summary>
        public wndMathMenu()
        {
            InitializeComponent();

            //MAKE SURE TO INCLUDE THIS LINE OR THE APPLICATION WILL NOT CLOSE
            //BECAUSE THE WINDOWS ARE STILL IN MEMORY
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;///////////////////////////////////////////////////////////

            wndHighScoresForm = new wndHighScores();
            wndEnterUserDataForm = new wndEnterUserData();
            wndGameForm = new wndGame();

            //Pass the high scores form to the game form.
            //This way the high scores form may be displayed via the game form.
            wndGameForm.CopyHighScores = wndHighScoresForm;
        }
        
        /// <summary>
        /// when clicked, shows the game page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdPlayGame_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Hide the menu
                this.Hide();
                //show the begin game button
                wndGameForm.cmdBeginGame.Visibility = Visibility.Visible;
                //set header for the gameForm
                wndGameForm.lblGameHeader.Content = "Are you ready to become a math Jedi?";

                //hide the user text
                wndGameForm.txtUserGuess.Visibility = Visibility.Hidden;
                //Show the game form
                wndGameForm.ShowDialog();
                //Show the main form
                cmdPlayGame.IsEnabled = false;
                this.Show();
            }
            catch(Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// opens the window for the user to enter the needed
        /// information for the game and sets the Play Game button
        /// to enabled once they have valid information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdEnterUserData_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Hide the menu
                this.Hide();
                //Show the user data form
                wndEnterUserDataForm.ShowDialog();

                //Show the main form
                this.Show();

                //enable the play game after data is valid
                cmdPlayGame.IsEnabled = true;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
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
