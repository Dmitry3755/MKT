namespace MKT
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int user_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string user_login { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string user_password { get; set; }
    }
}
