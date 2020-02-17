using Abp.Application.Navigation;

namespace LinhDang.KworkPractice.Web.Views.Shared.Components.SideBarNav
{
    public class SideBarNavViewModel
    {
        public UserMenu MainMenu { get; set; }

        public string ActiveMenuItemName { get; set; }
    }
}
