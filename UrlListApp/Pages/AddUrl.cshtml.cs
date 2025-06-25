using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UrlListApp.Models;
using UrlListApp.Services;

namespace UrlListApp.Pages
{
    public class AddUrlModel : PageModel
    {
        private readonly UrlListRepository _repo;
        [BindProperty]
        public string? InputUrl { get; set; }
        [BindProperty]
        public string? Title { get; set; }
        [BindProperty]
        public string? Description { get; set; }
        public string? ErrorMessage { get; set; }
        public UrlList? UrlList { get; set; }

        public AddUrlModel()
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
            UrlList = _repo.GetByCustomUrl(customUrl);
            if (UrlList == null)
                return NotFound();
            if (string.IsNullOrWhiteSpace(InputUrl))
            {
                ErrorMessage = "URL is required.";
                return Page();
            }
            UrlList.Urls.Add(new UrlItem { Url = InputUrl, Title = Title, Description = Description });
            return RedirectToPage("/ViewUrlList", new { customUrl });
        }
    }
}
