// Dummy template
using System.Text;
class EventDummy : IEvent{
	
	// Method which does the events intended behavior
	public void Trigger(){
		Console.WriteLine("Dummy event");
	}
}