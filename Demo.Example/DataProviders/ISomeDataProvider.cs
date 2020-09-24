using Demo.Example.Model.DTOs;
using System.Threading.Tasks;

namespace Demo.Example.DataProviders
{
    public interface ISomeDataProvider
    {
        Task<SourceData> FindData();
    }
}
