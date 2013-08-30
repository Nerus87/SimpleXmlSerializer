using System;
using System.Runtime.Serialization;

namespace Example {

    [DataContract]
    class ToSerialize
    {

        private readonly string version = "1.2.3";

        [DataMember]
        private string value = null;

        [DataMember]
        public string value2 = "1";

        [DataMember]
        private int value3;

        /*.....*/

        private ToSerialize()
        {
        }

        public ToSerialize(double value)
        {
            this.value3 = (int) value;
        }

        public string getVersion() {
            return version;
        }

        public string getValue2()
        {
            return value2;
        }

    }


}
