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
    public sealed partial class SHA8WorkingVariablesPage : Page
    {
        MainPage MainPage { get; }

        ObservableCollection<SquareRoot8WorkingVariablesViewModel> SquareRoot8WorkingVariableViewModels { get; set; } = new ObservableCollection<SquareRoot8WorkingVariablesViewModel>();

        public SHA8WorkingVariablesPage()
        {
            InitializeComponent();

            Loaded += SHA8WorkingVariablesPage_Loaded;

            MainPage = MainPage.CurrentMainPage;
        }

        private void SHA8WorkingVariablesPage_Loaded(object sender, RoutedEventArgs e)
        {
            uint[] originalSquareRootWorkingVariables = SquareRoot8WorkingVariables.initialHashValue; //from web
            uint[] smallPrimes = SmallPrimes.smallPrimes;
            for (int i = 0; i < 8; i++)
            {
                uint calculatedSquareRootWorkingVariable = BitwiseOperations.GetCalculatedWorkingVariableSquareRoot(smallPrimes[i]);
                string bits32 = Convert.ToString(calculatedSquareRootWorkingVariable, 2).PadLeft(32, '0');
                SquareRoot8WorkingVariableViewModels.Add(new SquareRoot8WorkingVariablesViewModel
                {
                    SquareRoot8WorkingVariablesViewModelId = i,
                    Primenumber = smallPrimes[i],
                    Calculated = $"0x{calculatedSquareRootWorkingVariable:x2}",
                    Original = $"0x{originalSquareRootWorkingVariables[i]:x2}",
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
