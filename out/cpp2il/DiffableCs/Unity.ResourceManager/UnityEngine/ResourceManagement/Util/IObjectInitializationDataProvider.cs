namespace UnityEngine.ResourceManagement.Util;

public interface IObjectInitializationDataProvider
{

	public string Name
	{
		 get { } //Length: 0
	}

	public ObjectInitializationData CreateObjectInitializationData() { }

	public string get_Name() { }

}

