using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.VariantTypes.Models;
using IkasAdminApiLibrary.Api.VariantTypes.Models.Inputs;

namespace IkasAdminApiLibrary.Api.VariantTypes.Abstracts
{
    public interface IVariantTypeManager
    {
        public Task<IResult<List<VariantType>>> List(ListVariantTypeInput? input = null);

        public Task<IResult<VariantType>> Save(VariantTypeInput variantTypeInput);
    }
}
