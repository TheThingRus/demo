using Demo.Example.DataProviders;
using Demo.Example.Exceptions;
using Demo.Example.Handlers;
using Demo.Example.Model;
using Demo.Example.Model.DTOs;
using System;
using System.Threading.Tasks;

namespace Demo.Example
{
    public class SomeWorkProcessor : IWorkProcessor
    {
        private readonly ISomeDataProvider _dataProvider;
        private readonly IHandlerCreator _handlerCreator;
        private readonly IDataHandlerDeterminator _dataHandlerDeterminator;

        public SomeWorkProcessor(
            ISomeDataProvider dataProvider, 
            IHandlerCreator handlerCreator,
            IDataHandlerDeterminator dataHandlerDeterminator)
        {
            _dataProvider = dataProvider ?? throw new ArgumentNullException(nameof(dataProvider));
            _handlerCreator = handlerCreator ?? throw new ArgumentNullException(nameof(handlerCreator));
            _dataHandlerDeterminator = dataHandlerDeterminator ?? throw new ArgumentNullException(nameof(dataHandlerDeterminator));
        }

        public async Task<HandleResult> Process()
        {
            var data = await _dataProvider.FindData();
            var handlerType = _dataHandlerDeterminator.GetHandlerType(data);
            if (_handlerCreator.HasHandler(handlerType))
            {
                throw new UserException("Incorerct source data");
            }
            var handler = _handlerCreator.CreateHandler(handlerType, options: new Handlers.HandlerOptions { });
            return handler.Handle(data);
        }
    }
}
