using System;
using System.Threading.Tasks;
using Windows.Devices.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using MicrosoftHel10World.Services;

namespace MicrosoftHel10World.Layouts.Detail
{
    public sealed partial class PhotoDetailLayout : BaseDetailLayout
    {
        public static readonly DependencyProperty MaxWProperty =
            DependencyProperty.Register("MaxW", typeof(double), typeof(PhotoDetailLayout), new PropertyMetadata(0D));

        public static readonly DependencyProperty MaxHProperty =
            DependencyProperty.Register("MaxH", typeof(double), typeof(PhotoDetailLayout), new PropertyMetadata(0D));

        public PhotoDetailLayout()
        {
            InitializeComponent();
        }

        public double MaxW
        {
            get { return (double)GetValue(MaxWProperty); }
            set { SetValue(MaxWProperty, value); }
        }

        public double MaxH
        {
            get { return (double)GetValue(MaxHProperty); }
            set { SetValue(MaxHProperty, value); }
        }

        public override void UpdateFontSize()
        {
        }

        private void ScrollViewer_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            MaxH = e.NewSize.Height;
            MaxW = e.NewSize.Width;
        }
    }
}
