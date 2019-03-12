using System;
using System.Collections.Generic;

namespace SPMedicalGroup.DomainsContextDir
{
    public partial class Situacao
    {
        public Situacao()
        {
            Consultas = new HashSet<Consultas>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Consultas> Consultas { get; set; }
    }
}
