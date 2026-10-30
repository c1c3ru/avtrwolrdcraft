namespace UnityEngine.ResourceManagement.Util;

[ExecuteInEditMode]
public abstract class ComponentSingleton : MonoBehaviour
{
	private static T s_Instance; //Field offset: 0x0

	public static bool Exists
	{
		 get { } //Length: 140
	}

	public static T Instance
	{
		 get { } //Length: 352
	}

	protected ComponentSingleton`1() { }

	private void Awake() { }

	private static T CreateNewSingleton() { }

	public static void DestroySingleton() { }

	private static T FindInstance() { }

	public static bool get_Exists() { }

	public static T get_Instance() { }

	protected override string GetGameObjectName() { }

}

