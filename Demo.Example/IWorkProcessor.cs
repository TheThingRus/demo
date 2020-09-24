using Demo.Example.Model;
using Demo.Example.Model.DTOs;
using System.Threading.Tasks;

namespace Demo.Example
{
    public interface IWorkProcessor
    {
        Task<HandleResult> Process();
    }
}
