using Mapster;

namespace Shop.Application.Common.Mappings
{
    public interface IMapWith<T>
    {
        void Mapping(TypeAdapterConfig profile);
    }
}
