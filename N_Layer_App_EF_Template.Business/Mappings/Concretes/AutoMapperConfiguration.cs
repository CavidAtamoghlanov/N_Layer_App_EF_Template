using AutoMapper;
using N_Layer_App_EF_Template.Business.Mappings.Abstracts;

namespace N_Layer_App_EF_Template.Business.Mappings.Concretes;

public class AutoMapperConfiguration : IAutoMapperConfiguration
{
    public T Map<T, TModel>(TModel model) where T : class, new()
    {

        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<TModel, T>();
        });

        var mapper = configuration.CreateMapper();

        var result = mapper.Map<T>(model);

        return result;
    }

    public IEnumerable<T> Map<T, TModel>(IEnumerable<TModel> model) where T : class, new()
    {

        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<TModel, T>();
        });

        var mapper = configuration.CreateMapper();

        var result = mapper.Map<IEnumerable<T>>(model);

        return result;
    }
}