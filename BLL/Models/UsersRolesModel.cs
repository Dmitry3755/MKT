using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;


namespace BLL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class UsersRolesModel
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int users_roles_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int user_id_FK { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int role_id_FK { get; set; }

        public virtual Roles Roles { get; set; }

        public virtual Users Users { get; set; }

        public UsersRolesModel()
        {
        }

        public UsersRolesModel(Users_roles usersRoles)
        {
            users_roles_id = usersRoles.users_roles_id;
            role_id_FK = usersRoles.role_id_FK;
            user_id_FK = usersRoles.user_id_FK;
        }
    }
}
