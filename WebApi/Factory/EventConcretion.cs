using Accounts.Project.ViewModel;
using System.Threading.Tasks;

namespace Accounts.Project.Factory
{
    public abstract class EventConcretion
    {
        public abstract Task<string> ExecuteEvent(Event eventModel);
    }
}
