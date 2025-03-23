using System.ComponentModel.DataAnnotations;

namespace E_CommerceApp.Models
{
    public class Template
    {
        [Key]
        public int Id { get; set; }
        [Required , MaxLength(100)]
        public string TemplateName { get; set; }


        [Required]
        public string HtmlContent { get; set; }

        public TemplateType TemplateType { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

    }
}
