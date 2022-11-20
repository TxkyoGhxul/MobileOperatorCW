using Application.ViewModels;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Helpers;
public static class HtmlHelper
{
    /// <summary>
    /// @if (Model.PageViewModel.HasNextPage)
        //{
        //    <a asp-action="Index"
        //   asp-route-page="@Model.PageViewModel.TotalPages"
        //   asp-route-pageSize="@Model.PageViewModel.PageSize"
        //   class="btn btn-outline-dark">
        //        На последнюю страницу
        //        <i class="glyphicon glyphicon-chevron-right"></i>
        //    </a>
        //}
/// </summary>
/// <typeparam name="T"></typeparam>
/// <param name="html"></param>
/// <param name="viewModel"></param>
/// <returns></returns>
    public static HtmlString CreateToLastPageButton<T>(this IHtmlHelper html, IndexViewModel<T> viewModel)
    {
        string result = string.Empty;

        if (viewModel.PageViewModel.HasNextPage)
        {
            result = "<a asp-action=\"Index\" " +
                $"asp-route-page=\"{viewModel.PageViewModel.TotalPages}\" " +
                $"asp-route-pageSize=\"{viewModel.PageViewModel.PageSize}\" " +
                "class=\"btn btn-outline-dark\">" +
                    "На последнюю страницу " +
                    "<i class=\"glyphicon glyphicon-chevron-right\"></i>" +
                "</a>";
        }

        return new HtmlString(result);
    }
}
