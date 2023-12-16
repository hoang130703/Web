using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Components
{
    [ViewComponent(Name = "Post")]
    public class RecentPostComponet : ViewComponent
    {
        private readonly DataContext _context;
        public RecentPostComponet(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofPost = (from p in _context.Posts
                              where (p.IsActive == true) && (p.Status == 1)
                              orderby p.PostID descending
                              select p).Take(6).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofPost));
        }
    }
}