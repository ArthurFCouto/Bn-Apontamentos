namespace BN.Apontamentos.Application.Extensions
{
    public static class NumbersExtensions
    {
        public static string AddDynamicParams(
             this int? parametro,
             string clausula)
        {
            return parametro.HasValue && parametro > 0 ?
                clausula :
                string.Empty;
        }
    }
}
