namespace Unity.Collections;

[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
public struct NativeKeyValueArrays : INativeDisposable, IDisposable
{
	public NativeArray<TKey> Keys; //Field offset: 0x0
	public NativeArray<TValue> Values; //Field offset: 0x0

	public int Length
	{
		 get { } //Length: 8
	}

	public NativeKeyValueArrays`2(int length, AllocatorHandle allocator, NativeArrayOptions options) { }

	public override void Dispose() { }

	[NotBurstCompatible]
	public override JobHandle Dispose(JobHandle inputDeps) { }

	public int get_Length() { }

}

