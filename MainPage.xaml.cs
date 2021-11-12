using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace ConnectionAnimationsAttachedShadowsRepro
{
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<MyModel> MyCollection { get; } = new ObservableCollection<MyModel>();

        public MainPage()
        {
            InitializeComponent();

            for (var i = 0; i < 20; i++)
            {
                MyCollection.Add(new MyModel { Name = $"Item {i}", ImageLink = "https://placekitten.com/150" });
            }
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frame.Navigate(typeof(DetailPage), e.ClickedItem, new DrillInNavigationTransitionInfo());
        }
    }
}
