using System;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;

namespace JsonPatchHelper
{
    public abstract class PatchDelta{}

    public abstract class PatchDelta<TEntity> : PatchDelta where TEntity : class
    {
        public TEntity Original { get; private set; }
        public TEntity Patched { get; private set; }

        public void Load(TEntity original, JsonPatchDocument<TEntity> patchDocument)
        {
            Original = original;
            var copyOfOriginal = original.Copy();
            patchDocument.ApplyTo(copyOfOriginal);
            Patched = copyOfOriginal;

            SetDeltas();
        }

        public void Load(TEntity original, TEntity patched)
        {
            Original = original;
            Patched = patched;

            SetDeltas();
        }

        private void SetDeltas()
        {
            var type = this.GetType();
            var deltaProperties = type.GetProperties().Where(p => typeof(PropertyDelta).IsAssignableFrom(p.PropertyType) && p.PropertyType.GenericTypeArguments.Length > 0);
            var patchProperties = type.GetProperties().Where(p => typeof(PatchDelta).IsAssignableFrom(p.PropertyType));

            foreach (var patchProperty in patchProperties)
            {
                var entityProperty = typeof(TEntity).GetProperty(patchProperty.Name);
                if (entityProperty != null)
                {
                    var patchDelta = Activator.CreateInstance(patchProperty.PropertyType);
                    var method = patchDelta.GetType().GetMethod("Load",
                        types: new[] {entityProperty.PropertyType, entityProperty.PropertyType});
                    method?.Invoke(patchDelta, new[] {entityProperty.GetValue(Original), entityProperty.GetValue(Patched)});
                    patchProperty.SetValue(this, patchDelta);
                }
            }

            foreach (var deltaProperty in deltaProperties)
            {
                var entityProperty = typeof(TEntity).GetProperty(deltaProperty.Name);
                if (entityProperty != null &&
                    deltaProperty.PropertyType.GenericTypeArguments.FirstOrDefault() == entityProperty.PropertyType)
                {
                    var patchDelta = Activator.CreateInstance(deltaProperty.PropertyType,
                        args: new[] {entityProperty.GetValue(Original), entityProperty.GetValue(Patched)});
                    deltaProperty.SetValue(this, patchDelta);
                }
            }
        }
    }
}
