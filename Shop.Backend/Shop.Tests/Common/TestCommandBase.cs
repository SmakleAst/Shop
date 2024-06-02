using Shop.Persistence;

namespace Shop.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly ShopDbContext Context;

        public TestCommandBase()
        {
            Context = ShopContextFactory.Create();
        }

        public void Dispose()
        {
            ShopContextFactory.Destroy(Context);
        }
    }
}
