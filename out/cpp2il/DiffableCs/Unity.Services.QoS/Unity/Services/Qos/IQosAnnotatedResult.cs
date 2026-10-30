namespace Unity.Services.Qos;

public interface IQosAnnotatedResult : IQosResult
{

	public Dictionary<String, List`1<String>> Annotations
	{
		 get { } //Length: 0
	}

	public Dictionary<String, List`1<String>> get_Annotations() { }

}

