using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UrlListApp.Models;
using UrlListApp.Services;

namespace UrlListApp.Pages
{
    public class CreateUrlListModel : PageModel
    {
        private readonly UrlListRepository _repo;
        [BindProperty]
        public string? Title { get; set; }
        [BindProperty]
        public string? CustomUrl { get; set; }
        public string? ErrorMessage { get; set; }

        public CreateUrlListModel()
        {
            _repo = new UrlListRepository();
        }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(Title))
            {
                ErrorMessage = "Title is required.";
                return Page();
            }
            string url = CustomUrl;
            if (string.IsNullOrWhiteSpace(url))
            {
                url = _repo.GenerateUniqueUrl();
            }
            else if (_repo.CustomUrlExists(url))
            {
                ErrorMessage = "Custom URL is already taken.";
                return Page();
            }
            var list = new UrlList { Title = Title, CustomUrl = url };
            _repo.Add(list);
            return RedirectToPage("/ViewUrlList", new { customUrl = url });
        }
    }
}
