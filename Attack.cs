/*
	A class which symbolizes attacks.
*/
namespace WoZ;

public class Attack{
	public string Name { get;}
	public int MinDamage { get;}
	public int MaxDamage { get;}
	public string Type { get;}
	
	public Attack(string name, int minDamage, int maxDamage, string type){
		this.Name = name;
		this.MinDamage = minDamage;
		this.MaxDamage = maxDamage;
		this.Type = type;
	}
}