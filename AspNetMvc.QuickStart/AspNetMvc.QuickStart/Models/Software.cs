using System.ComponentModel.DataAnnotations;

namespace AspNetMvc.QuickStart.Models
{
    public class Software
    {
        public int ID { get; set; }

        [Display(Name = "软件名称")]
        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Name { get; set; }

        [Display(Name = "描述")]
        [Required]
        [StringLength(40)]
        public string Description { get; set; }

        [Display(Name = "类型")]
        [Required]
        [StringLength(4)]
        public string Type { get; set; }

        [Display(Name = "URL")]
        [StringLength(800)]
        public string URL { get; set; }

    }
}