namespace WoZ.Interfaces;
interface IEvent{
	void Trigger();
	bool CanRun();
}