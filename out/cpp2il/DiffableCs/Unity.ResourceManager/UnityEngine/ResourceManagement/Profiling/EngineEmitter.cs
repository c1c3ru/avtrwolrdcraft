namespace UnityEngine.ResourceManagement.Profiling;

public class EngineEmitter : IProfilerEmitter
{

	public override bool IsEnabled
	{
		 get { } //Length: 8
	}

	public EngineEmitter() { }

	public override void EmitFrameMetaData(Guid id, int tag, Array data) { }

	public override bool get_IsEnabled() { }

	public override void InitialiseCallbacks(Action<Single> d) { }

}

