using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using LibyanaHub.Services.Domain.Entities;

namespace LibyanaHub.Services.WebApi.Helper
{
    public class SwaggerExampleSchema
    {

        public class PostMessageExampleSchemaFilter : ISchemaFilter
        {
            public void Apply(OpenApiSchema schema, SchemaFilterContext context)
            {
                //if (context.Type == typeof(Test))
                //{
                //    schema.Example = new Microsoft.OpenApi.Any.OpenApiObject
                //    {
                //        ["msgID"] = new Microsoft.OpenApi.Any.OpenApiString(null),
                //        ["Sender"] = new Microsoft.OpenApi.Any.OpenApiString("Gecol"),
                //        ["Receiver"] = new Microsoft.OpenApi.Any.OpenApiString("218947776156"),
                //        ["Message"] = new Microsoft.OpenApi.Any.OpenApiString("Test SMS"),
                //        ["Profile"] = new Microsoft.OpenApi.Any.OpenApiString("")

                //    };
                //}
            }
        }
    }
}
