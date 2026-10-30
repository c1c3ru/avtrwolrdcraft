namespace Unity.Services.Qos.Runner;

internal sealed class QosJobProvider : MulticastDelegate
{

	public QosJobProvider(object object, IntPtr method) { }

	public override IAsyncResult BeginInvoke(IList<UcgQosServer> servers, string title, AsyncCallback callback, object object) { }

	public override IQosJob EndInvoke(IAsyncResult result) { }

	public override IQosJob Invoke(IList<UcgQosServer> servers, string title) { }

}

