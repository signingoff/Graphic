using System;
using System.ComponentModel;
using System.Linq;
using NUnit.Framework;

namespace GEdit
{
    [TestFixture]
    public class DescriptorTest
    {
        [Test, Order(1)]
        public void AddProperty()
        {
            var provider = new ThreeColumnDescriptionProvider();

            TypeDescriptor.AddProvider(provider, typeof(AnotherThreeColumns));

            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(AnotherThreeColumns));

            Assert.AreEqual(4, properties.Count);
        }

        [Test, Order(2)]
        public void DynamicProperty()
        {
            var propertyManager = new DynamicPropertyManager<ThreeColumns>();
            propertyManager.Properties.Add(
                DynamicPropertyManager<ThreeColumns>.CreateProperty<ThreeColumns, string>(
                    "FourProperty",
                    t => "Four",
                    null
                ));

            var p = TypeDescriptor.GetProperties(typeof(ThreeColumns));

            Assert.AreEqual(4, p.Count);
        }

        public class ThreeColumnDescriptionProvider : TypeDescriptionProvider
        {
            public ThreeColumnDescriptionProvider() : base(TypeDescriptor.GetProvider(typeof(AnotherThreeColumns)))
            {
            }

            public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance)
            {
                return new ThreeColumnTypeDescriptor(base.GetTypeDescriptor(objectType, instance));
            }
        }

        public class ThreeColumnTypeDescriptor : CustomTypeDescriptor
        {
            public ThreeColumnTypeDescriptor(ICustomTypeDescriptor parent) : base(parent)
            {
            }

            public override PropertyDescriptorCollection GetProperties()
            {
                return GetProperties(null);
            }

            public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
            {
                var properties = new PropertyDescriptorCollection(base.GetProperties(attributes).OfType<PropertyDescriptor>().ToArray());

                properties.Add(new ThreePropertyDescriptor("Four", null));

                return properties;
            }
        }

        public class ThreePropertyDescriptor : PropertyDescriptor
        {
            public ThreePropertyDescriptor(string name, Attribute[] attrs) : base(name, attrs)
            {
            }

            public ThreePropertyDescriptor(MemberDescriptor descr) : base(descr)
            {
            }

            public ThreePropertyDescriptor(MemberDescriptor descr, Attribute[] attrs) : base(descr, attrs)
            {
            }

            public override bool CanResetValue(object component)
            {
                throw new NotImplementedException();
            }

            public override object GetValue(object component)
            {
                throw new NotImplementedException();
            }

            public override void ResetValue(object component)
            {
                throw new NotImplementedException();
            }

            public override void SetValue(object component, object value)
            {
                throw new NotImplementedException();
            }

            public override bool ShouldSerializeValue(object component)
            {
                throw new NotImplementedException();
            }

            public override Type ComponentType { get; }
            public override bool IsReadOnly { get; }
            public override Type PropertyType { get; }
        }
    }
}