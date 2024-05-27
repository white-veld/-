using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace ЭВМ
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public class RandomNumberGenerator
    {
        private static readonly Random random = new Random();
        public static int GenerateRandomNumber(int min, int max)
        {
            return random.Next(min, max + 1);
        }

        public static double GenerateRandomNumberInRange(double minValue, double maxValue)
        {
            if (minValue >= maxValue)
            {
                throw new ArgumentException("Минимальное значение должно быть меньше максимального.");
            }

            double randomNumber = minValue + (random.NextDouble() * (maxValue - minValue));
            return randomNumber;
        }
    }

    public partial class MainWindow : Window
    {
        bool Button2 = false;
        string RightAnswer;
        string Explanation;
    public MainWindow()
        {
            InitializeComponent();
        }

        private void AnswerButton_Click(object sender, RoutedEventArgs e)
        {
            string UserAnswer = (sender as Button).Content.ToString();
            string resultMessage = (UserAnswer == RightAnswer) ? "Правильный ответ!" : "Неправильный ответ.";
            resultMessage += $" {Explanation}";
            Question.Text = resultMessage;
            YesButton.Visibility = Visibility.Collapsed;
            NoButton.Visibility = Visibility.Collapsed;
        }


        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Button2 = true;
            ToggleButton ClickedButton = sender as ToggleButton;
            foreach (var button in new[] {CPU, Voltage12, Voltage5, Voltage3_3, BatteryOfBIOS, BIOS, PCI, RTC, USB})
            {
                if (button != ClickedButton)
                    button.IsChecked = false;
            }
            ClickedButton.IsChecked = true;
        }

        private void TestOfAmperage_Click(object sender, RoutedEventArgs e)
        {
            {
                if (Button2)
                {
                    Output.Text = "Выбрана неверная комбинация. Попробуй ещё раз!";
                    Button2 = false;
                }
            }
        }

        private void TestOfVoltage_Click(object sender, RoutedEventArgs e)
        {
            if (Voltage3_3.IsChecked == true)
            {
                int various = RandomNumberGenerator.GenerateRandomNumber(0, 1);
                double RandomVoltage;
                if (various == 0)
                {
                    double NormalVoltage = RandomNumberGenerator.GenerateRandomNumberInRange(2.97, 3.63);
                    RandomVoltage = NormalVoltage;
                    RightAnswer = "Да";
                }
                else
                {
                    if (RandomNumberGenerator.GenerateRandomNumber(0, 1) == 0)
                    {
                        double LowVoltage = RandomNumberGenerator.GenerateRandomNumberInRange(1.27, 2.45);
                        RandomVoltage = LowVoltage;
                        RightAnswer = "Нет";
                    }
                    else
                    {
                        double HighVoltage = RandomNumberGenerator.GenerateRandomNumberInRange(4.02, 5.11);
                        RandomVoltage = HighVoltage;
                        RightAnswer = "Нет";
                    }
                }
                Output.Text = "Напряжение = " + RandomVoltage;
                Question.Text = "Нормальное ли напряжение?";
                Explanation = "Допустимый диапазон напряжения = (2.97, 3.63)В";
                YesButton.Visibility = Visibility.Visible;
                NoButton.Visibility = Visibility.Visible;
            }
            else if (Voltage5.IsChecked == true)
            {
                int various = RandomNumberGenerator.GenerateRandomNumber(0, 1);
                double RandomVoltage;
                if (various == 0)
                {
                    double NormalVoltage = RandomNumberGenerator.GenerateRandomNumberInRange(4.5, 5.5);
                    RandomVoltage = NormalVoltage;
                    RightAnswer = "Да";
                }
                else
                {
                    if (RandomNumberGenerator.GenerateRandomNumber(0, 1) == 0)
                    {
                        double LowVoltage = RandomNumberGenerator.GenerateRandomNumberInRange(2.05, 3.95);
                        RandomVoltage = LowVoltage;
                        RightAnswer = "Нет";
                    }
                    else
                    {
                        double HighVoltage = RandomNumberGenerator.GenerateRandomNumberInRange(6.03, 7.15);
                        RandomVoltage = HighVoltage;
                        RightAnswer = "Нет";
                    }
                }
                Output.Text = "Напряжение = " + RandomVoltage;
                Question.Text = "Нормальное ли напряжение?";
                Explanation = "Допустимый диапазон напряжения = (4.5, 5.5)В";
                YesButton.Visibility = Visibility.Visible;
                NoButton.Visibility = Visibility.Visible;
            }
            else if (Voltage12.IsChecked == true)
            {
                int various = RandomNumberGenerator.GenerateRandomNumber(0, 1);
                double RandomVoltage;
                if (various == 0)
                {
                    double NormalVoltage = RandomNumberGenerator.GenerateRandomNumberInRange(10.8, 13.2);
                    RandomVoltage = NormalVoltage;
                    RightAnswer = "Да";
                }
                else
                {
                    if (RandomNumberGenerator.GenerateRandomNumber(0, 1) == 0)
                    {
                        double LowVoltage = RandomNumberGenerator.GenerateRandomNumberInRange(7.05, 9.95);
                        RandomVoltage = LowVoltage;
                        RightAnswer = "Нет";
                    }
                    else
                    {
                        double HighVoltage = RandomNumberGenerator.GenerateRandomNumberInRange(14.03, 17.15);
                        RandomVoltage = HighVoltage;
                        RightAnswer = "Нет";
                    }
                }
                Output.Text = "Напряжение = " + RandomVoltage;
                Question.Text = "Нормальное ли напряжение?";
                Explanation = "Допустимый диапазон напряжения = (10.8, 13.2)В";
                YesButton.Visibility = Visibility.Visible;
                NoButton.Visibility = Visibility.Visible;
            }
            else if (BatteryOfBIOS.IsChecked == true)
            {
                int various = RandomNumberGenerator.GenerateRandomNumber(0, 1);
                double RandomVoltage;
                if (various == 0)
                {
                    double NormalVoltage = RandomNumberGenerator.GenerateRandomNumberInRange(2.7, 3.3);
                    RandomVoltage = NormalVoltage;
                    RightAnswer = "Да";
                }
                else
                {
                    if (RandomNumberGenerator.GenerateRandomNumber(0, 1) == 0)
                    {
                        double LowVoltage = RandomNumberGenerator.GenerateRandomNumberInRange(2.05, 2.5);
                        RandomVoltage = LowVoltage;
                        RightAnswer = "Нет";
                    }
                    else
                    {
                        double HighVoltage = RandomNumberGenerator.GenerateRandomNumberInRange(3.9, 4.15);
                        RandomVoltage = HighVoltage;
                        RightAnswer = "Нет";
                    }
                }
                Output.Text = "Напряжение = " + RandomVoltage;
                Question.Text = "Нормальное ли напряжение?";
                Explanation = "Допустимый диапазон напряжения = (2.7, 3.3)В";
                YesButton.Visibility = Visibility.Visible;
                NoButton.Visibility = Visibility.Visible;
            }
            else if (USB.IsChecked == true)
            {
                int various = RandomNumberGenerator.GenerateRandomNumber(0, 1);
                double RandomVoltage;
                if (various == 0)
                {
                    double NormalVoltage = RandomNumberGenerator.GenerateRandomNumberInRange(4.75, 5.25);
                    RandomVoltage = NormalVoltage;
                    RightAnswer = "Да";
                }
                else
                {
                    if (RandomNumberGenerator.GenerateRandomNumber(0, 1) == 0)
                    {
                        double LowVoltage = RandomNumberGenerator.GenerateRandomNumberInRange(3.05, 4.41);
                        RandomVoltage = LowVoltage;
                        RightAnswer = "Нет";
                    }
                    else
                    {
                        double HighVoltage = RandomNumberGenerator.GenerateRandomNumberInRange(5.73, 7.15);
                        RandomVoltage = HighVoltage;
                        RightAnswer = "Нет";
                    }
                }
                Output.Text = "Напряжение = " + RandomVoltage;
                Question.Text = "Нормальное ли напряжение?";
                Explanation = "Допустимый диапазон напряжения = (4.75, 5.25)В";
                YesButton.Visibility = Visibility.Visible;
                NoButton.Visibility = Visibility.Visible;
            }
            else if (PWBN.IsChecked == true)
            {
                int various = RandomNumberGenerator.GenerateRandomNumber(0, 1);
                string facts;
                if (various == 0)
                {
                    facts = "Есть сигнал";
                    RightAnswer = "Да";
                }
                else
                {
                    facts = "Нет сигнала";
                    RightAnswer = "Нет";
                }
                Output.Text = facts;
                Question.Text = "Верно ли утверждение?";
                Explanation = "При исправном кнопки питания есть сигнал";
                YesButton.Visibility = Visibility.Visible;
                NoButton.Visibility = Visibility.Visible;
            }
            else
            {
                Output.Text = "Выбрана неверная комбинация. Попробуй ещё раз!";
            }
        }

        private void TestOfResistance_Click(object sender, RoutedEventArgs e)
        {
            if (Voltage3_3.IsChecked == true)
            {
                int various = RandomNumberGenerator.GenerateRandomNumber(0, 1);
                double RandomResistance;
                if (various == 0)
                {
                    double NormalResistance = RandomNumberGenerator.GenerateRandomNumber(100, 10000);
                    RandomResistance = NormalResistance;
                    RightAnswer = "Да";
                }
                else
                {
                    if (RandomNumberGenerator.GenerateRandomNumber(0, 1) == 0)
                    {
                        double LowResistance = RandomNumberGenerator.GenerateRandomNumberInRange(10, 80);
                        RandomResistance = LowResistance;
                        RightAnswer = "Нет";
                    }
                    else
                    {
                        double HighResistance = RandomNumberGenerator.GenerateRandomNumberInRange(15000, 150000);
                        RandomResistance = HighResistance;
                        RightAnswer = "Нет";
                    }
                }
                Output.Text = "Сопротивление= " + RandomResistance;
                Question.Text = "Нормальное ли сопротивление?";
                Explanation = "Допустимый диапазон сопротивления = (100, 10000)Ом";
                YesButton.Visibility = Visibility.Visible;
                NoButton.Visibility = Visibility.Visible;
            }
            else if (Voltage5.IsChecked == true)
            {
                int various = RandomNumberGenerator.GenerateRandomNumber(0, 1);
                double RandomResistance;
                if (various == 0)
                {
                    double NormalResistance = RandomNumberGenerator.GenerateRandomNumber(100, 10000);
                    RandomResistance = NormalResistance;
                    RightAnswer = "Да";
                }
                else
                {
                    if (RandomNumberGenerator.GenerateRandomNumber(0, 1) == 0)
                    {
                        double LowResistance = RandomNumberGenerator.GenerateRandomNumberInRange(10, 80);
                        RandomResistance = LowResistance;
                        RightAnswer = "Нет";
                    }
                    else
                    {
                        double HighResistance = RandomNumberGenerator.GenerateRandomNumberInRange(15000, 150000);
                        RandomResistance = HighResistance;
                        RightAnswer = "Нет";
                    }
                }
                Output.Text = "Сопротивление = " + RandomResistance;
                Question.Text = "Нормальное ли сопротивление?";
                Explanation = "Допустимый диапазон сопротивления = (100, 10000)Ом";
                YesButton.Visibility = Visibility.Visible;
                NoButton.Visibility = Visibility.Visible;
            }
            else if (Voltage12.IsChecked == true)
            {
                int various = RandomNumberGenerator.GenerateRandomNumber(0, 1);
                double RandomResistance;
                if (various == 0)
                {
                    double NormalResistance = RandomNumberGenerator.GenerateRandomNumber(1000, 20000);
                    RandomResistance = NormalResistance;
                    RightAnswer = "Да";
                }
                else
                {
                    if (RandomNumberGenerator.GenerateRandomNumber(0, 1) == 0)
                    {
                        double LowResistance = RandomNumberGenerator.GenerateRandomNumberInRange(10, 800);
                        RandomResistance = LowResistance;
                        RightAnswer = "Нет";
                    }
                    else
                    {
                        double HighResistance = RandomNumberGenerator.GenerateRandomNumberInRange(25000, 250000);
                        RandomResistance = HighResistance;
                        RightAnswer = "Нет";
                    }
                }
                Output.Text = "Сопротивление = " + RandomResistance;
                Question.Text = "Нормальное ли сопротивление?";
                Explanation = "Допустимый диапазон сопротивления = (1000, 20000)Ом";
                YesButton.Visibility = Visibility.Visible;
                NoButton.Visibility = Visibility.Visible;
            }
            else
            {
                Output.Text = "Выбрана неверная комбинация. Попробуй ещё раз!";
            }
        }
        private void TestOfRAM_Click(object sender, RoutedEventArgs e)
        {
            if (RAM.IsChecked == true)
            {
                int various = RandomNumberGenerator.GenerateRandomNumber(0, 2);
                string facts;
                if (various == 0)
                {
                    facts = "Все индикаторы горят красным";
                    RightAnswer = "Да";
                }
                else if (various == 1)
                {
                    facts = "Никакие индикаторы не горит красным";
                    RightAnswer = "Нет";
                }
                else
                {
                    facts = "Часть индикаторов горит красным";
                    RightAnswer = "Нет";
                }
                Output.Text = facts;
                Question.Text = "Верно ли утверждение?";
                Explanation = "При исправном ОЗУ все индикаторы горят красным";
                YesButton.Visibility = Visibility.Visible;
                NoButton.Visibility = Visibility.Visible;
            }
            else
            {
                Output.Text = "Выбрана неверная комбинация. Попробуй ещё раз!";
            }
        }
        private void TestOfCPU_Click(object sender, RoutedEventArgs e)
        {
            if (CPU.IsChecked == true)
            {
                int various = RandomNumberGenerator.GenerateRandomNumber(0, 2);
                string facts;
                if (various == 0)
                {
                    facts = "Все индикаторы горят красным";
                    RightAnswer = "Да";
                }
                else if (various == 1)
                {
                    facts = "Никакие индикаторы не горит красным";
                    RightAnswer = "Нет";
                }
                else
                {
                    facts = "Часть индикаторов горит красным";
                    RightAnswer = "Нет";
                }
                Output.Text = facts;
                Question.Text = "Верно ли утверждение?";
                Explanation = "При исправном сокете ЦПУ все индикаторы горят красным";
                YesButton.Visibility = Visibility.Visible;
                NoButton.Visibility = Visibility.Visible;
            }
            else
            {
                Output.Text = "Выбрана неверная комбинация. Попробуй ещё раз!";
            }
        }
        private void TestOfPCI_Click(object sender, RoutedEventArgs e)
        {
            if (PCI.IsChecked == true)
            {
                int various = RandomNumberGenerator.GenerateRandomNumber(0, 1);
                string facts;
                if (various == 0)
                {
                    facts = "Есть сигнал";
                    RightAnswer = "Да";
                }
                else
                {
                    facts = "Нет сигнала";
                    RightAnswer = "Нет";
                }
                Output.Text = facts;
                Question.Text = "Верно ли утверждение?";
                Explanation = "При исправном PCI есть сигнал";
                YesButton.Visibility = Visibility.Visible;
                NoButton.Visibility = Visibility.Visible;
            }
            else
            {
                Output.Text = "Выбрана неверная комбинация. Попробуй ещё раз!";
            }
        }
        private void Oscilloscop_Click(object sender, RoutedEventArgs e)
        {
            //Не работает
            //string[] images = { "/oscilloscope_not_work.jpg", "/oscilloscope_work.jpg" };
            //Random rand = new Random();
            //int various = rand.Next(images.Length);
            //string selectedImage = images[various];

            //BitmapImage bitmap = new BitmapImage(new Uri(selectedImage));
            //OscilloscopeImage.Source = bitmap;
            //OscilloscopeImage.Visibility = Visibility.Visible;

            //RightAnswer = (various == 1) ? "Да" : "Нет";
            //Explanation = "При исправном ВIOS должна быть синусоида"; ;
        }
    }
}
