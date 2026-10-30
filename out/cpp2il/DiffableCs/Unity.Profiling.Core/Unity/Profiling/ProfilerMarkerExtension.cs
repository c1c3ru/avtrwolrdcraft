namespace Unity.Profiling;

[Extension]
public static class ProfilerMarkerExtension
{

	[Conditional("ENABLE_PROFILER")]
	[Extension]
	public static void Begin(ProfilerMarker marker, int metadata) { }

	[Conditional("ENABLE_PROFILER")]
	[Extension]
	public static void Begin(ProfilerMarker marker, uint metadata) { }

	[Conditional("ENABLE_PROFILER")]
	[Extension]
	public static void Begin(ProfilerMarker marker, long metadata) { }

	[Conditional("ENABLE_PROFILER")]
	[Extension]
	public static void Begin(ProfilerMarker marker, ulong metadata) { }

	[Conditional("ENABLE_PROFILER")]
	[Extension]
	public static void Begin(ProfilerMarker marker, float metadata) { }

	[Conditional("ENABLE_PROFILER")]
	[Extension]
	public static void Begin(ProfilerMarker marker, double metadata) { }

	[Conditional("ENABLE_PROFILER")]
	[Extension]
	public static void Begin(ProfilerMarker marker, string metadata) { }

}

