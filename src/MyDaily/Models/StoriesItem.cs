using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace MyDaily.Models {
    public class StoriesItem : INotifyPropertyChanged {
        private string title;
        public string Title {
            get { return this.title; }
            set {
                if (title != value) {
                    title = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private int type;
        public int Type {
            get { return this.type; }
            set {
                if (type != value) {
                    type = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private List<string> images;
        public List<string> Images {
            get { return this.images; }
            set {
                if (images != value) {
                    images = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private int id;
        public int Id {
            get { return this.id; }
            set {
                if (id != value) {
                    id = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string ga_prefix;
        public string Ga_prefix {
            get { return this.ga_prefix; }
            set {
                if (ga_prefix != value) {
                    ga_prefix = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private bool? multipic;
        public bool? Multipic {
            get { return this.multipic; }
            set {
                if (multipic != value) {
                    multipic = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /*private BitmapImage image;
        public BitmapImage Image {
            get { return this.image; }
            set {
                if (image != value) {
                    image = value;
                    NotifyPropertyChanged();
                }
            }
        }*/

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "") {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public StoriesItem(int i, int tp, string tit, string prefix, bool? mul, List<string> imgs) {
            id = i;
            type = tp;
            title = tit;
            ga_prefix = prefix;
            multipic = mul;
            images = imgs;
        }
    }
}
