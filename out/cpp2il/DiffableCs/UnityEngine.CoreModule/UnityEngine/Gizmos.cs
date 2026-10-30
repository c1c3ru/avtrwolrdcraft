namespace UnityEngine;

[NativeHeader("Runtime/Export/Gizmos/Gizmos.bindings.h")]
[StaticAccessor("GizmoBindings", StaticAccessorType::DoubleColon (2))]
public sealed class Gizmos
{

	public static Color color
	{
		 get { } //Length: 72
		 set { } //Length: 68
	}

	[NativeThrows]
	public static void DrawLine(Vector3 from, Vector3 to) { }

	private static void DrawLine_Injected(ref Vector3 from, ref Vector3 to) { }

	public static Color get_color() { }

	private static void get_color_Injected(out Color ret) { }

	public static void set_color(Color value) { }

	private static void set_color_Injected(ref Color value) { }

}

