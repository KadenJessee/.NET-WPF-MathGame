using System;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;

namespace WPF_Math_Game_Outline
{
    /// <summary>
    /// Interaction logic for wndEnterUserData.xaml
    /// </summary>
    public partial class wndEnterUserData : Window
    {
        /// <summary>
        /// clsUser object for passing data around
        /// </summary>
        clsUser clsUser;

        /// <summary>
        /// clsGame object for passing data around
        /// </summary>
        clsGame clsGame;

        /// <summary>
        /// using for the error label to display for a few seconds
        /// </summary>
        DispatcherTimer timer;

        /// <summary>
        /// to take from the text box input
        /// </summary>
        int age;

        /// <summary>
        /// to take from the text box input
        /// </summary>
        string name;

        /// <summary>
        /// wndMathmenu object
        /// </summary>
        wndMathMenu wndMathMenu;
        public wndEnterUserData()
        {
            InitializeComponent();

            //initialize the objects
            clsUser = new clsUser();
            clsGame = new clsGame();
            //initialize the timer object
            timer = new DispatcherTimer();
            //make the timer go off for a few seconds
            timer.Interval = TimeSpan.FromSeconds(3);
            //which method will handle the click event
            timer.Tick += new EventHandler(Timer_Tick);
        }

        /// <summary>
        /// When user clicks, it validates the input and sets
        /// the needed information for the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCloseUserDataForm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //if empty
                if (string.IsNullOrEmpty(txtBoxUserName.Text) || string.IsNullOrEmpty(txtBoxAge.Text))
                {
                    lblDataError.Content = "Enter a name";
                    lblDataError.Visibility = Visibility.Visible;
                    timer.Start();
                    return;
                }
                //checks between ages 3-10
                else if (!Int32.TryParse(txtBoxAge.Text, out age) || (age < 3) || (age > 10))
                {
                    lblDataError.Content = "Age needs to be between 3-10";
                    lblDataError.Visibility = Visibility.Visible;
                    timer.Start();
                    return;
                }
                //checks if a radio button is pushed
                else if (btnAddition.IsChecked == false && btnSubtraction.IsChecked == false && btnMult.IsChecked == false
                          && btnDivision.IsChecked == false)
                {
                    lblDataError.Content = "Enter a game type";
                    lblDataError.Visibility = Visibility.Visible;
                    timer.Start();
                    return;
                }
                else
                {
                    //set the name
                    clsUser.Name = txtBoxUserName.Text;

                    //set the age
                    clsUser.Age = age;

                    //set the game type
                    if (btnAddition.IsChecked == true)//addition
                    {
                        clsGame.GetSetGameType = clsGame.GameType.Add;
                        btnAddition.IsChecked = false;
                    }
                    else if (btnSubtraction.IsChecked == true)//subtraction
                    {
                        clsGame.GetSetGameType = clsGame.GameType.Subtract;
                        btnSubtraction.IsChecked = false;
                    }
                    else if (btnDivision.IsChecked == true)//division
                    {
                        clsGame.GetSetGameType = clsGame.GameType.Divide;
                        btnDivision.IsChecked = false;
                    }
                    else//multiplication
                    {
                        clsGame.GetSetGameType = clsGame.GameType.Mult;
                        btnMult.IsChecked = false;
                    }
                    //clear the text/radio buttons
                    txtBoxUserName.Text = "";
                    txtBoxAge.Text = "";

                    //Hide user data form
                    this.Hide();
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
        /// handles closing the window
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
        /// goes off when the timer ticks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                lblDataError.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
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
