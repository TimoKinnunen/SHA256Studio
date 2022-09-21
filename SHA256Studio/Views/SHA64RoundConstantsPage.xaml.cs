using SHA256Studio.Data;
using SHA256Studio.Extensions;
using SHA256Studio.ViewModels;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace SHA256Studio.Views
{
    public sealed partial class SHA64RoundConstantsPage : Page
    {
        MainPage MainPage { get; }

        ObservableCollection<CubeRoot64RoundConstantViewModel> RoundConstantViewModels { get; set; } = new ObservableCollection<CubeRoot64RoundConstantViewModel>();

        public SHA64RoundConstantsPage()
        {
            InitializeComponent();

            Loaded += SHA64RoundConstantsPage_Loaded;

            MainPage = MainPage.CurrentMainPage;
        }

        private void SHA64RoundConstantsPage_Loaded(object sender, RoutedEventArgs e)
        {
            uint[] originalCubeRootRoundConstants = CubeRoot64RoundConstants.K; //from web
            uint[] smallPrimes = SmallPrimes.smallPrimes;
            for (int i = 0; i < 64; i++)
            {
                uint calculatedRoundConstantCubeRoot = BitwiseOperations.GetCalculatedRoundConstantCubeRoot(smallPrimes[i]);
                string bits32 = Convert.ToString(calculatedRoundConstantCubeRoot, 2).PadLeft(32, '0');
                RoundConstantViewModels.Add(new CubeRoot64RoundConstantViewModel
                {
                    CubeRoot64RoundConstantViewModelId = i,
                    Primenumber = smallPrimes[i],
                    Calculated = $"0x{calculatedRoundConstantCubeRoot:x2}",
                    Original = $"0x{originalCubeRootRoundConstants[i]:x2}",
                    Bits32 = $"{bits32}",
                });
            }
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
    }
}
