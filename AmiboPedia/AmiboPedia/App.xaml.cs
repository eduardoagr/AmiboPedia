using AmiboPedia.View;

using Syncfusion.Licensing;

using Xamarin.Forms;

namespace AmiboPedia {
    public partial class App : Application {

        public App() {

            //Register Syncfusion license
            SyncfusionLicenseProvider.RegisterLicense("NDAxNTQzQDMxMzgyZTM0MmUzMGtUM2VIMGhtbGIzK3d5bE5CYlB5Y3p6dVZndFhPNm5OL1lJNzMwSlVrQXc9");

            InitializeComponent();

            MainPage = new NavigationPage(new AmiboCollectionPage());
        }

        protected override void OnStart() {
        }

        protected override void OnSleep() {
        }

        protected override void OnResume() {
        }
    }
}
