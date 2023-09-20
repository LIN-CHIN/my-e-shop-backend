using NJsonSchema;
using NSwag.Generation.Processors.Contexts;
using NSwag.Generation.Processors;
using NSwag;

namespace EShopAPI.NSwags
{
    /// <summary>
    /// 加入自訂的Header 參數
    /// </summary>
    public class AddHeaderParameter : IOperationProcessor
    {
        public bool Process(OperationProcessorContext context)
        {
            // Define your custom header parameter here
            var parameter = new OpenApiParameter
            {
                Name = "EventId",
                Kind = OpenApiParameterKind.Header,
                Type = JsonObjectType.String, // Set the type as needed (integer in this case)
                IsRequired = true,
                Description = "事件id",
                Default = ""
            };

            // Add the parameter to the operation
            context.OperationDescription.Operation.Parameters.Add(parameter);

            return true;
        }
    }
}
