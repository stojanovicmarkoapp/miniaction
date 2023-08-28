using Miniaction.Application.Tracking;
using Miniaction.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Application.UseCaseHandling
{
    public class QueryHandler : IQueryHandler
    {
        private IApplicationActor _actor;
        private IUseCaseTracker _tracker;
        public QueryHandler(IApplicationActor actor, IUseCaseTracker tracker)
        {
            _actor = actor;
            _tracker = tracker;
        }
        public TResult HandleQuery<TSearch, TResult>(IQuery<TSearch, TResult> query, TSearch search)
            where TResult : class
        {
            if (!_actor.UseCaseIDs.Contains(query.ID))
            {
                throw new UnauthorizedAccessException();
            }
            _tracker.Add(new UseCaseTrackEntry
            {
                ActorID = _actor.ID,
                ActorUsername = _actor.Username,
                Data = search,
                UseCaseName = query.Name
            });
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var result = query.Execute(search);
            stopwatch.Stop();
            Console.WriteLine("Execution time: " + stopwatch.ElapsedMilliseconds + " milliseconds\nUseCase: " + query.Name + "\nPerformed by: " + _actor.Username);
            return result;
        }
    }
}
