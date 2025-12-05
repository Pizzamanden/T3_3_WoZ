namespace WoZ;
static class Flags
{
    static private Dictionary<string, bool> flagdict = new Dictionary<string, bool>();
    public const string D_S2_Combat_dead = "D_S2_combat";
    public const string D_S4_Combat_dead = "D_S4_combat";
    public const string D_S6_Combat_dead = "D_S6_combat";

    // Flag for items
    public const string Got_Sword = "Got_Sword";
    public const string Got_Bins = "Got_Bin";
    public const string Got_Chemicals = "Got_Chemicals";
    public const string Got_Lighter = "Got_Lighter";

    // Flags for mall zone
    public const string M_S3_Pickup_Barbie = "M_S3";
    public const string M_S4_Combat_dead = "M_S4_combat";
    public const string M_S6_Combat_dead = "M_S6_combat";

    // Flags for starter zone
    public const string S_S6_BOSS_1_Dead = "S_S6_BOSS_1_Dead";
    public const string S_S6_BOSS_2_Dead = "S_S6_BOSS_2_Dead";
    public const string S_S6_BOSS_3_Dead = "S_S6_BOSS_3_Dead";
    public const string S_S6_BOSS_4_Dead = "S_S6_BOSS_4_Dead";

    // Flags for City zone
    public const string C_S4_Monster_Dead = "C_S4_Monster_Dead";
    public const string C_S4_LighterFluid_Pickup = "C_S4_LighterFluid_Pickup"; // Needed for explosions
    public const string C_S6_Monster_Dead = "C_S6_Monster_Dead";
    public const string C_S1_MiniBoss_Boss_Dead = "C_S1_MiniBoss_Boss_Dead";
    public const string Key_1_Pickup = "Key_1_Pickup";

    static Flags(){
        // Attacks flags
        flagdict.Add(Got_Sword, false);
        flagdict.Add(Got_Bins, false);
        flagdict.Add(Got_Chemicals, false);
        flagdict.Add(Got_Lighter, false);
        // Docks zone flags
        flagdict.Add(D_S2_Combat_dead, false);
        flagdict.Add(D_S4_Combat_dead, false);
        flagdict.Add(D_S6_Combat_dead, false);
        // Starter zone flags
        flagdict.Add(S_S6_BOSS_1_Dead, false);
        flagdict.Add(S_S6_BOSS_2_Dead, false);
        flagdict.Add(S_S6_BOSS_3_Dead, false);
        flagdict.Add(S_S6_BOSS_4_Dead, false);
        // City zone flags
        flagdict.Add(C_S4_Monster_Dead, false);
        flagdict.Add(C_S4_LighterFluid_Pickup, false);
        flagdict.Add(C_S6_Monster_Dead, false);
        flagdict.Add(C_S1_MiniBoss_Boss_Dead, false);
        flagdict.Add(Key_1_Pickup, false);
        // Mall zone flags
        flagdict.Add(M_S3_Pickup_Barbie, false);
        flagdict.Add(M_S4_Combat_dead, false);
        flagdict.Add(M_S6_Combat_dead, false);
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