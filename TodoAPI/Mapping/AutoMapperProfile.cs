using AutoMapper;
using TodoAPI.Contracts;
using TodoAPI.Models;

namespace TodoAPI.MappingProfiles{
    public class AutoMapperProfile: Profile{
        public AutoMapperProfile(){
            CreateMap<CreateTodoRequest, Todo>()
            //When mapping from the source object to the destination object, do not set the Id property on the destination
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
                

            CreateMap<UpdateTodoRequest, Todo>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
        }
        
    }
}