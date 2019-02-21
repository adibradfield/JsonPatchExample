using System;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;

namespace JsonPatchHelper
{
    public abstract class JsonPatchMapper<TDto, TEntity> where TDto : class where TEntity : class
    {
        protected PatchMappingCollection MappingOverrides { get; } = new PatchMappingCollection();

        public JsonPatchDocument<TEntity> Map(JsonPatchDocument<TDto> dto)
        {
            var entity = new JsonPatchDocument<TEntity> {ContractResolver = dto.ContractResolver};

            foreach (var dtoOperation in dto.Operations)
            {
                var pathMapping = GetMapping(dtoOperation.path);
                var fromMapping = GetMapping(dtoOperation.from);
                var path = pathMapping?.NewPath ?? dtoOperation.path;
                var from = fromMapping?.NewPath ?? dtoOperation.from;
                var value = pathMapping?.ValueConverter(dtoOperation.value) ?? dtoOperation.value;

                entity.Operations.Add(new Operation<TEntity>(dtoOperation.op, path, from, value));
            }

            return entity;
        }

        private PatchMapping GetMapping(string path)
        {
            if (path == default(string))
            {
                return default(PatchMapping);
            }

            var pathParts = path.Split('/');

            for (var i = pathParts.Length; i > 1; i--)
            {
                var searchPath = string.Join("/", pathParts, 0, i);
                var key = GetMappingKey(searchPath);
                if (key != null)
                {
                    return MappingOverrides[key];
                }
            }

            return default(PatchMapping);
        }

        private string GetMappingKey(string path)
        {
            return MappingOverrides.Keys.SingleOrDefault(k =>
                string.Equals(k, path, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
