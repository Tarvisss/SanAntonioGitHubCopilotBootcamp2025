using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UrlListApp.Models;
using UrlListApp.Services;

namespace UrlListApp.Pages
{
    public class DeleteUrlListModel : PageModel
    {
        private readonly UrlListRepository _repo;
        public UrlList? UrlList { get; set; }

        public DeleteUrlListModel()
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

        public IActionResult OnPost(string customUrl)
        {
            _repo.Remove(customUrl);
            return RedirectToPage("/UrlLists");
        }
    }
}
