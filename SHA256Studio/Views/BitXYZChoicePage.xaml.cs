using SHA256Studio.Extensions;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace SHA256Studio.Views
{
    public sealed partial class BitXYZChoicePage : Page
    {
        MainPage MainPage { get; }

        uint x { get; set; }

        uint y { get; set; }

        uint z { get; set; }

        public BitXYZChoicePage()
        {
            InitializeComponent();

            Loaded += BitXYZChoicePage_Loaded;

            MainPage = MainPage.CurrentMainPage;
        }

        private void BitXYZChoicePage_Loaded(object sender, RoutedEventArgs e)
        {
            //x = 1234567890;

            x = Convert.ToUInt32("01010001000011100101001001111111".PadLeft(32, '0'), 2); 

            //y = 94567890;

            y = Convert.ToUInt32("10011011000001010110100010001100".PadLeft(32, '0'), 2);

            //z = 91117890;

            z = Convert.ToUInt32("00011111100000111101100110101011".PadLeft(32, '0'), 2);

            InitiateUI();
        }

        private void InitiateUI()
        {
            NumberXTextBox.Text = x.ToString();

            Bits32XTextBlock.Text = Convert.ToString(x, 2).PadLeft(32, '0');

            NumberYTextBox.Text = y.ToString();

            Bits32YTextBlock.Text = Convert.ToString(y, 2).PadLeft(32, '0');

            NumberZTextBox.Text = z.ToString();

            Bits32ZTextBlock.Text = Convert.ToString(z, 2).PadLeft(32, '0');

            uint xyzChoice = BitwiseOperations.ChoiceXYZ(x, y, z);

            XYZChoiceBits32TextBlock.Text = Convert.ToString(xyzChoice, 2).PadLeft(32, '0');

            XYZChoiceBits32AsNumberTextBlock.Text = xyzChoice.ToString();
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

        private void NumberZTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (uint.TryParse(NumberZTextBox.Text, out uint value))
            {
                z = value;
                InitiateUI();
            }
            else
            {
                z = 0;
                NumberZTextBox.Text = z.ToString();
                MainPage.NotifyUser("Number z should be unsigned int (32 bits)!", NotifyType.StatusMessage);
            }
        }
    }
}
