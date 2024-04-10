using System.ComponentModel;

namespace TaskSystem.Enums
{
    public enum TaskStatus
    {
        [Description("To do")]
        Todo = 1,
        [Description("Finished")]
        Finished = 2,
    }
}
