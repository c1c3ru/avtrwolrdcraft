namespace Unity.MemoryProfiler;

internal class DefaultMetadataCollect : MetadataCollect
{

	public DefaultMetadataCollect() { }

	public virtual void CollectMetadata(MemorySnapshotMetadata data) { }

	private string FormatSecondsToTime(double timeInSeconds) { }

}

