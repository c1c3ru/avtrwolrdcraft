namespace SimpleEasing;

public abstract class UnitySingleton : MonoBehaviour
{
	private static T _instance; //Field offset: 0x0

	public static bool HasInstance
	{
		 get { } //Length: 48
	}

	public static T instance
	{
		 get { } //Length: 1124
	}

	public static bool IsDestroyed
	{
		 get { } //Length: 140
	}

	protected UnitySingleton`1() { }

	public static bool get_HasInstance() { }

	public static T get_instance() { }

	public static bool get_IsDestroyed() { }

	protected void OnApplicationQuit() { }

	protected override void OnDestroy() { }

	protected override void onDestruction() { }

}

