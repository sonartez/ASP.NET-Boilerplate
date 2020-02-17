using System.Threading.Tasks;
using LinhDang.KworkPractice.Configuration.Dto;

namespace LinhDang.KworkPractice.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
