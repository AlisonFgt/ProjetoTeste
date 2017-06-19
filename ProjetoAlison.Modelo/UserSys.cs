namespace ProjetoAlison
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserSys
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Login { get; set; }

        [Required(ErrorMessage ="Email é obrigatório")]
        [StringLength(50)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória.")]
        [StringLength(40)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public int UserRoleId { get; set; }
    }
}
