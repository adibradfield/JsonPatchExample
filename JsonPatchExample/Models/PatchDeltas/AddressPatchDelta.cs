using JsonPatchExample.Models.Entity;
using JsonPatchHelper;

namespace JsonPatchExample.Models.PatchDeltas
{
    public class AddressPatchDelta : PatchDelta<AddressPatchEntity>
    {
        public PropertyDelta<string> Street { get; set; }
        public PropertyDelta<string> Location { get; set; }
        public PropertyDelta<string> Town { get; set; }
        public PropertyDelta<string> County { get; set; }
        public PropertyDelta<string> PostalCode { get; set; }
    }
}