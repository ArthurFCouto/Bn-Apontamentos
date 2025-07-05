namespace BN.Apontamentos.API.Extensions
{
    public static class StringExtensions
    {
        public static string AddDynamicParams(
             this string parametro,
             string clausula)
        {
            return !string.IsNullOrWhiteSpace(parametro) ?
                clausula :
                string.Empty;
        }
    }
}
