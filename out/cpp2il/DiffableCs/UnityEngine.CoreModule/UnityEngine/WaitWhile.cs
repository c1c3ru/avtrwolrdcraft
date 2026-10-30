namespace UnityEngine;

public sealed class WaitWhile : CustomYieldInstruction
{
	private Func<Boolean> m_Predicate; //Field offset: 0x10

	public virtual bool keepWaiting
	{
		 get { } //Length: 36
	}

	public WaitWhile(Func<Boolean> predicate) { }

	public virtual bool get_keepWaiting() { }

}

