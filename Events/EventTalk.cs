/*
	An event which can talk to an NPC in the given space
*/
class EventTalk : IEvent{
	
	private Space space;
	
	public EventTalk(Space space){
		this.space = space;
	}
	
	public void Trigger(){
		if(space.HasNPC() == true){
			space.GetNPC().Talk();
		}
	}
}