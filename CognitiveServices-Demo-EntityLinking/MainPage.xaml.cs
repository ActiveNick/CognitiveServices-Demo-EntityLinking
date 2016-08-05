using Microsoft.ProjectOxford.EntityLinking;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace CognitiveServices_Demo_EntityLinking
{
    /// <summary>
    /// Demonstrate Microsoft Entity Linking Intelligence Service, part of Cognitive Services,
    /// using a block of input text and displaying all the entities detected based on their
    /// corresponding Wikipedia articles
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        // Get Entitiy Linking results for input text
        private async void btnGetResult_Click(object sender, RoutedEventArgs e)
        {
            var text = this.inputBox.Text;

            // Create a new Cognitive Services Entity Linking Service client, pass our subscription ID
            var client = new EntityLinkingServiceClient("b2663927e9d242269740dd5390070e76");
            // Send our text for entity linking
            var linkResponse = await client.LinkAsync(text);
            // Display the results
            var result = string.Join(", ", linkResponse.Select(i => i.WikipediaID).ToList());
            this.outputBlock.Text = result;
        }

        // Clear all inputs and results
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            inputBox.Text = "";
            outputBlock.Text = "";
        }
    }
}
