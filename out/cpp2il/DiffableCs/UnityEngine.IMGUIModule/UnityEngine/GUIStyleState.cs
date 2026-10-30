namespace UnityEngine;

[NativeHeader("Modules/IMGUI/GUIStyle.bindings.h")]
public sealed class GUIStyleState
{
	internal IntPtr m_Ptr; //Field offset: 0x10
	private readonly GUIStyle m_SourceStyle; //Field offset: 0x18

	[NativeProperty("Background", False, TargetType::Function (0))]
	public Texture2D background
	{
		 set { } //Length: 68
	}

	[NativeProperty("textColor", False, TargetType::Field (1))]
	public Color textColor
	{
		 get { } //Length: 88
		 set { } //Length: 84
	}

	public GUIStyleState() { }

	private GUIStyleState(GUIStyle sourceStyle, IntPtr source) { }

	[FreeFunction(Name = "GUIStyleState_Bindings::Cleanup", IsThreadSafe = True, HasExplicitThis = True)]
	private void Cleanup() { }

	protected virtual void Finalize() { }

	public Color get_textColor() { }

	private void get_textColor_Injected(out Color ret) { }

	internal static GUIStyleState GetGUIStyleState(GUIStyle sourceStyle, IntPtr source) { }

	[FreeFunction(Name = "GUIStyleState_Bindings::Init", IsThreadSafe = True)]
	private static IntPtr Init() { }

	public void set_background(Texture2D value) { }

	public void set_textColor(Color value) { }

	private void set_textColor_Injected(ref Color value) { }

}

