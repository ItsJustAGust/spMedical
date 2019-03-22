using Microsoft.EntityFrameworkCore;
using SPMedicalGroup.DomainsContextDir;
using SPMedicalGroup.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Usuarios BuscarPorEmailESenha(string email, string senha)
        {
            using (SpMedicalContext ctx = new SpMedicalContext())
            {
                Usuarios usuarioProcurado = ctx.Usuarios.Include(x => x.TipoUsuario).FirstOrDefault(x => x.Email == email && x.Senha == senha);

                if (usuarioProcurado == null)
                {
                    return null;
                }
                return usuarioProcurado;
            }
        }

        public void Cadastrar(Usuarios usuario)
        {
            using (SpMedicalContext ctx = new SpMedicalContext())
            {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
        }

        public void Deletar(Usuarios usuario)
        {
            using (SpMedicalContext ctx = new SpMedicalContext())
            {
                ctx.Usuarios.Remove(usuario);
                ctx.SaveChanges();
            }
        }


        public List<Usuarios> Listar()
        {
            using (SpMedicalContext ctx = new SpMedicalContext())
            {
                return ctx.Usuarios.ToList();
            }
        }

        public void Login(Usuarios usuario)
        {
            throw new NotImplementedException();
        }
    }
}
