using Something.Domain.Models;

namespace Something.Application
{
    public interface ISomethingElseUpdateInteractor
    {
        SomethingElse UpdateSomethingElseAddSomething(int id, string name);
    }
}