namespace WoZ.Commands;
using WoZ;
using WoZ.Interfaces;
class CommandDirections : BaseCommand, ICommand {
    public CommandDirections()
    {
        description = "Get current position and directions";
    }
    public void Execute (Context context, string command, string[] parameters) {
        Space current = context.GetCurrent();
        Space.ExitList(current);
    }
}