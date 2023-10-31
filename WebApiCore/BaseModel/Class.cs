using System.ComponentModel.DataAnnotations;

namespace WebApiCore.BaseModel
{
    public class UploadFileInputDto
    {
        [Required]
        public IFormFile? File { get; set; }
    }

}
