using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyDaily.Models {
    public class NoteItem : INotifyPropertyChanged {
        [PrimaryKey]
        [AutoIncrement]
        public int id { set; get; }

        
        private string title;
        [MaxLength(20)]
        public string Title {
            get { return this.title; }
            set {
                if (title != value) {
                    title = value;
                    NotifyPropertyChanged();
                }
            }
        }

        
        private string details { set; get; }
        [MaxLength(100)]
        public string Details {
            get { return this.details; }
            set {
                if (details != value) {
                    details = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "") {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
