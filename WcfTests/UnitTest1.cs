using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WcfTests
{
    using System.IO;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Xml.Serialization;
    using WcfSerialization;

    [TestClass]
    public class UnitTest1
    {
        public static string ContractObjectToXml<T>(T obj)
        {
            var dataContractSerializer = new DataContractSerializer(obj.GetType());

            String text;
            using (var memoryStream = new MemoryStream())
            {
                dataContractSerializer.WriteObject(memoryStream, obj);
                byte[] data = new byte[memoryStream.Length];
                Array.Copy(memoryStream.GetBuffer(), data, data.Length);

                text = Encoding.UTF8.GetString(data);
            }
            return text;
        }

        [TestMethod]
        public void GivenAClassWithoutDataContract_WhenPropertyDefined_ThenSerializedByDefault()
        {
            // Arrange
            var x = new MyClass1() {MyProperty1 = 98765, MyProperty2 = "asdasdasd"};

            // Act
            var stringClass = ContractObjectToXml(x);

            // Assert
            Assert.IsTrue(stringClass.Contains("98765"));
            Assert.IsTrue(stringClass.Contains("asdasdasd"));

        }

        [TestMethod]
        public void GivenAClassWithDataContract_WhenPropertyDefined_ThenNothingIsSerialized()
        {
            // Arrange
            var x = new MyClass2() { MyProperty1 = 98765, MyProperty2 = "asdasdasd" };

            // Act
            var stringClass = ContractObjectToXml(x);

            // Assert
            Assert.IsFalse(stringClass.Contains("98765"));
            Assert.IsFalse(stringClass.Contains("asdasdasd"));

        }

        [TestMethod]
        public void GivenAClassWithDataContractAndDataMember_WhenPropertyDefined_ThenSerializedByDefault()
        {
            // Arrange
            var x = new MyClass3() { MyProperty1 = 98765, MyProperty2 = "asdasdasd" };

            // Act
            var stringClass = ContractObjectToXml(x);

            // Assert
            Assert.IsTrue(stringClass.Contains("98765"));
            Assert.IsTrue(stringClass.Contains("asdasdasd"));

        }

        [TestMethod]
        public void GivenAClassWithDataContractAndDataMember_WhenProperty2Ignored_ThenSerializedAllButNotIgnored()
        {
            // Arrange
            var x = new MyClass4() { MyProperty1 = 98765, MyProperty2 = "asdasdasd" };

            // Act
            var stringClass = ContractObjectToXml(x);

            // Assert
            Assert.IsTrue(stringClass.Contains("98765"));
            Assert.IsFalse(stringClass.Contains("asdasdasd"));

        }
        [TestMethod]
        public void GivenAClassWithDataContractAndDataMember_WhenProperty2NoAttribute_ThenSerializedAllButNotNoAttribute()
        {
            // Arrange
            var x = new MyClass5() { MyProperty1 = 98765, MyProperty2 = "asdasdasd" };

            // Act
            var stringClass = ContractObjectToXml(x);

            // Assert
            Assert.IsTrue(stringClass.Contains("98765"));
            Assert.IsFalse(stringClass.Contains("asdasdasd"));

        }
    }
}
