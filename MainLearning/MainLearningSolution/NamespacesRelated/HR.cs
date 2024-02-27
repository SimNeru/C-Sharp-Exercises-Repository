namespace HR
{
    public interface IEmployee
    {
    }

    public class Excecutive : IExecutive
    {
    }

    public interface IExecutive : IEmployee
    {
    }

    //si possono nestare altri namespaces
    namespace Mgr
    {
        public interface IManager : IEmployee
        {
        }

        public class Manager : IManager
        {
        }

        public class AsstManager : IManager
        {
        }
    }
}
