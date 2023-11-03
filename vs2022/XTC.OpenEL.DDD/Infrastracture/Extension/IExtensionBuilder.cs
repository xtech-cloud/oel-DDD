using Autofac;
using AutoMapper;
using System;

namespace XTC.OpenEL.DDD.Infrastracture.Extension;

public interface IExtensionBuilder
{
    void UseDependencyInjection(Action<ContainerBuilder> _action);
    void UseAutoMapper(Action<MapperConfigurationExpression> _action);
}
