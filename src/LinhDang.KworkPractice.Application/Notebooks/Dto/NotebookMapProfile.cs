using AutoMapper;
using LinhDang.KworkPractice.Core.Notebooks;
using System.Linq;

namespace LinhDang.KworkPractice.Notebooks.Dto
{
    public class NotebookMapProfile : Profile
    {
        public NotebookMapProfile()
        {
            CreateMap<NotebookDto,Notebook>()
                .ForMember(x=>x.Notes,opt=>opt.MapFrom(n=>n.Notes.OrderByDescending(t=>t.CreationTime)));
            CreateMap<NoteDto, Note>()
                .ForMember(x => x.Notebook, opt => opt.Ignore());
        }
    }
}
