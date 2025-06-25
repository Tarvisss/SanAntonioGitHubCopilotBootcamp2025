using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UrlListApp.Models;
using UrlListApp.Services;
using System;

namespace UrlListApp.Pages
{
    public class EditUrlModel : PageModel
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
        public UrlItem? UrlItem { get; set; }

        public EditUrlModel()
        {
            _repo = new UrlListRepository();
        }

        public IActionResult OnGet(string customUrl, Guid urlId)
        {
            UrlList = _repo.GetByCustomUrl(customUrl);
            if (UrlList == null)
                return NotFound();
            UrlItem = UrlList.Urls.FirstOrDefault(u => u.Id == urlId);
            if (UrlItem == null)
                return NotFound();
            InputUrl = UrlItem.Url;
            Title = UrlItem.Title;
            Description = UrlItem.Description;
            return Page();
        }

        public IActionResult OnPost(string customUrl, Guid urlId)
        {
            UrlList = _repo.GetByCustomUrl(customUrl);
            if (UrlList == null)
                return NotFound();
            UrlItem = UrlList.Urls.FirstOrDefault(u => u.Id == urlId);
            if (UrlItem == null)
                return NotFound();
            if (string.IsNullOrWhiteSpace(InputUrl))
            {
                ErrorMessage = "URL is required.";
                return Page();
            }
            UrlItem.Url = InputUrl;
            UrlItem.Title = Title;
            UrlItem.Description = Description;
            return RedirectToPage("/ViewUrlList", new { customUrl });
        }
    }
}
