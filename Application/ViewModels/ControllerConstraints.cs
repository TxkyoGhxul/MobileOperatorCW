namespace Application.ViewModels;
public class ControllerConstraints
{
    public string INDEX_TEXT_FILTER_KEY { get; init; }
    public string INDEX_CURRENT_PAGE { get; init; }
    public string INDEX_PAGE_SIZE { get; init; }
    public string INDEX_ORDER_STATE { get; init; }

    public ControllerConstraints(string controllerName)
    {
        INDEX_TEXT_FILTER_KEY = $"{controllerName}/IndexTextFilter";
        INDEX_CURRENT_PAGE = $"{controllerName}/IndexCurrentPage";
        INDEX_PAGE_SIZE = $"{controllerName}/IndexPageSize";
        INDEX_ORDER_STATE = $"{controllerName}/IndexOrderState";
    }
}
