namespace Alura.Adopet.Console.Commands
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CommandDocAttribute : Attribute
    {
        public string Command { get; set; }
        public string Documentation { get; set; }

        public CommandDocAttribute(string command, string documentation)
        {
            Command = command;
            Documentation = documentation;
        }
    }
}
