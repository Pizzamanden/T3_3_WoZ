/* Space class for modeling spaces (rooms, caves, ...)
*/

class Space : Node {
	private NPC? npc;

	public Space (String name) : base(name)
	{
			
	}

	public void Welcome () {
		Console.WriteLine("You are now at "+name);
		HashSet<string> exits = edges.Keys.ToHashSet();
		Console.WriteLine("Current exits are:");
		foreach (String exit in exits) {
		Console.WriteLine(" - "+exit);
		}
	}

	public void Goodbye () {
	}

	public override Space FollowEdge(string direction)
	{
		return (Space)(base.FollowEdge(direction));
	}

	public void PlaceNPC(NPC npc)
	{
		this.npc = npc;
	}
		public bool NPCCheck()
	{
		return npc != null;
	}

	//Magnus: returns the item without removing it
	public NPC? GetNPC()
	{
		return npc;
	}
}
