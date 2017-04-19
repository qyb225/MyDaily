using MyDaily.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyDaily.ViewModels {
    public class NoteListViewModels : INotifyPropertyChanged {
        private ObservableCollection<Models.NoteItem> allItems = new ObservableCollection<Models.NoteItem>();
        public ObservableCollection<Models.NoteItem> AllItems {
            get { return this.allItems; }
            set {
                if (allItems != value) {
                    allItems = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private Models.NoteItem selectedItem = default(Models.NoteItem);
        public Models.NoteItem SelectedItem { get { return selectedItem; } set { this.selectedItem = value; } }

        public NoteListViewModels() {
            using (var conn = NoteDatabase.GetDbConnection()) {
                
                var allDB = conn.Table<Models.NoteItem>();
                foreach (var item in allDB) {
                    this.allItems.Add(new Models.NoteItem() { id = item.id, Title = item.Title, Details = item.Details });
                }
            }
        }


        public void AddNoteItem(string title, string detail) {
            Models.NoteItem theNew = new Models.NoteItem() { Title = title, Details = detail };
            this.allItems.Add(theNew);
            using (var conn = NoteDatabase.GetDbConnection()) {
                var Database = conn.Table<Models.NoteItem>();
                conn.Insert(theNew);
            }
            NotifyPropertyChanged();
        }

        public void AddNoteItem(Models.NoteItem x) {
            this.allItems.Add(x);
            using (var conn = NoteDatabase.GetDbConnection()) {
                var Database = conn.Table<Models.NoteItem>();
                conn.Insert(x);
            }
            NotifyPropertyChanged();
        }

        public void Update(Models.NoteItem x) {
            using (var conn = NoteDatabase.GetDbConnection()) {
                var Database = conn.Table<Models.NoteItem>();
                conn.InsertOrReplace(x);
            }
            NotifyPropertyChanged();
        }

        public void RemoveNoteItem(Models.NoteItem x) {
            this.allItems.Remove(x);
            using (var conn = NoteDatabase.GetDbConnection()) {
                var Database = conn.Table<Models.NoteItem>();
                conn.Delete(x);
            }
            this.selectedItem = null;
            NotifyPropertyChanged();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "") {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
