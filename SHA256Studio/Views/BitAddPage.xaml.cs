using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace SHA256Studio.Views
{
    public sealed partial class BitAddPage : Page
    {
        MainPage MainPage { get; }

        uint x { get; set; }

        uint y { get; set; }

        public BitAddPage()
        {
            InitializeComponent();

            Loaded += BitAddPage_Loaded;

            MainPage = MainPage.CurrentMainPage;
        }

        private void BitAddPage_Loaded(object sender, RoutedEventArgs e)
        {
            //x = uint.MaxValue;
            x = 1234567;

            y = 111111111;

            InitiateUI();
        }

        private void InitiateUI()
        {
            NumberXTextBox.Text = x.ToString();

            Bits32XTextBlock.Text = Convert.ToString(x, 2).PadLeft(32, '0'); ;

            NumberYTextBox.Text = y.ToString();

            Bits32YTextBlock.Text = Convert.ToString(y, 2).PadLeft(32, '0'); ;

            uint xy = x + y;

            AddBits32TextBlock.Text = Convert.ToString(xy, 2).PadLeft(32, '0'); ;

            AddBits32AsNumberTextBlock.Text = xy.ToString();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // code here
            // code here
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);

            // code here
            // code here
        }

        private void HomeAppBarButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (sender is AppBarButton)
            {
                MainPage.GoToHomePage();
            }
        }

        private void NumberXTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (uint.TryParse(NumberXTextBox.Text, out uint value))
            {
                x = value;
                InitiateUI();
            }
            else
            {
                x = 0;
                NumberXTextBox.Text = x.ToString();
                MainPage.NotifyUser("Number x should be unsigned int (32 bits)!", NotifyType.StatusMessage);
            }
        }

        private void NumberYTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (uint.TryParse(NumberYTextBox.Text, out uint value))
            {
                y = value;
                InitiateUI();
            }
            else
            {
                y = 0;
                NumberYTextBox.Text = y.ToString();
                MainPage.NotifyUser("Number y should be unsigned int (32 bits)!", NotifyType.StatusMessage);
            }
        }
    }
}
