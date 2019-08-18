using System.Runtime.Serialization;

using Interfaces.Models.Properties;

namespace Models.ArgsDefinitions
{
    [DataContract]
    public class Parameter: ITitleProperty
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }
        [DataMember(Name = "desc")]
        public string Description { get; set; }
        [DataMember(Name = "multiple")]
        public bool Multiple { get; set; }
        [DataMember(Name = "values")]
        public string[] Values { get; set; }
    }
}