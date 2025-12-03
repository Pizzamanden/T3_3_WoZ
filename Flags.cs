namespace WoZ;
using WoZ;
static class Flags
{
    static private Dictionary<string, bool> flagdict = new Dictionary<string, bool>();
    public const string D_S2_Combat_dead = "D_S2_combat";
    public const string D_S4_combat_dead = "D_S4_combat";
    public const string D_S6_combat_dead = "D_S6_combat";

    static Flags(){
        flagdict.Add(D_S2_Combat_dead, false);
        flagdict.Add(D_S4_combat_dead, false);
        flagdict.Add(D_S6_combat_dead, false);
    }

    /*
    Mikkel: Checks if a flag is true or false
    returns true: if flag exists AND is true
    returns false: if flag does not exist OR is false
    */
    static public bool GetFlag (string name){
        if (flagdict.ContainsKey(name)){
            return flagdict[name];
        }
        return false;
    }

    /*
    Mikkel: Set a flag with the given name to true (by default)
    returns true: if flags value has been updated
    returns false: if flag does not exist
    */
    static public bool SetFlag (string name, bool value = true){
        if (flagdict.ContainsKey(name)){
            flagdict[name] = value;
            return true;
        }
        return false;
    }
}