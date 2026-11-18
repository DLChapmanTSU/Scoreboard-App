using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Text.Json;
using System.Windows.Media;

namespace WPF_Scoreboard
{
    public class Player
    {
        string m_name { get; set; } = "None";
        uint m_nation { get; set; } = 0;
        uint m_wins { get; set; } = 0;
        uint m_losses { get; set; } = 0;
    }

    public class FlagData 
    {
        public ImageSource m_flagImage { get; set; } = null;
        public string m_flagName { get; set; } = "None";
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string m_playerOneScore = "0";
        string m_playerTwoScore = "0";
        string m_playerOneName;
        string m_playerTwoName;
        string m_playerOneNation = "None.png";
        string m_playerTwoNation = "None.png";
        List<FlagData> m_flags = new List<FlagData>();
        public MainWindow()
        {
            InitializeComponent();

            tbxPlayerOneName.Text = "Name";
            tbxPlayerTwoName.Text = "Name";
            tbxPlayerOneScore.Text = "0";
            tbxPlayerTwoScore.Text = "0";

            string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            DirectoryInfo di = new DirectoryInfo("Images/Flags");
            foreach (FileInfo fi in di.GetFiles())
            {
                FlagData data = new FlagData();
                data.m_flagImage = new BitmapImage(new Uri(fi.FullName));
                data.m_flagName = fi.Name;
                m_flags.Add(data);
            }

            cbxPlayerOneNation.ItemsSource = m_flags;
            cbxPlayerTwoNation.ItemsSource = m_flags;
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

            if (!File.Exists("ScoreboardOutput/PlayerOneNation.png"))
            {
                Directory.CreateDirectory("ScoreboardOutput");
                File.Copy($"Images/Flags/{m_playerOneNation}", "ScoreboardOutput/PlayerOneNation.png", true);
                File.SetLastWriteTime("ScoreboardOutput/PlayerOneNation.png", DateTime.Now);
            }
            else
            {
                File.Copy($"Images/Flags/{m_playerOneNation}", "ScoreboardOutput/PlayerOneNation.png", true);
                File.SetLastWriteTime("ScoreboardOutput/PlayerOneNation.png", DateTime.Now);
            }

            if (!File.Exists("ScoreboardOutput/PlayerTwoNation.png"))
            {
                Directory.CreateDirectory("ScoreboardOutput");
                File.Copy($"Images/Flags/{m_playerTwoNation}", "ScoreboardOutput/PlayerTwoNation.png", true);
                File.SetLastWriteTime("ScoreboardOutput/PlayerTwoNation.png", DateTime.Now);
            }
            else
            {
                File.Copy($"Images/Flags/{m_playerTwoNation}", "ScoreboardOutput/PlayerTwoNation.png", true);
                File.SetLastWriteTime("ScoreboardOutput/PlayerTwoNation.png", DateTime.Now);
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

        private void cbxPlayerOneNation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            m_playerOneNation = cbxPlayerOneNation.SelectedItem as FlagData != null ? (cbxPlayerOneNation.SelectedItem as FlagData).m_flagName : "None.png";
        }

        private void cbxPlayerTwoNation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            m_playerTwoNation = cbxPlayerTwoNation.SelectedItem as FlagData != null ? (cbxPlayerTwoNation.SelectedItem as FlagData).m_flagName : "None.png";
        }
    }
}