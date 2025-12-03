/*
	A class which symbolizes attacks.
*/
namespace WoZ;
using WoZ;

public class Attack{
	public string Name { get;}
	public int Damage { get;}
	public string Type { get;}
	
	public Attack(string name, int damage, string type){
		this.Name = name;
		this.Damage = damage;
		this.Type = type;
	}
}