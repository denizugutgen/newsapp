using newsapp.Models;
using newsapp.Services;

namespace newsapp.Pages;

public partial class NewsListPage : ContentPage
{
    ApiService apiService;
    public List<Article> ArticlesList;
    private object selectedItem;

    public object CurrentSelection { get; private set; }

    public NewsListPage(string categoryName)
	{
        InitializeComponent();
        Title = categoryName;
        GetNews(categoryName);
        ArticlesList = new List<Article>();
        
    }

    private async void GetNews(string categoryName)
    {
        apiService = new ApiService();
        var newsResult = await ApiService.GetNews(categoryName);
        foreach (var item in newsResult.Articles)
        {
            ArticlesList.Add(item);
        }
        CvNews.ItemsSource = ArticlesList;
    }

    private void CvNews_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedItem = e.CurrentSelection.FirstOrDefault() as Article;
        if (selectedItem == null) return;
        Navigation.PushAsync(new NewsDetailPage(selectedItem));
        ((CollectionView)sender).SelectedItem = null;
    }


}
