/* Command interface
 */
namespace WoZ.Interfaces;
interface ICommand {
  void Execute (Context context, string command, string[] parameters);
  string GetDescription ();
}

