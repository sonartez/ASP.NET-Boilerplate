using System.ComponentModel.DataAnnotations;

namespace LinhDang.KworkPractice.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}