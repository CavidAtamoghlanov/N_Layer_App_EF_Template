using AutoMapper;
using N_Layer_App_EF_Template.Business.DTOs.ClaimDTOs;
using N_Layer_App_EF_Template.Business.DTOs.RoleDTOs;
using N_Layer_App_EF_Template.Business.Mappings.Abstracts;
using N_Layer_App_EF_Template.Business.Mappings.Profiles;
using N_Layer_App_EF_Template.Domain.Entities.Concretes;

namespace N_Layer_App_EF_Template.Business.Mappings.Concretes
{
    public class AutoMapper : IAutoMapper
    {
        private readonly IMapper _mapper;

        public AutoMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile()); 
            });

            _mapper = configuration.CreateMapper();
        }

        public T Map<T, TModel>(TModel model) where T : class, new()
        {
            var result = _mapper.Map<T>(model);
            return result;
        }

        public IEnumerable<T> Map<T, TModel>(IEnumerable<TModel> model) where T : class, new()
        {
            var result = _mapper.Map<IEnumerable<T>>(model);
            return result;
        }
    }
}
