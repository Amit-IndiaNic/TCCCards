using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCCCards.Models.Card
{
    [Table("CardTemplates")]
    public class CardTemplate : BaseStatusEntity
    {
        [Required]
        [StringLength(100)]
        public string TemplateName { get; set; }

        [Required]
        [StringLength(1000)]
        public string ImagePath { get; set; }

        [Required]
        [StringLength(200)]
        public string ImageName { get; set; }
    }
}
