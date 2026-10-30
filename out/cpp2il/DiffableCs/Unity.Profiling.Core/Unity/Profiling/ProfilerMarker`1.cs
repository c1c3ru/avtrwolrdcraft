namespace Unity.Profiling;

[IsReadOnly]
public struct ProfilerMarker
{
	[IsReadOnly]
	internal struct AutoScope : IDisposable
	{

		internal AutoScope(ProfilerMarker<TP1> marker, TP1 p1) { }

		public override void Dispose() { }

	}


	public ProfilerMarker`1(string name, string param1Name) { }

	public ProfilerMarker`1(ProfilerCategory category, string name, string param1Name) { }

	public AutoScope<TP1> Auto(TP1 p1) { }

	[Conditional("ENABLE_PROFILER")]
	public void Begin(TP1 p1) { }

	[Conditional("ENABLE_PROFILER")]
	public void End() { }

}

