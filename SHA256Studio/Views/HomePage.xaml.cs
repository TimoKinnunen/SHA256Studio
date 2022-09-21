using System;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace SHA256Studio.Views
{
    public sealed partial class HomePage : Page
    {
        MainPage MainPage { get; }

        public HomePage()
        {
            InitializeComponent();

            Loaded += HomePage_Loaded;

            MainPage = MainPage.CurrentMainPage;
        }

        private async void HomePage_Loaded(object sender, RoutedEventArgs e)
        {
            string fileLocationAndName = @"Assets\HomePageCode.txt";
            StorageFolder InstallationFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            StorageFile storageFile = await InstallationFolder.GetFileAsync(fileLocationAndName);
            HomePageCodeTextBlock.Text = await FileIO.ReadTextAsync(storageFile);
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

        //private string SHA256CalculateHash(string rawInput)
        //{
        //    #region read input
        //    StringBuilder inputBinaryStringBuilder = new StringBuilder();

        //    byte[] inputBytes = Encoding.UTF8.GetBytes(rawInput);

        //    foreach (byte inputByte in inputBytes)
        //    {
        //        inputBinaryStringBuilder.Append(Convert.ToString(inputByte, 2).PadLeft(8, '0'));
        //    }

        //    //does not pad left to 8 bits
        //    string binaryInputLengthAsBinary = Convert.ToString(inputBinaryStringBuilder.Length, 2);

        //    //to separate input from rest -> add '1'
        //    inputBinaryStringBuilder.Append('1');

        //    while ((inputBinaryStringBuilder.Length + 64) % 512 != 0)
        //    {
        //        //up to 448 bits
        //        inputBinaryStringBuilder.Append('0');
        //    }

        //    //64 bits
        //    inputBinaryStringBuilder.Append(binaryInputLengthAsBinary.PadLeft(64, '0'));
        //    #endregion read input

        //    #region message blocks
        //    int messageBlockCount = inputBinaryStringBuilder.Length / 512;

        //    string[] messageBlocks = new string[messageBlockCount];

        //    for (int i = 0; i < messageBlockCount; i++)
        //    {
        //        messageBlocks[i] = inputBinaryStringBuilder.ToString().Substring(i * 512, 512);
        //    }
        //    #endregion message blocks

        //    #region create message scheduler and compress
        //    //initial hash values
        //    h0 = 0x6a09e667;
        //    h1 = 0xbb67ae85;
        //    h2 = 0x3c6ef372;
        //    h3 = 0xa54ff53a;
        //    h4 = 0x510e527f;
        //    h5 = 0x9b05688c;
        //    h6 = 0x1f83d9ab;
        //    h7 = 0x5be0cd19;

        //    //round constants
        //    uint[] K = {
        //        0x428a2f98, 0x71374491, 0xb5c0fbcf, 0xe9b5dba5, 0x3956c25b, 0x59f111f1, 0x923f82a4, 0xab1c5ed5,
        //        0xd807aa98, 0x12835b01, 0x243185be, 0x550c7dc3, 0x72be5d74, 0x80deb1fe, 0x9bdc06a7, 0xc19bf174,
        //        0xe49b69c1, 0xefbe4786, 0x0fc19dc6, 0x240ca1cc, 0x2de92c6f, 0x4a7484aa, 0x5cb0a9dc, 0x76f988da,
        //        0x983e5152, 0xa831c66d, 0xb00327c8, 0xbf597fc7, 0xc6e00bf3, 0xd5a79147, 0x06ca6351, 0x14292967,
        //        0x27b70a85, 0x2e1b2138, 0x4d2c6dfc, 0x53380d13, 0x650a7354, 0x766a0abb, 0x81c2c92e, 0x92722c85,
        //        0xa2bfe8a1, 0xa81a664b, 0xc24b8b70, 0xc76c51a3, 0xd192e819, 0xd6990624, 0xf40e3585, 0x106aa070,
        //        0x19a4c116, 0x1e376c08, 0x2748774c, 0x34b0bcb5, 0x391c0cb3, 0x4ed8aa4a, 0x5b9cca4f, 0x682e6ff3,
        //        0x748f82ee, 0x78a5636f, 0x84c87814, 0x8cc70208, 0x90befffa, 0xa4506ceb, 0xbef9a3f7, 0xc67178f2,
        //    };

        //    // working registers
        //    uint a, b, c, d, e, f, g, h;

        //    for (int m = 0; m < messageBlocks.Length; m++)
        //    {
        //        //initialized or from an earlier round
        //        a = h0;
        //        b = h1;
        //        c = h2;
        //        d = h3;
        //        e = h4;
        //        f = h5;
        //        g = h6;
        //        h = h7;

        //        #region message scheduler
        //        uint[] messageScheduler = new uint[64];

        //        for (int i = 0; i < 16; i++)
        //        {
        //            messageScheduler[i] = Convert.ToUInt32(messageBlocks[m].Substring(i * 32, 32), 2);
        //        }

        //        for (int t = 16; t < 64; t++)
        //        {
        //            //W(t) = σ1(t-2) + (t-7) + σ0(t-15) + (t-16)
        //            messageScheduler[t] = BitwiseOperations.LowerCaseSigma1(messageScheduler[t - 2]) +
        //                messageScheduler[t - 7] +
        //                BitwiseOperations.LowerCaseSigma0(messageScheduler[t - 15]) +
        //                messageScheduler[t - 16];
        //        }
        //        #endregion message scheduler

        //        #region compression
        //        for (int i = 0; i < 64; i++)
        //        {
        //            //temporary word T1 = Σ1(e) + Ch(e, f, g) + h + K0 + W0
        //            uint T1 = BitwiseOperations.UpperCaseSigma1(e) +
        //                BitwiseOperations.ChoiceXYZ(e, f, g) +
        //                h + K[i] + messageScheduler[i];

        //            //temporary word T2 = Σ0(a) + Maj(a, b, c)
        //            uint T2 = BitwiseOperations.UpperCaseSigma0(a) +
        //                BitwiseOperations.MajorityXYZ(a, b, c);

        //            //update the working registers
        //            h = g;
        //            g = f;
        //            f = e;
        //            e = d + T1;
        //            d = c;
        //            c = b;
        //            b = a;
        //            a = T1 + T2;
        //        }
        //        #endregion compression

        //        //for next round or final hash
        //        h0 = a + h0;
        //        h1 = b + h1;
        //        h2 = c + h2;
        //        h3 = d + h3;
        //        h4 = e + h4;
        //        h5 = f + h5;
        //        h6 = g + h6;
        //        h7 = h + h7;
        //    }
        //    #endregion create message scheduler and compress

        //    return $"{h0:x8}{h1:x8}{h2:x8}{h3:x8}{h4:x8}{h5:x8}{h6:x8}{h7:x8}";
        //}
    }
}
