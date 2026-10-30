namespace PazuCore;

public abstract class Window : MonoBehaviour
{
	[CompilerGenerated]
	private static Action<Window> OnWindowOpenEvent; //Field offset: 0x0
	[CompilerGenerated]
	private static Action<Window> OnWindowCloseEvent; //Field offset: 0x8
	[CompilerGenerated]
	private static Action<Window> OnWindowDestroyEvent; //Field offset: 0x10
	[SerializeField]
	protected string openWindowSoundName; //Field offset: 0x20
	[SerializeField]
	protected string closeWindowSoundName; //Field offset: 0x28

	public static event Action<Window> OnWindowCloseEvent
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	public static event Action<Window> OnWindowDestroyEvent
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	public static event Action<Window> OnWindowOpenEvent
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	protected Window() { }

	[CompilerGenerated]
	public static void add_OnWindowCloseEvent(Action<Window> value) { }

	[CompilerGenerated]
	public static void add_OnWindowDestroyEvent(Action<Window> value) { }

	[CompilerGenerated]
	public static void add_OnWindowOpenEvent(Action<Window> value) { }

	public override void CloseWindow() { }

	protected void CloseWindowEnd() { }

	protected override void OnDestroy() { }

	public void OnWindowOpen() { }

	private void PlaySound(string soundName) { }

	[CompilerGenerated]
	public static void remove_OnWindowCloseEvent(Action<Window> value) { }

	[CompilerGenerated]
	public static void remove_OnWindowDestroyEvent(Action<Window> value) { }

	[CompilerGenerated]
	public static void remove_OnWindowOpenEvent(Action<Window> value) { }

}

