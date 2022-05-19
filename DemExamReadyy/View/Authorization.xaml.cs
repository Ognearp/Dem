using DemExamReadyy.Model;
using DemExamReadyy.OtherClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DemExamReadyy.View
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window, INotifyPropertyChanged
    {

        private string login;
        private string password;
        private string captcha;
        private string correctCapthca;
        public Authorization()
        {
            GenerateCaptha();
            InitializeComponent();
            DataContext = this;
        }

        public string Password { get => password; set { password = value; OnPropertyChanged(); } }
        public string Login { get => login; set { login = value; OnPropertyChanged(); } }

        public string Captcha { get => captcha; set { captcha = value; OnPropertyChanged(); } }

        public string CorrectCapthca { get => correctCapthca; set { correctCapthca = value; OnPropertyChanged(); } }
        #region Metod
        public void Authorizationn()
        {
            using (var bd = new Model1())
            {
                if(Captcha == CorrectCapthca)
                {
                    if (bd.BaseEmployes.Any(p => p.login == Login && p.password == Password))
                    {
                        UserService.Instance.baseEmployes = bd.BaseEmployes.FirstOrDefault(p => p.login == Login && p.password == Password);
                        if (UserService.Instance.baseEmployes.id_role == 1)
                        {
                            xueta xueva = new xueta();
                            xueva.Show();
                            this.Close();
                        }
                        if (UserService.Instance.baseEmployes.id_role == 2)
                        {
                            xueta2 xueva = new xueta2();
                            xueva.Show();
                            this.Close();
                        }
                    }
                }
              
            }
        }

        public void GenerateCaptha()
        {
            Captcha = TestClass.Generate(8);
        }
        #endregion
        #region Property

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Authorizationn();
        }
    }
}
