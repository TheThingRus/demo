using Demo.Example.Model;
using Demo.Example.Model.DTOs;

namespace Demo.Example.Handlers
{
    public interface IHandler
    {
        HandleResult Handle(SourceData sourceData);
    }
}
