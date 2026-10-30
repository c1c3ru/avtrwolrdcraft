namespace Unity.MemoryProfiler;

public abstract class MetadataCollect : IDisposable
{
	private bool disposed; //Field offset: 0x10

	protected MetadataCollect() { }

	public abstract void CollectMetadata(MemorySnapshotMetadata data) { }

	public override void Dispose() { }

}

