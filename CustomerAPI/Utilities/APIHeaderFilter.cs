using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CustomerAPI.Utilities
{
    public class APIHeaderFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            var param = new OpenApiParameter();
            param.Name = "UserId";
            param.In = ParameterLocation.Header;
            param.Required = true;
            var param1 = new OpenApiParameter();
            param1.Name = "Token";
            param1.In = ParameterLocation.Header;
            param1.Required = true;

            operation.Parameters.Add(param);
            operation.Parameters.Add(param1);
        }
    }
}
