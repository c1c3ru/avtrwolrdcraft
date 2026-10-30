namespace Unity.Profiling;

[IsReadOnly]
public struct ProfilerMarker
{
	[IsReadOnly]
	internal struct AutoScope : IDisposable
	{

		internal AutoScope(ProfilerMarker<TP1, TP2> marker, TP1 p1, TP2 p2) { }

		public override void Dispose() { }

	}


	public ProfilerMarker`2(string name, string param1Name, string param2Name) { }

	public ProfilerMarker`2(ProfilerCategory category, string name, string param1Name, string param2Name) { }

	public AutoScope<TP1, TP2> Auto(TP1 p1, TP2 p2) { }

	[Conditional("ENABLE_PROFILER")]
	public void Begin(TP1 p1, TP2 p2) { }

	[Conditional("ENABLE_PROFILER")]
	public void End() { }

}

