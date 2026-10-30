namespace UnityEngine.Android;

public struct Permission
{
	private static AndroidJavaObject m_UnityPermissions; //Field offset: 0x0

	private static AndroidJavaObject GetUnityPermissions() { }

	public static bool HasUserAuthorizedPermission(string permission) { }

	public static void RequestUserPermissions(String[] permissions, PermissionCallbacks callbacks) { }

}

