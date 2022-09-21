using SHA256Studio.Extensions;
using System;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace SHA256Studio.Views
{
    public sealed partial class BitShiftRightPage : Page
    {
        MainPage MainPage { get; }

        uint x { get; set; }

        public BitShiftRightPage()
        {
            InitializeComponent();

            Loaded += BitShiftRightPage_Loaded;

            MainPage = MainPage.CurrentMainPage;
        }

        private void BitShiftRightPage_Loaded(object sender, RoutedEventArgs e)
        {
            x = 1234567890;

            InitiateUI();
        }

        private void InitiateUI()
        {
            NumberTextBox.Text = x.ToString();

            Bits32TextBlock.Text = Convert.ToString(x, 2).PadLeft(32, '0');

            ShiftedBits32TextBlock.Text = Convert.ToString(x, 2).PadLeft(32, '0');

            ShiftedBits32AsNumberTextBlock.Text = x.ToString();
        }

        private void ShiftRightOneButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            x = BitwiseOperations.ShiftRight(x, 1);
            ShiftedBits32TextBlock.Text = Convert.ToString(x, 2).PadLeft(32, '0');
            ShiftedBits32AsNumberTextBlock.Text = x.ToString();
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

        private async void ShiftRightAllAppBarButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            InitiateUI();

            ShiftCounterTextBlock.Visibility = Visibility.Visible;
            for (int i = 0; i < 32; i++)
            {
                x = BitwiseOperations.ShiftRight(x, 1);
                ShiftedBits32TextBlock.Text = Convert.ToString(x, 2).PadLeft(32, '0');
                ShiftedBits32AsNumberTextBlock.Text = x.ToString();
                ShiftCounterTextBlock.Text = $"{i + 1}";

                await Task.Delay(200);
            }
            ShiftCounterTextBlock.Visibility = Visibility.Collapsed;
        }

        private void NumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (uint.TryParse(NumberTextBox.Text, out uint value))
            {
                x = value;
                InitiateUI();
            }
            else
            {
                x = 0;
                NumberTextBox.Text = x.ToString();
                MainPage.NotifyUser("Number should be unsigned int (32 bits)!", NotifyType.StatusMessage);
            }
        }
    }
}
