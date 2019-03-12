using System;
using System.Collections.Generic;

namespace SPMedicalGroup.DomainsContextDir
{
    public partial class Pacientes
    {
        public Pacientes()
        {
            Consultas = new HashSet<Consultas>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string EMail { get; set; }
        public string Telefone { get; set; }
        public long? Rg { get; set; }
        public long? Cpf { get; set; }
        public int? Cep { get; set; }
        public DateTime? DataNascimento { get; set; }
        public int? UsuarioId { get; set; }

        public Usuarios Usuario { get; set; }
        public ICollection<Consultas> Consultas { get; set; }
    }
}
