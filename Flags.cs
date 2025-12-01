static class Flags
{
    static private Dictionary<string, bool> flagdict = new Dictionary<string, bool>();
    public const string S1_slime_dead = "S1_slime_dead";
    public const string S2_mime_dead = "S2_mime_dead";

    static Flags(){
        flagdict.Add(S1_slime_dead, false);
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