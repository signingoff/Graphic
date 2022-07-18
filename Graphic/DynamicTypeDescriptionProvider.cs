using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace GEdit
{
    public class DynamicTypeDescriptionProvider : TypeDescriptionProvider
    {
        private readonly List<PropertyDescriptor> _properties = new List<PropertyDescriptor>();

        public DynamicTypeDescriptionProvider(Type type) : base(TypeDescriptor.GetProvider(type))
        {
        }

        public IList<PropertyDescriptor> Properties => _properties;

        public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance)
        {
            return new DynamicCustomTypeDescriptor(_properties, base.GetTypeDescriptor(objectType, instance));
        }

        private class DynamicCustomTypeDescriptor : CustomTypeDescriptor
        {
            private readonly IList<PropertyDescriptor> _dynamicPropertyDescriptors;

            public DynamicCustomTypeDescriptor(IList<PropertyDescriptor> dynamicPropertyDescriptors, ICustomTypeDescriptor descriptor)
                : base(descriptor)
            {
                this._dynamicPropertyDescriptors = dynamicPropertyDescriptors;
            }

            public override PropertyDescriptorCollection GetProperties()
            {
                return GetProperties(null);
            }

            public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
            {
                var properties = new PropertyDescriptorCollection(null);

                foreach (PropertyDescriptor property in base.GetProperties(attributes))
                {
                    properties.Add(property);
                }

                foreach (PropertyDescriptor property in _dynamicPropertyDescriptors)
                {
                    properties.Add(property);
                }
                return properties;
            }
        }
    }
}