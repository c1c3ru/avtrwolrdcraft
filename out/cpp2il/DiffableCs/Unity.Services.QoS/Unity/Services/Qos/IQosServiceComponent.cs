namespace Unity.Services.Qos;

public interface IQosServiceComponent : IServiceComponent
{

	public IQosService Service
	{
		 get { } //Length: 0
	}

	public IQosService get_Service() { }

}

