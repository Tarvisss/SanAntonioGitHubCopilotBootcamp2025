using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UrlListApp.Models;
using UrlListApp.Services;

namespace UrlListApp.Pages
{
    public class ViewUrlListModel : PageModel
    {
        private readonly UrlListRepository _repo;
        public UrlList? UrlList { get; set; }

        public ViewUrlListModel()
        {
            _repo = new UrlListRepository();
        }

        public IActionResult OnGet(string customUrl)
        {
            UrlList = _repo.GetByCustomUrl(customUrl);
            if (UrlList == null)
                return NotFound();
            return Page();
        }
    }
}
