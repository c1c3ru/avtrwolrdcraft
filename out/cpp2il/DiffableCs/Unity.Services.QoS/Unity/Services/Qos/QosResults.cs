namespace Unity.Services.Qos;

internal class QosResults : IQosResults, IServiceComponent
{
	private WrappedQosService _qosService; //Field offset: 0x10

	internal QosResults(WrappedQosService qosService) { }

	public override Task<IList`1<QosResult>> GetSortedQosResultsAsync(string service, IList<String> regions) { }

}

