namespace Unity.Profiling;

[IsReadOnly]
public struct ProfilerCounterValue
{

	public T Value
	{
		 get { } //Length: 8
		 set { } //Length: 4
	}

	public ProfilerCounterValue`1(string name) { }

	public ProfilerCounterValue`1(string name, ProfilerMarkerDataUnit dataUnit) { }

	public ProfilerCounterValue`1(string name, ProfilerMarkerDataUnit dataUnit, ProfilerCounterOptions counterOptions) { }

	public ProfilerCounterValue`1(ProfilerCategory category, string name, ProfilerMarkerDataUnit dataUnit) { }

	public ProfilerCounterValue`1(ProfilerCategory category, string name, ProfilerMarkerDataUnit dataUnit, ProfilerCounterOptions counterOptions) { }

	public T get_Value() { }

	[Conditional("ENABLE_PROFILER")]
	public void Sample() { }

	public void set_Value(T value) { }

}

