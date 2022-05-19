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
    /// Логика взаимодействия для EdditProduct.xaml
    /// </summary>
    public partial class EdditProduct : Window, INotifyPropertyChanged
    {
        private string name;
        private double? cost;
        private string dis;
        private string unit;
        private byte[] photo;
        private string selecttype;

        public string Name1 { get => name; set { name = value; OnPropertyChanged(); } }
        public double? Cost { get => cost; set { cost = value; OnPropertyChanged(); } }
        public string Dis { get => dis; set { dis = value; OnPropertyChanged(); } }
        public string Unit { get => unit; set { unit = value; OnPropertyChanged(); } }
        public byte[] Photo { get => photo; set { photo = value; OnPropertyChanged(); } }
        public string Selecttype { get => selecttype; set { selecttype = value; OnPropertyChanged(); } }

        public Products Currentproduct { get; set; }
        public List<string> Sort { get; set; }


        public EdditProduct(Products products)
        {
            Initiailize(products);
            InitializeComponent();
            DataContext = this;
        }


        public void Initiailize(Products products)
        {
            Currentproduct = products;
            Name1 = Currentproduct.name_product;
            Cost = Currentproduct.cost;
            Dis = Currentproduct.description;
            Unit = Currentproduct.unit_of;
           
            Photo = Currentproduct.photo;
            Sort = new List<string>
            {
                "Печенье",
                "Вафли",
            };
            Selecttype = Sort.FirstOrDefault(p => p.Equals(Currentproduct.type_product));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Изображение | *.PNG; *.JPG; *.JPEG;";
            if (openFileDialog.ShowDialog() == true)
            {
                Photo = File.ReadAllBytes(openFileDialog.FileName);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Currentproduct.name_product = Name1;
            Currentproduct.cost = Cost;
            Currentproduct.description = Dis;
            Currentproduct.unit_of = Unit;
            Currentproduct.photo = Photo;

            DialogResult = true;
        }
    }
}
