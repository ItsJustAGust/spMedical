using Microsoft.EntityFrameworkCore;
using SPMedicalGroup.DomainsContextDir;
using SPMedicalGroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup.Repositories
{
    public class ConsultaRepsotory : IConsultaRepository
    {
        public void Alterar(Consultas consulta)
        {
            using (SpMedicalContext ctx = new SpMedicalContext())
            {
                ctx.Consultas.Update(consulta);
                ctx.SaveChanges();
            }
        }

        public Consultas BuscarConsultaPorId(int id)
        {
            using (SpMedicalContext ctx = new SpMedicalContext())
            {
                Consultas consultaProcurada = ctx.Consultas.Include(x => x.Medicos).FirstOrDefault(x => x.Id == id);

                if (consultaProcurada == null)
                {
                    return null;
                }
                return consultaProcurada;
            }
        }

        public void Cadastrar(Consultas consulta)
        {
            using (SpMedicalContext ctx = new SpMedicalContext())
            {
                ctx.Consultas.Add(consulta);
                ctx.SaveChanges();
            }
        }

        public List<Consultas> Listar()
        {
            using (SpMedicalContext ctx = new SpMedicalContext()) 
            {
                return ctx.Consultas.ToList();
            }
        }

        public List<Consultas> ListarConsultasMedico(int id)
        {
            using (SpMedicalContext ctx = new SpMedicalContext())
            {
                Medicos medicoProcurado = ctx.Medicos.FirstOrDefault(x => x.UsuarioId == id);
                return ctx.Consultas.Where(x => x.Medicos.Id == medicoProcurado.Id).ToList();
            }
        }

        public List<Consultas> ListarConsultasPaciente(int id)
        {
            using (SpMedicalContext ctx = new SpMedicalContext()) 
            {
                                                                 //Talvez esteja errado o x.Id
                Pacientes pacienteProcurado = ctx.Pacientes.FirstOrDefault(x => x.Id == id);
                return ctx.Consultas.Where(x => x.Paciente.Id == pacienteProcurado.Id).ToList();
            }
        }
    }
}
