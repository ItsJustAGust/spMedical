using System;
using System.Collections.Generic;

namespace SPMedicalGroup.DomainsContextDir
{
    public partial class Medicos
    {
        public Medicos()
        {
            Consultas = new HashSet<Consultas>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public long Crm { get; set; }
        public int? EspecialidadeId { get; set; }
        public int? ClinicaId { get; set; }
        public int? UsuarioId { get; set; }

        public Clinica Clinica { get; set; }
        public Especialidade Especialidade { get; set; }
        public Usuarios Usuario { get; set; }
        public ICollection<Consultas> Consultas { get; set; }
    }
}
