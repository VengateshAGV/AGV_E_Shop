

using Shop.ModelArea.Models;

namespace Application.Contract.Presistence
{
    public interface IBrandModelRepositry : IGenaricRepositry<BrandModel>
    {
        Task Update(BrandModel brandModel);

        Task<BrandModel> GetBrandPostById(Guid id);

        Task<List<BrandModel>> GetAllBrandModels();

        Task<List<BrandModel>> GetAllModels(Guid? SkipRecord, Guid? brandId);

        Task<List<BrandModel>> GetAllModels(string? searchName, Guid? brandId, Guid? modelTypeId);
    }
}
