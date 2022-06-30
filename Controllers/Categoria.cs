using Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Controllers
{
    public class CategoriaController
    {
        public static Categoria IncluirCategoria(
            string Nome,
            string Descricao
        )
        {
            if (String.IsNullOrEmpty(Nome))
            {
                throw new Exception("O nome é obrigatório.");
            }

            return new Categoria(Nome, Descricao);
        }

        public static Categoria AlterarCategoria(
            int Id,
            string Nome,
            string Descricao
        )
        {
            Categoria categoria = Categoria.GetCategoria(Id);

            if (!String.IsNullOrEmpty(Nome))
            {
                categoria.Nome = Nome;
            }

            if (!String.IsNullOrEmpty(Descricao))
            {
                categoria.Descricao = Descricao;
            }

            if (categoria == null)
            {
                throw new Exception("Categoria não encontrada.");
            }

            Models.Categoria.AlterarCategoria(Id, Nome, Descricao);
            return categoria;
        }

        public static Categoria RemoverCategoria(
            int Id
        )
        {
            Categoria categoria = Categoria.GetCategoria(Id);
            Categoria.RemoverCategoria(categoria);

            if (categoria == null)
            {
                throw new Exception("Categoria não encontrada.");
            }

            return categoria;
        }

        public static Categoria GetCategoria(
           int Id
       )
        {
            Categoria categoria = (
                from Categoria in Categoria.GetCategorias()
                where Categoria.Id == Id
                select Categoria
            ).First();

            if (categoria == null)
            {
                throw new Exception("Categoria não encontrada");
            }

            return categoria;
        }

        public static IEnumerable<Categoria> GetCategorias()
        {
            return Categoria.GetCategorias();
        }
    }
}