namespace Unity.Collections.LowLevel.Unsafe;

[BurstCompatible]
internal struct RingControl
{
	internal readonly int Capacity; //Field offset: 0x0
	internal int Current; //Field offset: 0x4
	internal int Write; //Field offset: 0x8
	internal int Read; //Field offset: 0xC

	internal int Length
	{
		internal get { } //Length: 44
	}

	internal RingControl(int capacity) { }

	internal int Available() { }

	internal int Commit(int count) { }

	internal int Consume(int count) { }

	internal int Distance(int from, int to) { }

	internal int get_Length() { }

	internal int Reserve(int count) { }

	internal void Reset() { }

}

