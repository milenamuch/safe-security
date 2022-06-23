using Models;
using System;
using System.Linq;
using System.Collections.Generic;
//using Repository;
using System.Text.RegularExpressions;

namespace Controllers
{
    public class SenhaController
    {
        public static Senha IncluirSenha(
            string Nome,
            int CategoriaId,
            string Url,
            string Usuario,
            string SenhaEncrypt,
            string Procedimento
        )
        {
            if (String.IsNullOrEmpty(Nome))
            {
                throw new Exception("O nome é obrigatório.");
            }

            if (CategoriaId < 0)
            {
                throw new Exception("O id da categoria é obrigatório.");
            }

            if (String.IsNullOrEmpty(Usuario))
            {
                throw new Exception("O usuário é obrigatório.");
            }

            if (String.IsNullOrEmpty(Url))
            {
                throw new Exception("A url é obrigatória.");
            }

            Regex rx = new Regex(
                "https?:\\/\\/(?:www\\.|(?!www))[a-zA-Z0-9][a-zA-Z0-9-]+"
                + "[a-zA-Z0-9]\\.[^\\s]{2,}|www\\.[a-zA-Z0-9][a-zA-Z0-9-]+"
                + "[a-zA-Z0-9]\\.[^\\s]{2,}|https?:\\/\\/(?:www\\.|(?!www))"
                + "[a-zA-Z0-9]+\\.[^\\s]{2,}|www\\.[a-zA-Z0-9]+\\.[^\\s]{2,}"
            );

            if (String.IsNullOrEmpty(Url) || !rx.IsMatch(Url))
            {
                throw new Exception("A url é inválida.");
            }

            if (String.IsNullOrEmpty(SenhaEncrypt))
            {
                throw new Exception("A senha é obrigatória.");
            }

             if (SenhaEncrypt.Length < 8) {
                throw new Exception("A senha deve ter no mínimo 8 caracteres.");
            }

            return new Senha(
                Nome,
                CategoriaId,
                Url,
                Usuario,
                SenhaEncrypt,
                Procedimento
            );
        }

        public static Senha AlterarSenha(
            int Id,
            string Nome,
            int CategoriaId,
            string Url,
            string Usuario,
            string SenhaEncrypt,
            string Procedimento
        )
        {
            Senha senha = Senha.GetSenha(Id);

            if (!String.IsNullOrEmpty(Nome))
            {
                senha.Nome = Nome;
            }
            senha.Nome = Nome;

            if (CategoriaId > 0)
            {
                senha.CategoriaId = CategoriaId;
            }
            senha.CategoriaId = CategoriaId;

            if (!String.IsNullOrEmpty(Url))
            {
                senha.Url = Url;
            }
            senha.Url = Url;

            if (!String.IsNullOrEmpty(Usuario))
            {
                senha.Usuario = Usuario;
            }
            senha.Usuario = Usuario;

            if (!String.IsNullOrEmpty(SenhaEncrypt))
            {
                senha.SenhaEncrypt = SenhaEncrypt;
            }
            senha.SenhaEncrypt = SenhaEncrypt;
            senha.Procedimento = Procedimento;

            Models.Senha.AlterarSenha(
            Id,
            Nome,
            CategoriaId,
            Url,
            Usuario,
            SenhaEncrypt,
            Procedimento);

            return senha;
        }

        public static Senha RemoverSenha(
            int Id
        )
        {
            Senha senha = Senha.GetSenha(Id);
            Senha.RemoverSenha(senha);
            return senha;
        }

         public static Senha GetSenha(int Id)
        {
            Senha senha = Senha.GetSenha(Id);

            if (senha == null)
            {
                throw new Exception("Senha não encontrada.");
            }

            return senha;
        }

        public static IEnumerable<Senha> GetSenhas()
        {
            return Senha.GetSenhas();
        }
    }
}