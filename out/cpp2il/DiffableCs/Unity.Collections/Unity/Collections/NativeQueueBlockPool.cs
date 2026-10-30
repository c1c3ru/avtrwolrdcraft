namespace Unity.Collections;

internal class NativeQueueBlockPool
{
	private static readonly SharedStatic<IntPtr> Data; //Field offset: 0x0

	private static NativeQueueBlockPool() { }

	public NativeQueueBlockPool() { }

	[BurstDiscard]
	private static void AppDomainOnDomainUnload() { }

	internal static NativeQueueBlockPoolData* GetQueueBlockPool() { }

	private static void OnDomainUnload(object sender, EventArgs e) { }

}

