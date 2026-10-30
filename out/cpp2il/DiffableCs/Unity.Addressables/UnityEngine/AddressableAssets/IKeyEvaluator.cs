namespace UnityEngine.AddressableAssets;

public interface IKeyEvaluator
{

	public object RuntimeKey
	{
		 get { } //Length: 0
	}

	public object get_RuntimeKey() { }

	public bool RuntimeKeyIsValid() { }

}

