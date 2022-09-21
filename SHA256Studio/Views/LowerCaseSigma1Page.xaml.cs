using SHA256Studio.Extensions;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace SHA256Studio.Views
{
    public sealed partial class LowerCaseSigma1Page : Page
    {
        MainPage MainPage { get; }

        uint x { get; set; }

        uint lowerCaseSigma1 { get; set; }

        public LowerCaseSigma1Page()
        {
            InitializeComponent();

            Loaded += LowerCaseSigma1Page_Loaded;

            MainPage = MainPage.CurrentMainPage;
        }

        private void LowerCaseSigma1Page_Loaded(object sender, RoutedEventArgs e)
        {
            //x = uint.MaxValue;
            //x = 123456;

            x = Convert.ToUInt32("11111111111111".PadLeft(32, '0'), 2);

            InitiateUI();
        }

        private void InitiateUI()
        {
            NumberXTextBox.Text = x.ToString();

            Bits32XTextBlock.Text = Convert.ToString(x, 2).PadLeft(32, '0');

            lowerCaseSigma1 = BitwiseOperations.LowerCaseSigma1(x);

            Bits32LowerCaseSigma1TextBlock.Text = Convert.ToString(lowerCaseSigma1, 2).PadLeft(32, '0');
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
    }
}
