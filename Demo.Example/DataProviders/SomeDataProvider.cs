using Demo.Example.Model.DTOs;
using System.Threading.Tasks;

namespace Demo.Example.DataProviders
{
    sealed class SomeDataProvider : ISomeDataProvider
    {
        public Task<SourceData> FindData()
        {
            throw new System.NotImplementedException();
        }
    }
}
