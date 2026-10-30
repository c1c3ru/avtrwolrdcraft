namespace UnityEngine.ResourceManagement.Profiling;

internal interface IProfilerEmitter
{

	public bool IsEnabled
	{
		 get { } //Length: 0
	}

	public void EmitFrameMetaData(Guid id, int tag, Array data) { }

	public bool get_IsEnabled() { }

	public void InitialiseCallbacks(Action<Single> onLateUpdateDelegate) { }

}

