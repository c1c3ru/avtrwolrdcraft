namespace Unity.Services.Qos.Runner;

internal sealed class DnsResolver : MulticastDelegate
{

	public DnsResolver(object object, IntPtr method) { }

	public override IAsyncResult BeginInvoke(string host, AsyncCallback callback, object object) { }

	public override Task<IPAddress[]> EndInvoke(IAsyncResult result) { }

	public override Task<IPAddress[]> Invoke(string host) { }

}

