namespace Unity.Services.Qos;

internal class QosServiceComponent : IQosServiceComponent, IServiceComponent
{
	[CompilerGenerated]
	private readonly IQosService <Service>k__BackingField; //Field offset: 0x10

	public override IQosService Service
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	internal QosServiceComponent(IQosService qos) { }

	[CompilerGenerated]
	public override IQosService get_Service() { }

}

