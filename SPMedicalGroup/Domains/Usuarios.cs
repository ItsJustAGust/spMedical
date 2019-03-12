using System;
using System.Collections.Generic;

namespace SPMedicalGroup.DomainsContextDir
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Medicos = new HashSet<Medicos>();
            Pacientes = new HashSet<Pacientes>();
        }

        public int Id { get; set; }
        public int? TipoUsuarioId { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public TipoUsuario TipoUsuario { get; set; }
        public ICollection<Medicos> Medicos { get; set; }
        public ICollection<Pacientes> Pacientes { get; set; }
    }
}
