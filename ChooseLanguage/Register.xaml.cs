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
    public partial class Register : Window, INotifyPropertyChanged
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
        public Register()
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
    }

    
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
