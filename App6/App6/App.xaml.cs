using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App6.Model;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App6
{
    public partial class App : Application
    {
        public static User user = new User();

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage())
            {
               BarBackgroundColor = Color.FromHex("D4000F"),
               BarTextColor = Color.White
            };
        }

        protected override void OnStart()
        {
            user.id_org_einrichtung = 0;
            user.id_org_wohnbereich = 0;
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
