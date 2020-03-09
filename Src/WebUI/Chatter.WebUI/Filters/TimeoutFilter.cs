using Chatter.WebUI.Infrastructure;
using Chatter.WebUI.Infrastructure.ConfigurationModels;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Chatter.WebUI.Filters
{
    public class TimeoutFilter : Attribute, IAsyncActionFilter
    {
        private int timeoutInterval = 30;

        public TimeoutFilter() { }

        public TimeoutFilter(int timeout) => timeoutInterval = timeout;

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var actionValue = GetMaxQueryTimeFromArguments(context);

            var timeoutTask = CreateTimeoutTask(actionValue);
            var executionTask = next();

            var finishedTask = await Task.WhenAny(executionTask, timeoutTask);

            if (finishedTask == timeoutTask)
                throw new TimeoutException();
        }

        private int GetMaxQueryTimeFromArguments(ActionExecutingContext actionContext)
        {
            var queryModel = actionContext.ActionArguments.Values.FirstOrDefault();
            if (queryModel != null && queryModel is IMaxQueryTime queryTime)
                return queryTime.MaxQueryTime;

            return 0;
        }

        private Task CreateTimeoutTask(int actionValue) => Task.Delay(TimeSpan.FromSeconds(actionValue == 0 ? timeoutInterval : actionValue));
    }
}
