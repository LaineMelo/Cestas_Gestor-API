namespace gestor_cestas_api.Models
{
    public interface ILinkGenerator
    {

        void GerarLinks(Beneficiario beneficiario);
        void GerarLinks(Voluntario beneficiario);
        public class NullLinkGenerator : ILinkGenerator
        {
            public void GerarLinks(Beneficiario beneficiario)
            {
                // Não faz nada durante os testes
            }
            public void GerarLinks(Voluntario voluntario)
            {
                // Não faz nada durante os testes
            }
        }

    }
}
