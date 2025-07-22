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

        public static string AddDynamicParamsList<T>(
             this IEnumerable<T> parametro,
             string clausula)
        {
            return parametro.Any() ?
                clausula :
                string.Empty;
        }
    }
}
