using SPMedicalGroup.DomainsContextDir;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup.Interface
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuarios usuario);

        void Listar(Usuarios usuario);

        Usuarios BuscarPorEmailESenha(string email, string senha);

        void Login(Usuarios usuario);
    }
}
