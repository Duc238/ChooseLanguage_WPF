using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChooseLanguage
{
    public static class LanguageManager
    {
        public static void SetLanguageDictionary(ELanguage lang)
        {
            ResourceDictionary dict = new ResourceDictionary();
            switch (lang)
            {
                case ELanguage.English:
                    dict.Source = new Uri("..\\Resource\\ResourceString.en-US.xaml",
                             UriKind.Relative);

                    break;
                case ELanguage.VietNamese:
                    dict.Source = new Uri("..\\Resource\\ResourceString.vi-VN.xaml",
                                   UriKind.Relative);
                    break;
                default:
                    dict.Source = new Uri("..\\Resource\\ResourceString.en-US.xaml",
                              UriKind.Relative);
                    break;
            }
            Cons.CurrentLanguage = lang;
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(dict);
        }
    }
}
