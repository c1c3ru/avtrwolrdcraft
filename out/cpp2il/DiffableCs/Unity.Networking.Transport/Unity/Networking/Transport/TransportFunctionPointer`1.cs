namespace Unity.Networking.Transport;

public struct TransportFunctionPointer
{
	public readonly FunctionPointer<T> Ptr; //Field offset: 0x0

	public TransportFunctionPointer`1(T executeDelegate) { }

	public TransportFunctionPointer`1(FunctionPointer<T> Pointer) { }

	public static TransportFunctionPointer<T> Burst(T burstCompilableDelegate) { }

	public static TransportFunctionPointer<T> Managed(T managedDelegate) { }

}

