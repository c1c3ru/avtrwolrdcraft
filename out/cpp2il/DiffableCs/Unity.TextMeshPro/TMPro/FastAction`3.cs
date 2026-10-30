namespace TMPro;

public class FastAction
{
	private LinkedList<Action`3<A, B, C>> delegates; //Field offset: 0x0
	private Dictionary<Action`3<A, B, C>, LinkedListNode`1<Action`3<A, B, C>>> lookup; //Field offset: 0x0

	public FastAction`3() { }

	public void Add(Action<A, B, C> rhs) { }

	public void Call(A a, B b, C c) { }

	public void Remove(Action<A, B, C> rhs) { }

}

