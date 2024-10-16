﻿using System;
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
using MyDaily.Pages;
using MyDaily.Pages.ZhiHu;
using MyDaily.Pages.Note;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MyDaily {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page {
        public MainPage() {
            this.InitializeComponent();
            TheFrame.Navigate(typeof(HomePage));
        }

        private void HumbugerButton_Click(object sender, RoutedEventArgs e) {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void IconListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (ZhiHuBar.IsSelected) {
                TheFrame.Navigate(typeof(ZhiHuHomePage));
            }
            else if (HomePage.IsSelected) {
                TheFrame.Navigate(typeof(HomePage));
            }
            else if (SearchBar.IsSelected) {
                TheFrame.Navigate(typeof(SearchPage));
            }
            else if (NoteBar.IsSelected) {
                TheFrame.Navigate(typeof(NotePage));
            }
        }
    }
}
