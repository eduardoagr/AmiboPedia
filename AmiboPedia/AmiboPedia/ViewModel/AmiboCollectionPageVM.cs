using AmiboPedia.Model;

using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;

namespace AmiboPedia.ViewModel {
    public class AmiboCollectionPageVM : ViewModelBase {

        public ObservableCollection<Character> Characters { get; set; }

        private ObservableCollection<Amiibo> _Amiibos;
        public ObservableCollection<Amiibo> Amiibos {
            get { return _Amiibos; }
            set {
                if (_Amiibos != value) {
                    _Amiibos = value;
                    RaisePropertyChanged();
                }
            }
        }
        public ICommand SearchCommand { get; set; }

        public AmiboCollectionPageVM() {

            SearchCommand = new Command(async (SearchTerm) => {

                var character = SearchTerm as Character;
                if (character != null) {
                    var url = $"https://www.amiiboapi.com/api/amiibo/?character={character.name}";
                    var service = new HttpHelper<Amiibos>();
                    var amiibos = await service.GetRestServiceData(url);
                    Amiibos = new ObservableCollection<Amiibo>(amiibos.amiibo);
                }
            });
        }
        public async Task LoadCharacters(string url) {
            var servine = new HttpHelper<Characters>();
            var characters = await servine.GetRestServiceData(url);
            Characters = new ObservableCollection<Character>(characters.amiibo);
        }
    }
}
