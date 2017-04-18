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

namespace MyDaily.Pages.Note {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NotePage : Page {
        public ViewModels.NoteListViewModels ViewModels { get; set; }
        public NotePage() {
            this.InitializeComponent();
            this.ViewModels = new ViewModels.NoteListViewModels();
        }

        private void AddAppBarButton_Click(object sender, RoutedEventArgs e) {
            ViewModels.AddNoteItem("明天你好", "123456");
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e) { 
            if (ViewModels.SelectedItem != null) {
                ViewModels.RemoveNoteItem(ViewModels.SelectedItem);
            }
        }

        private void NoteItem_ItemClicked(object sender, ItemClickEventArgs e) {
            ViewModels.SelectedItem = (Models.NoteItem)(e.ClickedItem);
        }
    }
}
