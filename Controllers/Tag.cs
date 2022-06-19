using Models;
using System;
using System.Linq;
using System.Collections.Generic;
//using Repository;

namespace Controllers
{
    public class TagController
    {
        public static Tag IncluirTag(
            string Descricao
        )
        {
            if (String.IsNullOrEmpty(Descricao))
            {
                throw new Exception("A descrição é obrigatória.");
            }

            return new Tag(Descricao);
        }

        public static Tag AlterarTag(
            int Id,
            string Descricao
        )
        {
            Tag tag = Tag.GetTag(Id);

            if (!String.IsNullOrEmpty(Descricao))
            {
                tag.Descricao = Descricao;
            }
            tag.Descricao = Descricao;

            return tag;
        }

        public static Tag RemoverTag(
            int Id
        )
        {
            Tag tag = Tag.GetTag(Id);
            Tag.RemoverTag(tag);
            return tag;
        }

         public static Tag GetTag(int Id)
        {
            Tag tag = Tag.GetTag(Id);

            if (tag == null)
            {
                throw new Exception("Tag não encontrada.");
            }

            return tag;
        }

        public static IEnumerable<Tag> GetTags()
        {
            return Tag.GetTags();
        }
    }
}