namespace System.Runtime.Remoting.Messaging;

[CLSCompliant(False)]
[ComVisible(True)]
public class MethodCall : IMethodCallMessage, IMethodMessage, IMessage, ISerializable, IInternalMessage
{
	private string _uri; //Field offset: 0x10
	private string _typeName; //Field offset: 0x18
	private string _methodName; //Field offset: 0x20
	private Object[] _args; //Field offset: 0x28
	private Type[] _methodSignature; //Field offset: 0x30
	private MethodBase _methodBase; //Field offset: 0x38
	private LogicalCallContext _callContext; //Field offset: 0x40
	private Identity _targetIdentity; //Field offset: 0x48
	private Type[] _genericArguments; //Field offset: 0x50
	protected IDictionary ExternalProperties; //Field offset: 0x58
	protected IDictionary InternalProperties; //Field offset: 0x60

	public override int ArgCount
	{
		 get { } //Length: 28
	}

	public override Object[] Args
	{
		 get { } //Length: 8
	}

	private Type[] GenericArguments
	{
		private get { } //Length: 84
	}

	public override LogicalCallContext LogicalCallContext
	{
		 get { } //Length: 112
	}

	public override MethodBase MethodBase
	{
		 get { } //Length: 48
	}

	public override string MethodName
	{
		 get { } //Length: 72
	}

	public override object MethodSignature
	{
		 get { } //Length: 328
	}

	public override IDictionary Properties
	{
		 get { } //Length: 48
	}

	private override Identity System.Runtime.Remoting.Messaging.IInternalMessage.TargetIdentity
	{
		private get { } //Length: 8
		private set { } //Length: 8
	}

	private override string System.Runtime.Remoting.Messaging.IInternalMessage.Uri
	{
		private get { } //Length: 8
		private set { } //Length: 8
	}

	public override string TypeName
	{
		 get { } //Length: 92
	}

	public override string Uri
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	internal MethodCall(SerializationInfo info, StreamingContext context) { }

	internal MethodCall(CADMethodCallMessage msg) { }

	internal MethodCall() { }

	private Type CastTo(string clientType, Type serverType) { }

	internal void CopyFrom(IMethodMessage call) { }

	public override int get_ArgCount() { }

	public override Object[] get_Args() { }

	private Type[] get_GenericArguments() { }

	public override LogicalCallContext get_LogicalCallContext() { }

	public override MethodBase get_MethodBase() { }

	public override string get_MethodName() { }

	public override object get_MethodSignature() { }

	public override IDictionary get_Properties() { }

	public override string get_TypeName() { }

	public override string get_Uri() { }

	public override object GetArg(int argNum) { }

	public override void GetObjectData(SerializationInfo info, StreamingContext context) { }

	private static string GetTypeNameFromAssemblyQualifiedName(string aqname) { }

	public override void Init() { }

	internal override void InitDictionary() { }

	internal override void InitMethodProperty(string key, object value) { }

	public void ResolveMethod() { }

	public void set_Uri(string value) { }

	private override Identity System.Runtime.Remoting.Messaging.IInternalMessage.get_TargetIdentity() { }

	private override string System.Runtime.Remoting.Messaging.IInternalMessage.get_Uri() { }

	private override void System.Runtime.Remoting.Messaging.IInternalMessage.set_TargetIdentity(Identity value) { }

	private override void System.Runtime.Remoting.Messaging.IInternalMessage.set_Uri(string value) { }

}

