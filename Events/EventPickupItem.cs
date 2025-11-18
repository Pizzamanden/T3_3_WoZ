/*
	An event which can talk to an NPC in the given space
*/
class EventPickupItem : IEvent{
	
	private Context context;
	private Registry registry;
	private string[] itemName = new string[1];
	
	public EventPickupItem(Context context, Registry registry, string itemName){
		this.context = context;
		this.registry = registry;
		this.itemName[0] = itemName;
	}
	
	public void Trigger(){
		registry.GetCommand(CommandNames.CommandPickup).Execute(context, CommandNames.CommandPickup, itemName);
	}
}