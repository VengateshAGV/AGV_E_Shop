using Shop.ModelArea.Models;

namespace Application.Contract.Presistence
{
    public interface IBrandTypeRepositry : IGenaricRepositry<BrandType>
    {
        Task Update(BrandType brandType);
    }
}
