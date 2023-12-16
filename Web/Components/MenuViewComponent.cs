using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Components
{
    [ViewComponent(Name = "MenuView")]
    public class MenuViewComponent : ViewComponent
    {
        private DataContext _Context;
        public MenuViewComponent(DataContext context)
        {
            _Context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {


            var listofMenu = (from m in _Context.Menus
                              where (m.IsActive == true) && (m.Position == 1)
                              select m).ToList();


            return await Task.FromResult((IViewComponentResult)View("Default", listofMenu));
        }
    }
}
