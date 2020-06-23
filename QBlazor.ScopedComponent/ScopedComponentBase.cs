using System;
using Microsoft.AspNetCore.Components;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

// https://mrpmorris.blogspot.com/2020/04/blazor-scoping-services-to-component.html
namespace QBlazor.ScopedComponent
{
    public abstract class ScopedComponentBase : OwningComponentBase<IServiceProvider>
    {
        protected override void OnInitialized()
        {
            base.OnInitialized();
            DependencyInjector.InjectDependencies(this, Service);
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class InjectScopedAttribute : Attribute
    {
    }

    internal static class DependencyInjector
    {
        private static readonly ConcurrentDictionary<Type, IEnumerable<PropertyInjector>> TypeToPropertyInjectors = new ConcurrentDictionary<Type, IEnumerable<PropertyInjector>>();

        public static void InjectDependencies(ScopedComponentBase instance, IServiceProvider serviceProvider)
        {
            IEnumerable<PropertyInjector> propertyInjectors = TypeToPropertyInjectors.GetOrAdd(instance.GetType(), _ => CreatePropertyInjectors(instance));

            var serviceTypes = propertyInjectors.Select(x => x.ServiceType).Distinct().ToDictionary(x => x, x => serviceProvider.GetService(x));

            foreach (var injector in propertyInjectors)
            {
                injector.PropertySetter(instance, serviceTypes[injector.ServiceType]);
            }
        }

        private static IEnumerable<PropertyInjector> CreatePropertyInjectors(ScopedComponentBase instance)
        {
            Type componentType = instance.GetType();

            var properties = componentType
             .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
             .Select(p => new { Property = p, Attribute = p.GetCustomAttribute<InjectScopedAttribute>() })
             .Where(x => x.Attribute != null)
             .Select(x => new { x.Property.PropertyType, x.Property.SetMethod })
             .Where(x => x.SetMethod != null);

            var injectors = new List<PropertyInjector>();
            foreach (var property in properties)
            {
                var setterDelegateType = typeof(Action<,>).MakeGenericType(componentType, property.PropertyType);
                var setterDelegate = Delegate.CreateDelegate(setterDelegateType, property.SetMethod);

                Action<object, object> setProperty = (inst, service) => setterDelegate.DynamicInvoke(inst, service);

                var injector = new PropertyInjector(property.PropertyType, setProperty);
                injectors.Add(injector);
            }
            return injectors;
        }

        private class PropertyInjector
        {
            public Type ServiceType { get; }
            public Action<object, object> PropertySetter { get; }

            public PropertyInjector(Type serviceType, Action<object, object> propertySetter)
            {
                ServiceType = serviceType;
                PropertySetter = propertySetter;
            }
        }
    }
}