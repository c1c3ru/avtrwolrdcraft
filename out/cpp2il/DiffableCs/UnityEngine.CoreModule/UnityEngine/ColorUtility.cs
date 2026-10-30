namespace UnityEngine;

[NativeHeader("Runtime/Math/ColorUtility.h")]
public class ColorUtility
{

	[FreeFunction("TryParseHtmlColor", True)]
	internal static bool DoTryParseHtmlColor(string htmlString, out Color32 color) { }

	public static string ToHtmlStringRGB(Color color) { }

	public static bool TryParseHtmlString(string htmlString, out Color color) { }

}

