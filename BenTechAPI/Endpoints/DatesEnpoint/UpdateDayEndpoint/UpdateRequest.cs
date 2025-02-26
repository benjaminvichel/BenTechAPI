using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace BenTechAPI.Endpoints.DatesEnpoint.UpdateDayEndpoint
{
    public class UpdateRequest
    {
        [SwaggerSchema(Description = "Format: yyyy-MM-dd")]
        [DataType(DataType.Date)]
        public DateOnly Date { get; set; }
        public string colorCode { get; set; }
    }
}
