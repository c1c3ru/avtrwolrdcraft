namespace System.Runtime.Remoting.Messaging;

internal class IllogicalCallContext
{
	private Hashtable m_Datastore; //Field offset: 0x10
	private object m_HostContext; //Field offset: 0x18

	private Hashtable Datastore
	{
		private get { } //Length: 112
	}

	internal bool HasUserData
	{
		internal get { } //Length: 44
	}

	internal object HostContext
	{
		internal get { } //Length: 8
		internal set { } //Length: 8
	}

	public IllogicalCallContext() { }

	public IllogicalCallContext CreateCopy() { }

	public void FreeNamedDataSlot(string name) { }

	private Hashtable get_Datastore() { }

	internal bool get_HasUserData() { }

	internal object get_HostContext() { }

	internal void set_HostContext(object value) { }

}

