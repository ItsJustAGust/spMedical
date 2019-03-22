using SPMedicalGroup.DomainsContextDir;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup.Interfaces
{
    interface IConsultaRepository
    {
        
        void Cadastrar(Consultas consulta);

        List<Consultas> Listar();

        void Alterar(Consultas consulta);

        Consultas BuscarConsultaPorId(int id);

        /// <summary>
        /// Essa irá listar somente as consultas relacionadas ao paciente em questão
        /// </summary>
        /// <returns> Consultas do Paciente </returns>
        List<Consultas> ListarConsultasPaciente(int id);

        /// <summary>
        /// Essa irá listar somente as consultas relacionadas ao médico em questão
        /// </summary>
        /// <returns> Consultas do Medico </returns>
        List<Consultas> ListarConsultasMedico(int id);
    }
}
