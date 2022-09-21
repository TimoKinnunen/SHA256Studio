﻿using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace SHA256Studio.Views
{
    public sealed partial class InstructionsPage : Page
    {
        MainPage MainPage { get; }

        public InstructionsPage()
        {
            InitializeComponent();

            SizeChanged += InstructionsPage_SizeChanged;

            Loaded += InstructionsPage_Loaded;

            MainPage = MainPage.CurrentMainPage;
        }

        private void InstructionsPage_Loaded(object sender, RoutedEventArgs e)
        {
            SetPageContentStackPanelWidth();
        }

        private void InstructionsPage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            SetPageContentStackPanelWidth();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // code here
            // code here
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            // code here
            // code here
        }

        private void SetPageContentStackPanelWidth()
        {
            PageContentStackPanel.Width = ActualWidth -
                PageContentScrollViewer.Margin.Left -
                PageContentScrollViewer.Padding.Right;
        }

        #region MenuAppBarButton
        private void HomeAppBarButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (sender is AppBarButton)
            {
                MainPage.GoToHomePage();
            }
        }
        #endregion MenuAppBarButton
    }
}
