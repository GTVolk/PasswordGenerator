using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

namespace PasswordGenerator
{
    [Serializable()]
    public class Resource
    {
        public Resource(int id, string name, string uniqueKey, bool useSpecialChars = true)
        {
            this.Id = id;
            this.Name = name;
            this.UniqueKey = uniqueKey;
            this.UseSpecialChars = useSpecialChars;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string UniqueKey { get; set; }
        public bool UseSpecialChars { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
