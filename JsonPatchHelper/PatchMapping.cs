using System;

namespace JsonPatchHelper
{
    public class PatchMapping
    {
        public string OriginalPath { get; set; }
        public string NewPath { get; set; }
        public Func<object, object> ValueConverter { get; }

        public PatchMapping(string newPath, Func<object, object> valueConverter = null)
        {
            if (valueConverter == null)
            {
                valueConverter = s => s;
            }

            NewPath = newPath;
            ValueConverter = valueConverter;
        }
    }
}
