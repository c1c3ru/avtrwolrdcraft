namespace Unity.Services.Qos.Runner;

internal interface IQosJob : IJob
{

	public NativeArray<InternalQosResult> QosResults
	{
		 get { } //Length: 0
	}

	public void Dispose() { }

	public NativeArray<InternalQosResult> get_QosResults() { }

	public JobHandle Schedule(JobHandle dependsOn = null) { }

}

