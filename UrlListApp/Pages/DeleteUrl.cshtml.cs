using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UrlListApp.Models;
using UrlListApp.Services;
using System;

namespace UrlListApp.Pages
{
    public class DeleteUrlModel : PageModel
    {
        private readonly UrlListRepository _repo;
        public UrlList? UrlList { get; set; }
        public UrlItem? UrlItem { get; set; }

        public DeleteUrlModel()
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
            return Page();
        }

        public IActionResult OnPost(string customUrl, Guid urlId)
        {
            UrlList = _repo.GetByCustomUrl(customUrl);
            if (UrlList == null)
                return NotFound();
            var item = UrlList.Urls.FirstOrDefault(u => u.Id == urlId);
            if (item != null)
                UrlList.Urls.Remove(item);
            return RedirectToPage("/ViewUrlList", new { customUrl });
        }
    }
}
