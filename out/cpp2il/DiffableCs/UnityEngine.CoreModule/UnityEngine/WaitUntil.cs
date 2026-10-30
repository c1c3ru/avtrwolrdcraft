namespace UnityEngine;

public sealed class WaitUntil : CustomYieldInstruction
{
	private Func<Boolean> m_Predicate; //Field offset: 0x10

	public virtual bool keepWaiting
	{
		 get { } //Length: 48
	}

	public WaitUntil(Func<Boolean> predicate) { }

	public virtual bool get_keepWaiting() { }

}

