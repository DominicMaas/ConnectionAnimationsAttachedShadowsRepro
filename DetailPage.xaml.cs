using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace ConnectionAnimationsAttachedShadowsRepro
{
    public sealed partial class DetailPage : Page
    {
        public static readonly DependencyProperty ModelProperty =
            DependencyProperty.Register(nameof(Model), typeof(MyModel), typeof(DetailPage), new PropertyMetadata(null));

        public MyModel Model
        {
            get => (MyModel)GetValue(ModelProperty);
            set => SetValue(ModelProperty, value);
        }

        public DetailPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Model = (MyModel)e.Parameter;
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
