using DemExamReadyy.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window , INotifyPropertyChanged
    {

        private string name;
        private double cost;
        private string dis;
        private string unit;
        private byte[] photo;
        private string selecttype;

        public string Name1 { get => name; set { name = value; OnPropertyChanged(); } }
        public double Cost { get => cost; set { cost = value; OnPropertyChanged(); } }
        public string Dis { get => dis; set { dis = value; OnPropertyChanged(); } }
        public string Unit { get => unit; set { unit = value; OnPropertyChanged(); } }
        public byte[] Photo { get => photo; set { photo = value; OnPropertyChanged(); } }
        public string Selecttype { get => selecttype; set { selecttype = value; OnPropertyChanged(); } }

        public List<string> Sort { get; set; }

        public Products NewProduct { get; set; }

        public AddProduct()
        {
            Initiale();
            InitializeComponent();
            DataContext = this;
        }

        public void Initiale()
        {

            NewProduct = new Products();
            Name1 = string.Empty;
            Cost = 0;
            Dis = string.Empty;
            Unit = string.Empty;
            Sort = new List<string>
            {
                "Печенье",
                "Вафли",
            };
            Selecttype = string.Empty;
            Photo = null;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Изображение | *.JPG; *.PNG; *.JPEG";
            if (openFileDialog.ShowDialog() == true)
            {
                Photo = File.ReadAllBytes(openFileDialog.FileName);
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NewProduct.name_product  = Name1;
            NewProduct.type_product = Selecttype;
            NewProduct.cost = Cost;
            NewProduct.description = Dis;
            NewProduct.unit_of = Unit;
            NewProduct.photo = Photo;
            using(var bd = new Model1())
            {

                bd.Products.Add(NewProduct);
                bd.SaveChanges();
                DialogResult = true;
            }
        }
    }
}
