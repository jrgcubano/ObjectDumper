using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Linq;

namespace ObjectDumper
{
    public abstract class BaseObjectDumper<T, TFormater>          
    {
        private readonly IDictionary<string, Delegate> _templates;

        public BaseObjectDumper()
        {
            _templates = new Dictionary<string, Delegate>();
        }

        public IEnumerable<TFormater> Dump(T source)
        {
            if (source.IsNull())
                yield break;

            var properties = source.GetRedeableProperties()
                                   .OrderBy(p => p.Name);                               

            foreach (var property in properties)
                yield return ApplyTemplate(property, source);            
        }

        public void AddTemplateFor<TProperty>(Expression<Func<T, TProperty>> expression, Func<TProperty, string> template)
        {
            _templates.AddIfNotNull(expression.GetPropertyName(), template);
        }

        private TFormater ApplyTemplate(PropertyInfo property, object source)
        {
            return HaveTemplate(property) ?
                        ApplyCustomTemplate(property, source, ResolveCustomTemplate(property)) :
                        ApplyDefaultTemplate(property, source);
        }

        private bool HaveTemplate(PropertyInfo property)
        {
            return _templates.ContainsKey(property.Name);
        }

        private Delegate ResolveCustomTemplate(PropertyInfo property)
        {
            return _templates[property.Name];
        }

        private TFormater ApplyCustomTemplate(PropertyInfo property, object source, Delegate template)
        {
            return FormatResult(property.Name, template.DynamicInvoke(property.GetValue(source)) as string);
        }

        private TFormater ApplyDefaultTemplate(PropertyInfo property, object source)
        {
            return FormatResult(property.Name, Convert.ToString(property.GetValue(source)));
        }
        protected abstract TFormater FormatResult(string name, string value);    
    }
}