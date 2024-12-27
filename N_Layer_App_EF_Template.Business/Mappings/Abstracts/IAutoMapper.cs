﻿namespace N_Layer_App_EF_Template.Business.Mappings.Abstracts;

public interface IAutoMapper
{
    public IEnumerable<T> Map<T, TModel>(IEnumerable<TModel> model) where T : class, new();
    public T Map<T, TModel>(TModel model) where T : class, new();
}