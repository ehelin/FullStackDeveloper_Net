using System;
using System.Runtime.Serialization;

namespace NetCoreAPIJwtAuthentication
{
    [Serializable]
    [DataContract]
    public class Login
    {
        [DataMember]
        public string username { get; set; }

        [DataMember]
        public string password { get; set; }

        [DataMember]
        public string tokenDataPoint { get; set; }
    }
}
