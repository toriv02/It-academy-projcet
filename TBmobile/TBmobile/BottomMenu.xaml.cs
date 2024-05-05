using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TBmobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedPage1 : TabbedPage
    {
        public TabbedPage1()
        {
            InitializeComponent();
            // Получаем навигационную панель текущей страницы
            NavigationPage navPage = Application.Current.MainPage as NavigationPage;
            // Устанавливаем цвет фона навигационной панели
            navPage.BarBackgroundColor = Color.FromHex("#FF383838");
        }
    }
}