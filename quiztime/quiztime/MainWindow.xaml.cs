using MySql.Data.MySqlClient;
using MySqlConnector;
using quiztime.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAnimatedGif;
using System.IO;

namespace quiztime
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>


    public partial class MainWindow : Window
    {
        Microsoft.Win32.OpenFileDialog file = new Microsoft.Win32.OpenFileDialog();
        string destinationPath = "\\images\\default.jpg";
        int nakijken = 0;
        int counter = 0;
        int listcounter = 0;
        Class1 class1 = new Class1();
        List<string[]> vragen = new List<string[]>();
        List<string[]> question = new List<string[]>();
        string correct1 = "0";
        string correct2 = "0";
        string correct3 = "0";
        string correct4 = "0";
        public MainWindow()
        {
            InitializeComponent();
            var myquiz = class1.test();
            Window2 Window2 = new Window2();
            Window2.Show();
            myQuiz quiz = new myQuiz();
            quiztable.ItemsSource = myquiz;
        }
        private void play_Click(object sender, RoutedEventArgs e)
        {
            string quizid = (string)((System.Windows.Controls.Button)sender).Tag;
            vragen = class1.vragenData(Convert.ToInt32(quizid));


            foreach (Window window in System.Windows.Application.Current.Windows)
            {
                if (window.GetType() == typeof(Window2))
                {
                    (window as Window2).quiz.Content = vragen[0][1];
                    (window as Window2).A.Content = vragen[0][3];
                    (window as Window2).B.Content = vragen[0][5];
                    (window as Window2).C.Content = vragen[0][7];
                    (window as Window2).D.Content = vragen[0][9];

                }
            }

            if (nakijken != 0)
            {

                foreach (Window window in System.Windows.Application.Current.Windows)
                {
                    if (window.GetType() == typeof(Window2))
                    {
                        if (Int32.Parse(vragen[0][4]) == 1)
                        {
                            (window as Window2).A.Background = new SolidColorBrush(Color.FromRgb(0x80, 0xd9, 0x0b));
                        }
                        if (Int32.Parse(vragen[0][6]) == 1)
                        {
                            (window as Window2).B.Background = new SolidColorBrush(Color.FromRgb(0x80, 0xd9, 0x0b));
                        }
                        if (Int32.Parse(vragen[0][8]) == 1)
                        {
                            (window as Window2).C.Background = new SolidColorBrush(Color.FromRgb(0x80, 0xd9, 0x0b));
                        }
                        if (Int32.Parse(vragen[0][10]) == 1)
                        {
                            (window as Window2).D.Background = new SolidColorBrush(Color.FromRgb(0x80, 0xd9, 0x0b));
                        }
                    }
                }

            }
        }

        private void playQuiz(object sender, RoutedEventArgs e)
        {
            startscreen.Visibility = Visibility.Hidden;

        }

        private void makeQuiz(object sender, RoutedEventArgs e)
        {
            startscreen.Visibility = Visibility.Hidden;
            MakeQuizWindow.Visibility = Visibility.Visible;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            counter++;
            foreach (Window window in System.Windows.Application.Current.Windows)
            {
                if (window.GetType() == typeof(Window2))
                {
                    if (vragen.Count > counter)
                    {
                        (window as Window2).quiz.Content = vragen[counter][1];
                        (window as Window2).A.Content = vragen[counter][3];
                        (window as Window2).B.Content = vragen[counter][5];
                        (window as Window2).C.Content = vragen[counter][7];
                        (window as Window2).D.Content = vragen[counter][9];
                        (window as Window2).A.Background = new SolidColorBrush(Color.FromRgb(0xfc, 0xb3, 0x08));
                        (window as Window2).B.Background = new SolidColorBrush(Color.FromRgb(0xfc, 0xb3, 0x08));
                        (window as Window2).C.Background = new SolidColorBrush(Color.FromRgb(0xfc, 0xb3, 0x08));
                        (window as Window2).D.Background = new SolidColorBrush(Color.FromRgb(0xfc, 0xb3, 0x08));
                    }
                    else
                    {
                        MessageBox.Show("geen vragen meer!");
                        counter--;
                    }
                }

            }
            if (nakijken != 0)
            {

                foreach (Window window in System.Windows.Application.Current.Windows)
                {
                    if (window.GetType() == typeof(Window2))
                    {
                        if (vragen.Count > counter)
                        {
                            if (Int32.Parse(vragen[counter][4]) == 1)
                            {
                                (window as Window2).A.Background = new SolidColorBrush(Color.FromRgb(0x80, 0xd9, 0x0b));
                            }
                            if (Int32.Parse(vragen[counter][6]) == 1)
                            {
                                (window as Window2).B.Background = new SolidColorBrush(Color.FromRgb(0x80, 0xd9, 0x0b));
                            }
                            if (Int32.Parse(vragen[counter][8]) == 1)
                            {
                                (window as Window2).C.Background = new SolidColorBrush(Color.FromRgb(0x80, 0xd9, 0x0b));
                            }
                            if (Int32.Parse(vragen[counter][10]) == 1)
                            {
                                (window as Window2).D.Background = new SolidColorBrush(Color.FromRgb(0x80, 0xd9, 0x0b));
                            }
                        }
                    }

                }

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            counter--;
            foreach (Window window in System.Windows.Application.Current.Windows)
            {
                if (window.GetType() == typeof(Window2))
                {
                    if (!(counter == -1))
                    {
                        (window as Window2).quiz.Content = vragen[counter][1];
                        (window as Window2).A.Content = vragen[counter][3];
                        (window as Window2).B.Content = vragen[counter][5];
                        (window as Window2).C.Content = vragen[counter][7];
                        (window as Window2).D.Content = vragen[counter][9];
                        (window as Window2).A.Background = new SolidColorBrush(Color.FromRgb(0xfc, 0xb3, 0x08));
                        (window as Window2).B.Background = new SolidColorBrush(Color.FromRgb(0xfc, 0xb3, 0x08));
                        (window as Window2).C.Background = new SolidColorBrush(Color.FromRgb(0xfc, 0xb3, 0x08));
                        (window as Window2).D.Background = new SolidColorBrush(Color.FromRgb(0xfc, 0xb3, 0x08));
                    }
                    else
                    {
                        counter = 0;
                        MessageBox.Show("je kan niet verder terug!");
                    }
                }

            }
            if (nakijken != 0)
            {

                foreach (Window window in System.Windows.Application.Current.Windows)
                {
                    if (window.GetType() == typeof(Window2))
                    {
                        if (Int32.Parse(vragen[counter][4]) == 1)
                        {
                            (window as Window2).A.Background = new SolidColorBrush(Color.FromRgb(0x80, 0xd9, 0x0b));
                        }
                        if (Int32.Parse(vragen[counter][6]) == 1)
                        {
                            (window as Window2).B.Background = new SolidColorBrush(Color.FromRgb(0x80, 0xd9, 0x0b));
                        }
                        if (Int32.Parse(vragen[counter][8]) == 1)
                        {
                            (window as Window2).C.Background = new SolidColorBrush(Color.FromRgb(0x80, 0xd9, 0x0b));
                        }
                        if (Int32.Parse(vragen[counter][10]) == 1)
                        {
                            (window as Window2).D.Background = new SolidColorBrush(Color.FromRgb(0x80, 0xd9, 0x0b));
                        }
                    }
                }

            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            nakijken = 1;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            nakijken = 0;
        }



        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SelectAQuiz.Visibility = Visibility.Hidden;
            quizaanmaken.Visibility = Visibility.Visible;
        }
        private void ___No_Name__Checked(object sender, RoutedEventArgs e)
        {
            correct1 = "1";
        }
        private void correct2_Checked(object sender, RoutedEventArgs e)
        {
            correct2 = "1";
        }

        private void Correct3_Checked(object sender, RoutedEventArgs e)
        {
            correct3 = "1";
        }
        private void correct4_Checked(object sender, RoutedEventArgs e)
        {
            correct4 = "1";
        }
        private void incorrect1(object sender, RoutedEventArgs e)
        {
            correct1 = "0";
        }

        private void incorrect2(object sender, RoutedEventArgs e)
        {
            correct2 = "0";

        }

        private void incorrect3(object sender, RoutedEventArgs e)
        {
            correct3 = "0";

        }
        private void incorrect4(object sender, RoutedEventArgs e)
        {
            correct4 = "0";
        }



        private void next_button(object sender, RoutedEventArgs e)
        {
            string[] singlequestion = new string[10];
            singlequestion[0] = quizquestion.Text;
            singlequestion[1] = answer1.Text;
            singlequestion[2] = answer2.Text;
            singlequestion[3] = answer3.Text;
            singlequestion[4] = answer4.Text;
            singlequestion[5] = correct1;
            singlequestion[6] = correct2;
            singlequestion[7] = correct3;
            singlequestion[8] = correct4;
            singlequestion[9] = destinationPath;
            
            if (question.ElementAtOrDefault(listcounter) == null)
            {
                // Deze vraag bestaat niet
                question.Add(singlequestion);
            } 
            else
            {
                // Deze vraag bestaat
                question[listcounter] = singlequestion;
            }

            listcounter++;

            if (question.ElementAtOrDefault(listcounter) == null)
            {
                // Volgende vraag bestaat niet
                quizquestion.Text = "";
                answer1.Text = "";
                answer2.Text = "";
                answer3.Text = "";
                answer4.Text = "";
                Correct1.IsChecked = false;
                Correct2.IsChecked = false;
                Correct3.IsChecked = false;
                Correct4.IsChecked = false;
                destinationPath = "\\images\\default.jpg";
            } 
            else
            {
                // Volgende vraag bestaat
                quizquestion.Text = question[listcounter][0];
                answer1.Text = question[listcounter][1];
                answer2.Text = question[listcounter][2];
                answer3.Text = question[listcounter][3];
                answer4.Text = question[listcounter][4];

                destinationPath = question[listcounter][9];
                if (question[listcounter][5] == "0")
                {
                    Correct1.IsChecked = false;
                }
                else
                {
                    Correct1.IsChecked = true;
                }
                if (question[listcounter][6] == "0")
                {
                    Correct2.IsChecked = false;
                }
                else
                {
                    Correct2.IsChecked = true;
                }
                if (question[listcounter][7] == "0")
                {
                    Correct3.IsChecked = false;
                }
                else
                {
                    Correct3.IsChecked = true;
                }
                if (question[listcounter][8] == "0")
                {
                    Correct4.IsChecked = false;
                }
                else
                {
                    Correct4.IsChecked = true;
                }
            }



      


     
           
        }

        private void selectimage(object sender, RoutedEventArgs e)
        {
            file.Filter = "Image files|*.bmp;*.jpg;*.png;*.gif";
            file.FilterIndex = 1;
            if (file.ShowDialog() == true)
            {
                destinationPath = System.IO.Path.Combine(@"C:\Users\thijs\source\repos\quiztime\quiztime\images", System.IO.Path.GetFileName(file.FileName));
                Console.WriteLine(file.FileName);
                if (!File.Exists(destinationPath))
                {

                    File.Copy(file.FileName, System.IO.Path.Combine(@"C:\Users\thijs\source\repos\quiztime\quiztime\images", System.IO.Path.GetFileName(file.FileName)), true);
                }
                var image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(destinationPath, UriKind.RelativeOrAbsolute);
                image.EndInit();
                ImageBehavior.SetAnimatedSource(imagePicture, image);
            }
        }

        private void savequiz_Click(object sender, RoutedEventArgs e)
        {

            string[] singlequestion = new string[10];
            singlequestion[0] = quizquestion.Text;
            singlequestion[1] = answer1.Text;
            singlequestion[2] = answer2.Text;
            singlequestion[3] = answer3.Text;
            singlequestion[4] = answer4.Text;
            singlequestion[5] = correct1;
            singlequestion[6] = correct2;
            singlequestion[7] = correct3;
            singlequestion[8] = correct4;
            singlequestion[9] = destinationPath;
            
            if (listcounter == question.Count)
            {
                question.Add(singlequestion);
            }
            else
            {
                question[listcounter] = singlequestion; 
            }

        }

        private void buttonback(object sender, RoutedEventArgs e)
        {
            
            if (listcounter == 0)
            {
                MessageBox.Show("U kunt niet verder terug");
            }
            else
            {
                string[] singlequestion = new string[10];
                singlequestion[0] = quizquestion.Text;
                singlequestion[1] = answer1.Text;
                singlequestion[2] = answer2.Text;
                singlequestion[3] = answer3.Text;
                singlequestion[4] = answer4.Text;
                singlequestion[5] = correct1;
                singlequestion[6] = correct2;
                singlequestion[7] = correct3;
                singlequestion[8] = correct4;
                singlequestion[9] = destinationPath;
                question.Add(singlequestion);
                quizquestion.Text = "";
                answer1.Text = "";
                answer2.Text = "";
                answer3.Text = "";
                answer4.Text = "";
                Correct1.IsChecked = false;
                Correct2.IsChecked = false;
                Correct3.IsChecked = false;
                Correct4.IsChecked = false;
                destinationPath = "\\images\\default.jpg";
                listcounter--;
                quizquestion.Text = question[listcounter][0];
                answer1.Text = question[listcounter][1];
                answer2.Text = question[listcounter][2];
                answer3.Text = question[listcounter][3];
                answer4.Text = question[listcounter][4];
                if (question[listcounter][5] == "0")
                {
                    Correct1.IsChecked = false;
                }
                else
                {
                    Correct1.IsChecked = true;
                }
                if (question[listcounter][6] == "0")
                {
                    Correct2.IsChecked = false;
                }
                else
                {
                    Correct2.IsChecked = true;
                }
                if (question[listcounter][7] == "0")
                {
                    Correct3.IsChecked = false;
                }
                else
                {
                    Correct3.IsChecked = true;
                }
                if (question[listcounter][8] == "0")
                {
                    Correct4.IsChecked = false;
                }
                else
                {
                    Correct4.IsChecked = true;
                }
                destinationPath = question[listcounter][9];
                
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            quizaanmaken.Visibility = Visibility.Hidden;
            vragenaanmaken.Visibility = Visibility.Visible;
        }

        private void backtostart(object sender, RoutedEventArgs e)
        {
            vragenaanmaken.Visibility = Visibility.Hidden;
            SelectAQuiz.Visibility = Visibility.Visible;
        }
    }
}
