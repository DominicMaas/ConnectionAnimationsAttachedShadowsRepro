using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ConnectionAnimationsAttachedShadowsRepro
{
    public sealed partial class MyUserControl : UserControl
    {
        public static readonly DependencyProperty AttachedModelProperty =
            DependencyProperty.Register(nameof(AttachedModel), typeof(MyModel), typeof(MyUserControl), new PropertyMetadata(null));

        public MyModel AttachedModel
        {
            get => (MyModel)GetValue(AttachedModelProperty);
            set => SetValue(AttachedModelProperty, value);
        }

        public MyUserControl()
        {
            InitializeComponent();
        }
    }
}
