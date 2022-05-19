using DemExamReadyy.Model;
using DemExamReadyy.OtherClass;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для xueta.xaml
    /// </summary>
    public partial class xueta : Window , INotifyPropertyChanged
    {

        #region Fields

        private ObservableCollection<Products> productlist;
        private ObservableCollection<Products> filterlist;
        private int currentpage;
        private bool orderbydesign;
        private int itemonpage=10;
        private string selecttype;
        private string search;
        private Products selectProduct;
        private SortItem selectsort;

        private int count;
        private int count1;
        #endregion






        #region Big

        public ObservableCollection<Products> Productlist { get => productlist; set { productlist = value; OnPropertyChanged(); } }
        public ObservableCollection<Products> Filterlist { get => filterlist; set { filterlist = value; OnPropertyChanged();  } }
        public int Currentpage { get => currentpage; set { currentpage = value; OnPropertyChanged(); Filterat(Search, Selecttype, Selectsort.Property, Orderbydesign); } }
        public bool Orderbydesign { get => orderbydesign; set { orderbydesign = value; OnPropertyChanged(); Filterat(Search, Selecttype, Selectsort.Property, Orderbydesign); } }
        public int Itemonpage { get => itemonpage; set { itemonpage = value; OnPropertyChanged();  } }
        public string Selecttype { get => selecttype; set { selecttype = value; OnPropertyChanged(); Filterat(Search, Selecttype, Selectsort.Property, Orderbydesign); } }
        public Products SelectProduct { get => selectProduct; set { selectProduct = value; OnPropertyChanged(); } }

        public string Search { get => search; set { search = value; OnPropertyChanged(); Filterat(Search, Selecttype, Selectsort.Property, Orderbydesign); } }

        public SortItem Selectsort { get => selectsort; set { selectsort = value; OnPropertyChanged(); Filterat(Search, Selecttype, Selectsort.Property, Orderbydesign); } }

        public List<string> Filter { get; set; }

        public List<SortItem> Sort { get; set; }

        public int MaxPage { get => Convert.ToInt32(Math.Ceiling((float)Productlist.Where(p => p.name_product.Contains(search))
            .Where(p => Selecttype == "Все типы" ? p.type_product.Contains("") : p.type_product.Equals(Selecttype)).Count() / (float)itemonpage));
        }
    

        public string PageDisplay { get => $"{currentpage + 1}/{MaxPage}"; }

        public string Countik { get => $"{Count1} из {Count}"; }

        public int Count { get => count; set { count = value; OnPropertyChanged(); } }

        public int Count1 { get => count1; set { count1 = value; OnPropertyChanged(); } }
        #endregion
        public xueta()
        {
            LoadProduct();
            LoadSort();
            FilterLoad();
            InitializeFields();
            InitializeComponent();
            DataContext = this;
        }

        #region Metod

        public void InitializeFields()
        {
            search = string.Empty;
            selectsort = Sort[0];
            selecttype = Filter[0];
            Currentpage = 0;
        }


        public void LoadProduct()
        {
            using(var bd = new Model1())
            {
                Productlist = new ObservableCollection<Products>(bd.Products.ToList());
                Count = bd.Products.Count();
            }

            
        }

        public void LoadSort()
        {
            Sort = new List<SortItem>
            {
                new SortItem("name_product", "Название"),
                new SortItem("cost","Цена"),
            };
        }
        public void FilterLoad()
        {
            Filter = new List<string>

            {
                "Все типы",
                "Печенье",
                "Вафли",
            };
         
            
        }

        public void Filterat(string search, string filter,string orderby="name_product", bool OrderByDesign = false)
        {
            if (OrderByDesign)
            {
                Filterlist = new ObservableCollection<Products>(Productlist.OrderByDescending(p => p.GetProperty(orderby))
                    .Where(p => p.name_product.Contains(search))
                    .Where(p => filter == "Все типы" ? p.type_product.Contains("") : p.type_product.Equals(filter)));
                    
            }
            else
            {
                Filterlist = new ObservableCollection<Products>(Productlist.OrderBy(p => p.GetProperty(orderby))
                .Where(p => p.name_product.Contains(search))
                .Where(p => filter == "Все типы" ? p.type_product.Contains("") : p.type_product.Equals(filter)));
                   

                Count1 = Filterlist.Count();                  
                               

                 
            }
            OnPropertyChanged(nameof(PageDisplay));
            OnPropertyChanged(nameof(Countik));
            
           
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
            if (Currentpage+1 < MaxPage)
            {
                Currentpage++;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Currentpage > 0)
            {
                Currentpage--;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AddProduct add = new AddProduct();
            add.ShowDialog();
            if (add.DialogResult == true)
            {
                LoadProduct();
                Filterat(Search, Selecttype, Selectsort.Property, Orderbydesign);
            }
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EdditProduct eddit = new EdditProduct(SelectProduct);
            eddit.ShowDialog();
            if (eddit.DialogResult == true)
            {
                using (var bd = new Model1())
                {
                    var product = bd.Products.Find(eddit.Currentproduct.Id_product);
                    product.name_product = eddit.Name1;
                    product.type_product = eddit.Selecttype;
                    product.cost = eddit.Cost;
                    product.unit_of = eddit.Unit;
                    product.photo = eddit.Photo;
                    product.description = eddit.Dis;

                    bd.Entry(product).State = System.Data.Entity.EntityState.Modified;
                    bd.SaveChanges();

                    LoadProduct();
                    Filterat(Search, Selecttype, Selectsort.Property, Orderbydesign);

                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            using(var bd = new Model1())
            {
                var product = bd.Products.Find(SelectProduct.Id_product);
                if (product != null)
                {
                    bd.Products.Remove(product);
                    bd.SaveChanges();
                    LoadProduct();
                }
            }
        }
    }
}
