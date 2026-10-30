namespace Unity.Services.Qos.Runner;

internal interface IQosRunner
{

	public Task<List`1<QosResult>> MeasureQosAsync(IList<QosServer> servers) { }

	public Task<List`1<QosAnnotatedResult>> MeasureQosAsync(IList<QosServiceServer> servers) { }

	public Task<List`1<ValueTuple`2<QosServer, IQosMeasurements>>> MeasureQosV2Async(IList<QosServer> servers) { }

}

