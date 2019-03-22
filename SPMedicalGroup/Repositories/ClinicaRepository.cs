using SPMedicalGroup.DomainsContextDir;
using SPMedicalGroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        public void Cadastrar(Clinica clinica)
        {
            using (SpMedicalContext ctx = new SpMedicalContext())
            {
                ctx.Clinica.Add(clinica);
                ctx.SaveChanges();
            }
        }
    }
}
