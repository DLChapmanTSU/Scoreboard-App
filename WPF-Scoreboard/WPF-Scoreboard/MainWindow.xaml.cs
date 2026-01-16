using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WPF_Scoreboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string m_playerOneScore = "0";
        string m_playerTwoScore = "0";
        string m_playerOneName;
        string m_playerTwoName;
        List<string> m_flags = new List<string>();
        public MainWindow()
        {
            InitializeComponent();

            tbxPlayerOneName.Text = "Name";
            tbxPlayerTwoName.Text = "Name";
            tbxPlayerOneScore.Text = "0";
            tbxPlayerTwoScore.Text = "0";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) 
        {
            Uri imgUri = new Uri("/Images/Flags/zw.png", UriKind.Relative);
            imTestFlag.Source = new BitmapImage(imgUri);
        }

        private void btCommit_Click(object sender, RoutedEventArgs e)
        {
            //Write name info to text files
            if (!File.Exists("ScoreboardOutput/PlayerOneName.txt"))
            {
                Directory.CreateDirectory("ScoreboardOutput");

                using (StreamWriter sw = new StreamWriter("ScoreboardOutput/PlayerOneName.txt", true))
                {
                    sw.WriteLine(m_playerOneName);
                }
            }
            else
            {
                File.WriteAllText("ScoreboardOutput/PlayerOneName.txt", m_playerOneName);
            }

            if (!File.Exists("ScoreboardOutput/PlayerTwoName.txt"))
            {
                Directory.CreateDirectory("ScoreboardOutput");

                using (StreamWriter sw = new StreamWriter("ScoreboardOutput/PlayerTwoName.txt", true))
                {
                    sw.WriteLine(m_playerTwoName);
                }
            }
            else
            {
                File.WriteAllText("ScoreboardOutput/PlayerTwoName.txt", m_playerTwoName);
            }

            //Write score info to text files
            if (!File.Exists("ScoreboardOutput/PlayerOneScore.txt"))
            {
                Directory.CreateDirectory("ScoreboardOutput");

                using (StreamWriter sw = new StreamWriter("ScoreboardOutput/PlayerOneScore.txt", true)) 
                {
                    sw.WriteLine(m_playerOneScore);
                }
            }
            else
            {
                File.WriteAllText("ScoreboardOutput/PlayerOneScore.txt", m_playerOneScore);
            }

            if (!File.Exists("ScoreboardOutput/PlayerTwoScore.txt"))
            {
                Directory.CreateDirectory("ScoreboardOutput");

                using (StreamWriter sw = new StreamWriter("ScoreboardOutput/PlayerTwoScore.txt", true))
                {
                    sw.WriteLine(m_playerTwoScore);
                }
            }
            else 
            {
                File.WriteAllText("ScoreboardOutput/PlayerTwoScore.txt", m_playerTwoScore);
            }
        }

        private void tbxPlayerOneScore_TextChanged(object sender, TextChangedEventArgs e) 
        {
            m_playerOneScore = tbxPlayerOneScore.Text;
        }

        private void tbxPlayerTwoScore_TextChanged(object sender, TextChangedEventArgs e)
        {
            m_playerTwoScore = tbxPlayerTwoScore.Text;
        }
        private void tbxPlayerOneName_TextChanged(object sender, TextChangedEventArgs e)
        {
            m_playerOneName = tbxPlayerOneName.Text;
        }

        private void tbxPlayerTwoName_TextChanged(object sender, TextChangedEventArgs e)
        {
            m_playerTwoName = tbxPlayerTwoName.Text;
        }
    }
}