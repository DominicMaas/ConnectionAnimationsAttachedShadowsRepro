using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace ConnectionAnimationsAttachedShadowsRepro
{
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<MyModel> MyCollection { get; } = new ObservableCollection<MyModel>();

        private object _persistedItem;

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
            _persistedItem = e.ClickedItem;

            var animation = MainGridView.PrepareConnectedAnimation("forwardAnimation", _persistedItem, "ModelControl");
            animation.Configuration = new GravityConnectedAnimationConfiguration();

            Frame.Navigate(typeof(DetailPage), _persistedItem, new DrillInNavigationTransitionInfo());
        }

        private async void MainGridView_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (_persistedItem != null)
            {
                MainGridView.ScrollIntoView(_persistedItem);

                var animation = ConnectedAnimationService.GetForCurrentView().GetAnimation("backAnimation");
                if (animation != null)
                {
                    await MainGridView.TryStartConnectedAnimationAsync(animation, _persistedItem, "ModelControl");
                }
            }
        }
    }
}
