using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using MyDaily.Procy.ZhiHuProcy;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MyDaily.Pages.ZhiHu {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ZhiHuHomePage : Page {
        public ViewModels.StoriesListViewModels ViewModels { get; set; }
        private int topId = 0;
        private int topTotal = 0;
        RootObject Article;
        public ZhiHuHomePage() {
            this.InitializeComponent();
            this.ViewModels = new ViewModels.StoriesListViewModels();
            loadFrom();
        }

        private async void loadFrom() {
            Article = await DailyPage.GetArticle();
            topTotal = Article.top_stories.ToArray().Length;
            ThemeText1.Text = Article.top_stories[topId].title;
            ThemeImg1.Source = new BitmapImage(new Uri(Article.top_stories[topId].image));
            topId = (topId + 1) % topTotal;
            ThemeText2.Text = Article.top_stories[topId].title;
            ThemeImg2.Source = new BitmapImage(new Uri(Article.top_stories[topId].image));
            topId = (topId + 1) % topTotal;
        }

        private void ArticleItem_ItemClicked(object sender, ItemClickEventArgs e) {

        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            ThemeText1.Text = Article.top_stories[topId].title;
            ThemeImg1.Source = new BitmapImage(new Uri(Article.top_stories[topId].image));
            topId = (topId + 1) % topTotal;
            ThemeText2.Text = Article.top_stories[topId].title;
            ThemeImg2.Source = new BitmapImage(new Uri(Article.top_stories[topId].image));
            topId = (topId + 1) % topTotal;
        }
    }
}
