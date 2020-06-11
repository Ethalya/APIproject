using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.DataAccess
{
    [Table("Users")]
    public class Users
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]

        public int id { get; set; }

        [Column("login")]
        [Required]
        [StringLength(20)]

        public string login { get; set; }

        [Column("password")]
        [Required]
        [StringLength(20)]

        public string password { get; set; }


        [Column("name")]
        [Required]
        [StringLength(30)]

        public string name { get; set; }

        [Column("album")]
        [Required]
        [StringLength(5)]

        public string album { get; set; }
    }
}
