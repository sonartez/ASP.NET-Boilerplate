using Abp.Application.Services.Dto;

namespace LinhDang.KworkPractice.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

