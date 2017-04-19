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
    public sealed partial class EditPage : Page {
        public ViewModels.NoteListViewModels ViewModels { get; set; }
        public Models.NoteItem SelectedItem { get; set; }
        public EditPage() {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e) {
            if ((ViewModels.NoteListViewModels)e.Parameter != null) {
                ViewModels = (ViewModels.NoteListViewModels)e.Parameter;
                SelectedItem = ViewModels.SelectedItem;
            }
            if (SelectedItem == null) {
                SelectedItem = new Models.NoteItem();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e) {
            ViewModels.RemoveNoteItem(SelectedItem);
            this.Frame.Navigate(typeof(NotePage));
        }
        private void ConfirmButton_Click(object sender, RoutedEventArgs e) {
            if (ViewModels.SelectedItem == null) {
                ViewModels.AddNoteItem(SelectedItem);
            }
            else {
                ViewModels.Update(SelectedItem);
            }
            this.Frame.Navigate(typeof(NotePage));
        }
    }
}
