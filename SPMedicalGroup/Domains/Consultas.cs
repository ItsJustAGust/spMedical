using System;
using System.Collections.Generic;

namespace SPMedicalGroup.DomainsContextDir
{
    public partial class Consultas
    {
        public int Id { get; set; }
        public int? PacienteId { get; set; }
        public int? MedicosId { get; set; }
        public DateTime? DataAgendamento { get; set; }
        public string Descricao { get; set; }
        public int? SituacaoId { get; set; }

        public Medicos Medicos { get; set; }
        public Pacientes Paciente { get; set; }
        public Situacao Situacao { get; set; }
    }
}
