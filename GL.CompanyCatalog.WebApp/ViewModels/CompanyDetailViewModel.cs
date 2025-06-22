using System.ComponentModel.DataAnnotations;

namespace GL.CompanyCatalog.WebApp.ViewModels
{
    public class CompanyDetailViewModel
    {                
        public Guid CompanyId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The name of the company should be 50 characters or less")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The name of the excange should be 50 characters or less")]

        public string Exchange { get; set; } = string.Empty;

        [Required]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "The ticker must be exactly 5 characters.")]
        public string Ticker { get; set; } = string.Empty;

        [Required]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "The Isin must be exactly 12 characters.")]
        public string Isin { get; set; } = string.Empty;
        public string? Website { get; set; }
        public string ImageUrl { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        public CategoryViewModel Category { get; set; } = default!;
    }
}
