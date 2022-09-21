using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace SHA256Studio.Views
{
    public sealed partial class MerkleRootPage : Page
    {
        MainPage MainPage { get; }

        public MerkleRootPage()
        {
            InitializeComponent();

            Loaded += MerkleRootPage_Loaded;

            MainPage = MainPage.CurrentMainPage;
        }

        private async void MerkleRootPage_Loaded(object sender, RoutedEventArgs e)
        {
            string fileLocationAndName = @"Assets\MerkleRootPageCode.txt";
            StorageFolder InstallationFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            StorageFile storageFile = await InstallationFolder.GetFileAsync(fileLocationAndName);
            MerkleRootPageCodeTextBlock.Text = await FileIO.ReadTextAsync(storageFile);
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

        private void CalculateHashOfMerkleRootButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            CalculatedHashOfMerkleRootTextBlock.Text = CalculateHashOfMerkleRoot(Data.MerkleRootTransactions.Tx);
        }

        string CalculateHashOfMerkleRoot(string[] transactions)
        {
            while (true)
            {
                if (transactions.Length == 1)
                {
                    return transactions[0];
                }

                List<string> newTransactionList = new List<string>();
                int recordCount = (transactions.Length % 2 != 0) ? transactions.Length - 1 : transactions.Length;
                for (int i = 0; i < recordCount; i += 2)
                {
                    newTransactionList.Add(CalculateTransactionSHA256(transactions[i], transactions[i + 1]));
                }

                if (recordCount < transactions.Length)
                {
                    newTransactionList.Add(CalculateTransactionSHA256(transactions[transactions.Length - 1], transactions[transactions.Length - 1]));
                }

                transactions = newTransactionList.ToArray();
            }
        }

        string CalculateTransactionSHA256(string aTransactionHash, string bTransactionHash)
        {
            //transactions have 64 characters in it
            if (aTransactionHash.Length != 64 || bTransactionHash.Length != 64)
            {
                throw new ArgumentOutOfRangeException("Transaction as string length is not 64 characters.");
            }

            byte[] aBytes = new byte[32];
            for (int i = 0; i < 32; i++)
            {
                aBytes[i] = Convert.ToByte(aTransactionHash.Substring(i * 2, 2), 16);
            }
            //reverse
            Array.Reverse(aBytes);

            byte[] bBytes = new byte[32];
            for (int i = 0; i < 32; i++)
            {
                bBytes[i] = Convert.ToByte(bTransactionHash.Substring(i * 2, 2), 16);
            }
            //reverse
            Array.Reverse(bBytes);

            //concatenate aBytes and bBytes
            byte[] concatenatedBytes = aBytes.Concat(bBytes).ToArray();

            //calculate SHA256 first time
            byte[] firstTimeHashBytes;
            using (SHA256 sha256 = SHA256.Create())
            {
                firstTimeHashBytes = sha256.ComputeHash(concatenatedBytes);
            }

            //calculate SHA256 second time
            byte[] secondTimeHashBytes;
            using (SHA256 sha256 = SHA256.Create())
            {
                secondTimeHashBytes = sha256.ComputeHash(firstTimeHashBytes);
            }
            //reverse secondTimeHashBytes
            Array.Reverse(secondTimeHashBytes);

            //convert byte array to a string   
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < secondTimeHashBytes.Length; i++)
            {
                stringBuilder.Append(secondTimeHashBytes[i].ToString("x2"));
            }
            return stringBuilder.ToString();
        }
    }
}