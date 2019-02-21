using System;
using System.Collections.Generic;

namespace JsonPatchHelper
{
    public class PatchMappingCollection : Dictionary<string, PatchMapping>
    {
        public void AddMapping(string oldPath, string newPath, Func<object, object> valueConverter = null)
        {
            this[oldPath] = new PatchMapping(newPath, valueConverter);
        }
    }
}
