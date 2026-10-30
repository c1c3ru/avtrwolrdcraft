namespace PazuCore;

public static class MultiTouchProtection
{
	private static int _lastFrameInput; //Field offset: 0x0
	private static int _lastFrameToggleInputCounter; //Field offset: 0x4

	public static bool TryReceiveInput() { }

	public static bool TryReceiveUnityUIToggleInput() { }

}

