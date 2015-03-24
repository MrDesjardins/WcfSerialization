using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfSerialization
{
    using System.Runtime.Serialization;

    public class MyClass1
    {
        public int MyProperty1 { get; set; }
        public string MyProperty2 { get; set; }
    }
    [DataContract]
    public class MyClass2
    {
        public int MyProperty1 { get; set; }
        public string MyProperty2 { get; set; }
    }

    [DataContract]
    public class MyClass3
    {
        [DataMember]
        public int MyProperty1 { get; set; }
        [DataMember]
        public string MyProperty2 { get; set; }
    }


    [DataContract]
    public class MyClass4
    {
        [DataMember]
        public int MyProperty1 { get; set; }
        [IgnoreDataMember]
        public string MyProperty2 { get; set; }
    }

    [DataContract]
    public class MyClass5
    {
        [DataMember]
        public int MyProperty1 { get; set; }

        public string MyProperty2 { get; set; }
    }
}
