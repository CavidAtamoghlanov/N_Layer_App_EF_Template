using AutoMapper;
using N_Layer_App_EF_Template.Business.Mappings.Abstracts;
using N_Layer_App_EF_Template.Business.Mappings.Profiles;

namespace N_Layer_App_EF_Template.Business.Mappings.Concretes;

public class AutoMapper : IAutoMapper
{
    private readonly IMapper _mapper;


    public AutoMapper(MappingProfile mappingProfile)
    {
        MapperConfiguration? configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(mappingProfile);
        });

        _mapper = configuration.CreateMapper();
    }

    public T Map<T, TModel>(TModel model, bool hasProfiler = false) where T : class, new()
    {
        try
        {
            if (hasProfiler)
            {
                var result = _mapper.Map<T>(model);
                return result;
            }

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TModel, T>();
            });

            var mapper = configuration.CreateMapper();
            var resultCustom = mapper.Map<T>(model);

            return resultCustom;
        }
        catch (Exception ex)
        {
            throw new Exception(@$"Mapping Error - {typeof(TModel)} to {typeof(T)}\n\n" + ex.Message);
        }
    }

    public IEnumerable<T> Map<T, TModel>(IEnumerable<TModel> model, bool hasProfiler = false) where T : class, new()
    {
        try
        {
            if (hasProfiler)
            {
                var result = _mapper.Map<IEnumerable<T>>(model);
                return result;
            }

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TModel, T>();
            });

            var mapper = configuration.CreateMapper();

            var resultCustom = mapper.Map<IEnumerable<T>>(model);

            return resultCustom;
        }
        catch (Exception ex)
        {
            throw new Exception(@$"Mapping Error - {typeof(TModel)} to {typeof(T)}\n\n" + ex.Message);
        }
    }
}
