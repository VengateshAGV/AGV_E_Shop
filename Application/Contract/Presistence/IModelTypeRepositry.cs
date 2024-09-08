

using Shop.ModelArea.Models;

namespace Application.Contract.Presistence
{
    public interface IModelTypeRepositry : IGenaricRepositry<ModelType>
    {
        Task Update(ModelType modelType);

        Task<ModelType> GetModelTypeById(Guid id);

        Task<List<ModelType>> GetAllModelsType();
    }
}
