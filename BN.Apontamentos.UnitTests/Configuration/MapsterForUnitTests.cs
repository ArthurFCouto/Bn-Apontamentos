using Mapster;
using MapsterMapper;

namespace BN.Apontamentos.UnitTests.Extensions
{
    public static class MapsterForUnitTests
    {
        public static Mapper GetMapper<T>()
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(typeof(T).Assembly);

            return new Mapper(config);
        }
    }
}
