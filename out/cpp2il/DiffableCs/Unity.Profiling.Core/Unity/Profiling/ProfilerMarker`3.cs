namespace Unity.Profiling;

[IsReadOnly]
public struct ProfilerMarker
{
	[IsReadOnly]
	internal struct AutoScope : IDisposable
	{

		internal AutoScope(ProfilerMarker<TP1, TP2, TP3> marker, TP1 p1, TP2 p2, TP3 p3) { }

		public override void Dispose() { }

	}


	public ProfilerMarker`3(string name, string param1Name, string param2Name, string param3Name) { }

	public ProfilerMarker`3(ProfilerCategory category, string name, string param1Name, string param2Name, string param3Name) { }

	public AutoScope<TP1, TP2, TP3> Auto(TP1 p1, TP2 p2, TP3 p3) { }

	[Conditional("ENABLE_PROFILER")]
	public void Begin(TP1 p1, TP2 p2, TP3 p3) { }

	[Conditional("ENABLE_PROFILER")]
	public void End() { }

}

