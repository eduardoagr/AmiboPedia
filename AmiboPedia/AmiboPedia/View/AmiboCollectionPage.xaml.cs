
using AmiboPedia.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AmiboPedia.View {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AmiboCollectionPage : ContentPage {

        public AmiboCollectionPageVM AmiboCollectionPageVM { get; set; }
        public AmiboCollectionPage() {
            InitializeComponent();
        }

        protected override async void OnAppearing() {
            base.OnAppearing();

            AmiboCollectionPageVM = new AmiboCollectionPageVM();
            await AmiboCollectionPageVM.LoadCharacters(
                "https://amiiboapi.com/api/character/");
            BindingContext = AmiboCollectionPageVM;
        }
    }
}