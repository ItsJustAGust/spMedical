using SPMedicalGroup.DomainsContextDir;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup.Interfaces
{
    interface IClinicaRepository
    {
        void Cadastrar(Clinica clinica);
    }
}
