/* Command interface
 */
namespace WoZ.Interfaces;
using WoZ;
interface ICommand {
  void Execute (Context context, string command, string[] parameters);
  string GetDescription ();
}

