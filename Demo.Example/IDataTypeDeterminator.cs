using Demo.Example.Model;
using Demo.Example.Model.DTOs;

namespace Demo.Example
{
    public interface IDataHandlerDeterminator
    {
        HandlerType GetHandlerType(SourceData sourceData);
    }
}
