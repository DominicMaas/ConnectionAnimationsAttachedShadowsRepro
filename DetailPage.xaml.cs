using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
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

            var animation = ConnectedAnimationService.GetForCurrentView().GetAnimation("forwardAnimation");
            if (animation != null)
            {
                animation.TryStart(ModelControl, new [] { ModelName });
            }
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            var animation = ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("backAnimation", ModelControl);
            animation.Configuration = new DirectConnectedAnimationConfiguration();

            Frame.GoBack();
        }
    }
}
