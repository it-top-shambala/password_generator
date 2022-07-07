using System;
using System.Windows;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace PSW_Generation
{
    public partial class MainWindow : Window
    {

        private string letters = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";
        private string specialchar = @"!@#№$;%:&?*/|\,.";
        private string number = "0123456789";
        private int _SizeLetters = 0;
        private int _SizeNumbers = 0;
        private int _SizeSpecialChars = 0;
        private int _SizePasswords = 0;
        public ObservableCollection<string> passwords = new ObservableCollection<string>();

        public MainWindow()
        {
            InitializeComponent();
            ListPassword.ItemsSource = passwords;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _SizeLetters = Convert.ToInt32(Letters.Text);
            _SizeSpecialChars = Convert.ToInt32(SpecialChar.Text);
            _SizeNumbers = Convert.ToInt32(Number.Text);
            _SizePasswords = Convert.ToInt32(SizePassword.Text);
            Task<string>[]? tasks = null;
            if (CheckInputInfo())
            {
                InitTask(ref tasks, _SizePasswords);
                foreach (var task in tasks)
                {
                    task.Start();
                }
                foreach (var task in tasks)
                {
                    passwords.Add(task.Result);
                }
            }
            else
            {
                MessageBox.Show("Проверьте правильность написания данных!");
            }
        }

        private string GenerationPsw()
        {
            var PSW = string.Empty;
            var All = GenerationChars(letters, _SizeLetters) +
            GenerationChars(specialchar, _SizeSpecialChars) +
            GenerationChars(number, _SizeNumbers);
            var Length = All.Length;
            for (int i = 0; i < Length; i++)
            {
                Random rnd = new Random();
                var index = rnd.Next(0, Length - i);
                PSW += All[index];
                All = All.Remove(index, 1);
            }
            return PSW;
        }

        private bool CheckInputInfo()
        {
            try
            {
                if (_SizeLetters <= 0 ||
                    _SizeSpecialChars <= 0 ||
                    _SizeNumbers <= 0 ||
                    _SizePasswords <= 0)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private string GenerationChars(string String, int Length)
        {
            string StringChars = string.Empty;
            for (int i = 0; i < Length; i++)
            {
                Random rnd = new Random();
                StringChars += String[Convert.ToInt16(rnd.Next(0, String.Length - 1))];
            }
            return StringChars;
        }

        private void InitTask(ref Task<string>[]? tasks, int Length)
        {
            tasks = new Task<string>[Length];
            for (int i = 0; i < _SizePasswords; i++)
            {
                tasks[i] = new Task<string>(() =>
                {
                    return GenerationPsw();
                });
            }
        }
    }
}