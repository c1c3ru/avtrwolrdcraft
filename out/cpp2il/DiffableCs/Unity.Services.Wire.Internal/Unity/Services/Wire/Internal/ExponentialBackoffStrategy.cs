namespace Unity.Services.Wire.Internal;

internal class ExponentialBackoffStrategy : IBackoffStrategy
{
	private const float k_Max = 30; //Field offset: 0x0
	private const float k_Min = 0,1; //Field offset: 0x0
	private int m_Attempt; //Field offset: 0x10
	private float m_Factor; //Field offset: 0x14

	public ExponentialBackoffStrategy() { }

	private float GetDuration(int attempt) { }

	public override float GetNext() { }

	public override void Reset() { }

}

