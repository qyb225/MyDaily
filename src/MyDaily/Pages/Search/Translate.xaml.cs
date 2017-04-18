using MyDaily.Procy.TranslateProcy;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MyDaily.Pages.Search {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Translate : Page {
        public Translate() {
            this.InitializeComponent();
        }
        private async void showResult(string words) {
            RootObject translate = await TranslateProcy.GetTranslate(words);
            if (translate.basic == null) {
                Result.Text = "Cannot translate " + words;
            }
            else {
                Result.Text += "【 Basic 】: \n";
                foreach (var res in translate.basic.explains) {
                    Result.Text = Result.Text + res + "\n";
                }
                Result.Text += "\n【 Web 】: \n";
                foreach (var res in translate.web) {
                    Result.Text = Result.Text + "[" + res.key + "]:\n";
                    foreach (var weblist in res.value) {
                        Result.Text = Result.Text + weblist + "; ";
                    }
                    Result.Text = Result.Text + "\n\n";
                }
            }
        }

        private void Transl_Click(object sender, RoutedEventArgs e) {
            Result.Text = "";
            showResult(Input.Text);
        }
    }
}
