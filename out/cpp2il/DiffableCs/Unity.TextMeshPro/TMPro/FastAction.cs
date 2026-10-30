namespace TMPro;

public class FastAction
{
	private LinkedList<Action> delegates; //Field offset: 0x10
	private Dictionary<Action, LinkedListNode`1<Action>> lookup; //Field offset: 0x18

	public FastAction() { }

	public void Add(Action rhs) { }

	public void Call() { }

	public void Remove(Action rhs) { }

}

