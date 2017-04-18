using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MyDaily.Procy.ZhiHuProcy;

namespace MyDaily.ViewModels {
    public class StoriesListViewModels : INotifyPropertyChanged {
        private ObservableCollection<Models.StoriesItem> allItems = new ObservableCollection<Models.StoriesItem>();
        public ObservableCollection<Models.StoriesItem> AllItems {
            get { return this.allItems; }
            set {
                if (allItems != value) {
                    allItems = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private Models.StoriesItem selectedItem = default(Models.StoriesItem);
        public Models.StoriesItem SelectedItem { get { return selectedItem; } set { this.selectedItem = value; } }

        public StoriesListViewModels() {
            loadFrom();
        }

        private async void loadFrom() {
            RootObject Article = await DailyPage.GetArticle();
            var allStories = Article.stories;
            foreach (var item in allStories) {
                this.allItems.Add(new Models.StoriesItem(item.id, item.type, item.title, item.ga_prefix, item.multipic, item.images));
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
