using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesCore.Models
{
    public class MovieListModel
    {
        [Key]
        public int MovieID { get; set; }

        [Column(TypeName = "nvarchar(12)")]
        [DisplayName("TMDB ID")]
        [Required(ErrorMessage = "This Field is Required")]
        public int TmdbID { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        [Required(ErrorMessage = "This Field is Required")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(4)")]
        [MaxLength(4, ErrorMessage = "Maximum 4 characters only")]
        [Required(ErrorMessage = "This Field is Required")]
        public string Year { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Type { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Genre { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [DisplayName("Poster Link")]
        public string Poster { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [DisplayName("Trailer Link")]
        public string Trailer { get; set; }

        [Column(TypeName = "nvarchar(5)")]
        public string Quality { get; set; }
    }
}
