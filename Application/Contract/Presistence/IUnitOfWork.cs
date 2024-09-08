

namespace Application.Contract.Presistence
{
    public interface IUnitOfWork : IDisposable
    {
        public IBrandRepositry Brand {  get; }

        public IBrandTypeRepositry BrandType { get; }

        

        public IBrandModelRepositry Models { get; }

        public IModelTypeRepositry ModelType { get; }

        Task SaveAsync();
    }
}
