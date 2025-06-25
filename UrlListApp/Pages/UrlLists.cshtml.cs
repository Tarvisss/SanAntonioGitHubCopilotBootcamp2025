using Microsoft.AspNetCore.Mvc.RazorPages;
using UrlListApp.Models;
using UrlListApp.Services;
using System.Collections.Generic;

namespace UrlListApp.Pages
{
    public class UrlListsModel : PageModel
    {
        private readonly UrlListRepository _repo;
        public List<UrlList> UrlLists { get; set; } = new();

        public UrlListsModel()
        {
            _repo = new UrlListRepository();
        }

        public void OnGet()
        {
            UrlLists = new List<UrlList>(_repo.GetAll());
        }
    }
}
