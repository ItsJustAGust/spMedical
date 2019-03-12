using SPMedicalGroup.DomainsContextDir;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup.Repository
{
    public class UsuarioRepository
    {
        public void Cadastrar (Usuarios usuario)
        {
            using (SpMedicalContext ctx = new SpMedicalContext())
            {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
	    }
        public void Listar (Usuarios usuario)
        {
            using (SpMedicalContext ctx = new SpMedicalContext())
            {
                ctx.Usuarios.ToList();
            }
        }
        Usuarios BuscarPorEmailESenha(string email, string senha)
        {
            using (SpMedicalContext ctx = new SpMedicalContext())
            {
                ctx.
            }
        }
    }
}
