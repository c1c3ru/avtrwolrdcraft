namespace UnityEngine;

public class WaitForSecondsRealtime : CustomYieldInstruction
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private float <waitTime>k__BackingField; //Field offset: 0x10
	private float m_WaitUntilTime; //Field offset: 0x14

	public virtual bool keepWaiting
	{
		 get { } //Length: 156
	}

	public float waitTime
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public WaitForSecondsRealtime(float time) { }

	public virtual bool get_keepWaiting() { }

	[CompilerGenerated]
	public float get_waitTime() { }

	public virtual void Reset() { }

	[CompilerGenerated]
	public void set_waitTime(float value) { }

}

