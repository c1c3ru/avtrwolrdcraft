namespace Unity.Services.Wire.Internal;

internal interface IBackoffStrategy
{

	public float GetNext() { }

	public void Reset() { }

}

