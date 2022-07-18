using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace GEdit
{
    public class DynamicPropertyManager<TTarget> : IDisposable
    {
        private readonly DynamicTypeDescriptionProvider _provider;
        private readonly TTarget _target;

        public DynamicPropertyManager()
        {
            Type type = typeof(TTarget);

            _provider = new DynamicTypeDescriptionProvider(type);
            TypeDescriptor.AddProvider(_provider, type);
        }

        public DynamicPropertyManager(TTarget target)
        {
            this._target = target;

            _provider = new DynamicTypeDescriptionProvider(typeof(TTarget));
            TypeDescriptor.AddProvider(_provider, target);
        }

        public IList<PropertyDescriptor> Properties => _provider.Properties;

        public void Dispose()
        {
            if (ReferenceEquals(_target, null))
            {
                TypeDescriptor.RemoveProvider(_provider, typeof(TTarget));
            }
            else
            {
                TypeDescriptor.RemoveProvider(_provider, _target);
            }
        }

        public static DynamicPropertyDescriptor<TTargetType, TPropertyType> CreateProperty<TTargetType, TPropertyType>(
                string displayName,
                Func<TTargetType, TPropertyType> getter,
                Action<TTargetType, TPropertyType> setter,
                Attribute[] attributes)
        {
            return new DynamicPropertyDescriptor<TTargetType, TPropertyType>(
                displayName, getter, setter, attributes);
        }

        public static DynamicPropertyDescriptor<TTargetType, TPropertyType> CreateProperty<TTargetType, TPropertyType>(
                string displayName,
                Func<TTargetType, TPropertyType> getHandler,
                Attribute[] attributes)
        {
            return new DynamicPropertyDescriptor<TTargetType, TPropertyType>(
                displayName, getHandler, (t, p) => { }, attributes);
        }
    }
}