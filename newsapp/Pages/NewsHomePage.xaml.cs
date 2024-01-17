using newsapp.Models;
using newsapp.Services;


namespace newsapp.Pages;

public partial class NewsHomePage : ContentPage
{
	public List<Article> ArticlesList;
	public List<Category> CategoryList = new List<Category>()
	{
		new Category(){Name= "World", ImageUrl = "world_removebg.png"},

		new Category() { Name = "Nation", ImageUrl = "nation_removebg.png"},

		new Category() { Name = "Business", ImageUrl = "business_removebg.png"},

		new Category() { Name = "Technology", ImageUrl = "tech_removebg.png"},

		new Category() { Name = "Entertainment", ImageUrl = "entertainment_removebg.png"},

		new Category() { Name = "Sports", ImageUrl = "sports.png"},

		new Category() { Name = "Science", ImageUrl = "science_removebg.png"},

        new Category() { Name = "Health", ImageUrl = "health_health_removebg.png"},
};


    public NewsHomePage()
	{
        InitializeComponent();
		GetBreakingNews();
		ArticlesList = new List<Article>();
        CvCategories.ItemsSource = CategoryList;
	}

    private async void GetBreakingNews()
	{
        var ApiService = new ApiService();
        Android.Provider.DocumentsContract.Root newsResult = await Services.ApiService.GetNews("general");
        foreach (var item in newsResult.Articles)
        {
			ArticlesList.Add(item);

		}
        CvNews.ItemsSource = ArticlesList;
	}

	private void CvCategories_SelectedChanged(object sender, SelectionChangedEventArgs e)
	{
		var selectedItem = e.CurrentSelection.FirstOrDefault() as Category;
		if (selectedItem == null) return;
		Navigation.PushAsync(new NewsListPage(selectedItem.Name));
		((CollectionView)sender).SelectedItem = null;
	}

}
