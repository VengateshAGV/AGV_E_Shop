

using Shop.ModelArea.Models;

namespace Application.Contract.Presistence
{
    public interface IBrandRepositry : IGenaricRepositry<Brand>
    {
        Task Update(Brand brand);

        Task<Brand> GetBrandById(Guid id);

        Task<List<Brand>> GetAllBrand();
    }
}
