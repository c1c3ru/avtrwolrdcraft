namespace TMPro;

public class FastAction
{
	private LinkedList<Action`1<A>> delegates; //Field offset: 0x0
	private Dictionary<Action`1<A>, LinkedListNode`1<Action`1<A>>> lookup; //Field offset: 0x0

	public FastAction`1() { }

	public void Add(Action<A> rhs) { }

	public void Call(A a) { }

	public void Remove(Action<A> rhs) { }

}

