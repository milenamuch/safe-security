using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Controllers
{
    public class SenhaTagController
    {
        public static SenhaTag InserirSenhaTag(
            int TagId,
            int SenhaId
        )
        {
            TagController.GetTag(TagId);
            SenhaController.GetSenha(SenhaId);

            return new SenhaTag(TagId, SenhaId);
        }

        public static SenhaTag GetSenhaTag(
            int SenhaId,
            int TagId
        )
        {
            return SenhaTag.GetSenhaTag(SenhaId, TagId);
        }


        public static SenhaTag GetById(
            int Id
        )  
        {
            try
            {
                 SenhaTag senhaTag = SenhaTag.GetById(Id);
                SenhaTag.RemoverSenhaTag(senhaTag);
            }
            catch
            {
                throw new Exception("Não encontrado.");
            }
            return SenhaTag.GetById(Id);
        }

        public static void ExcluirSenhaTag(
            int Id
        )
        {
            try
            {
                SenhaTag senhaTag = SenhaTag.GetById(Id);
                SenhaTag.RemoverSenhaTag(senhaTag);
            }
            catch
            {
                throw new Exception(
                    "Não foi possível excluir a Tag de Senha "
                    + "pois o ID não existe"
                );
            }
        }
    }
}