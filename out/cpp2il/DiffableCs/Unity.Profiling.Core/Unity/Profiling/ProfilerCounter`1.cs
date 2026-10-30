namespace Unity.Profiling;

[IsReadOnly]
public struct ProfilerCounter
{

	public ProfilerCounter`1(ProfilerCategory category, string name, ProfilerMarkerDataUnit dataUnit) { }

	[Conditional("ENABLE_PROFILER")]
	public void Sample(T value) { }

}

