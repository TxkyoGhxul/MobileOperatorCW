namespace Application.ViewModels;
public class IndexViewModel<T>
{
    public IEnumerable<T> Data { get; init; }
    public PageViewModel PageViewModel { get; init; }

    public IndexViewModel(IEnumerable<T> data, PageViewModel pageViewModel)
    {
        PageViewModel = pageViewModel;
        Data = data.Skip((pageViewModel.PageNumber - 1) * pageViewModel.PageSize)
                   .Take(pageViewModel.PageSize)
                   .ToList();
    }
}
