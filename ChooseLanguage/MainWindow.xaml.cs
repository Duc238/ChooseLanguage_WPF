using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace ChooseLanguage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private List<string> listLanguage;
        public List<string> ListLanguage
        {
            get { return listLanguage; }
            set
            {
                listLanguage = value;
                OnPropertyChanged(nameof(ListLanguage));
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            ListLanguage = new List<string>() { "Tiếng Việt", "English" };
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combo = sender as ComboBox;
            if (combo.SelectedItem == null)
                return;
            bool isEN = !combo.SelectedItem.ToString().Equals("English") ? false : true;
            LanguageManager.SetLanguageDictionary(isEN ? ELanguage.English : ELanguage.VietNamese);
            this.InitializeComponent();

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string newName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(newName));
            }
        }

        private void CoboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combo = sender as ComboBox;
            if (combo.SelectedItem == null)
                return;
            bool isEN = !combo.SelectedItem.ToString().Equals("English") ? false : true;
            LanguageManager.SetLanguageDictionary(isEN ? ELanguage.English : ELanguage.VietNamese);
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }
    }

    //public static class LanguageManager
    //{
    //    public static void SetLanguageDictionary(ELanguage lang)
    //    {
    //        ResourceDictionary dict = new ResourceDictionary();
    //        switch (lang)
    //        {
    //            case ELanguage.English:
    //                dict.Source = new Uri("..\\Resource\\ResourceString.en-US.xaml",
    //                         UriKind.Relative);

    //                break;
    //            case ELanguage.VietNamese:
    //                dict.Source = new Uri("..\\Resource\\ResourceString.vi-VN.xaml",
    //                               UriKind.Relative);
    //                break;
    //            default:
    //                dict.Source = new Uri("..\\Resource\\ResourceString.en-US.xaml",
    //                          UriKind.Relative);
    //                break;
    //        }
    //        Cons.CurrentLanguage = lang;
    //        Application.Current.Resources.MergedDictionaries.Clear();
    //        Application.Current.Resources.MergedDictionaries.Add(dict);
    //    }
    //}
    //public enum ELanguage
    //{
    //    English,
    //    VietNamese
    //}

    //public static class Cons
    //{
    //    public static ELanguage CurrentLanguage = ELanguage.English;
    //}
}
