namespace TMPro;

public static class TMP_TextUtilities
{
	private struct LineSegment
	{
		public Vector3 Point1; //Field offset: 0x0
		public Vector3 Point2; //Field offset: 0xC

		public LineSegment(Vector3 p1, Vector3 p2) { }

	}

	private static Vector3[] m_rectWorldCorners; //Field offset: 0x0
	private const string k_lookupStringL = "-------------------------------- !-#$%&-()*+,-./0123456789:;<=>?@abcdefghijklmnopqrstuvwxyz[-]^_`abcdefghijklmnopqrstuvwxyz{|}~-"; //Field offset: 0x0
	private const string k_lookupStringU = "-------------------------------- !-#$%&-()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[-]^_`ABCDEFGHIJKLMNOPQRSTUVWXYZ{|}~-"; //Field offset: 0x0

	private static TMP_TextUtilities() { }

	public static float DistanceToLine(Vector3 a, Vector3 b, Vector3 point) { }

	public static int FindIntersectingCharacter(TMP_Text text, Vector3 position, Camera camera, bool visibleOnly) { }

	public static int FindIntersectingLine(TMP_Text text, Vector3 position, Camera camera) { }

	public static int FindIntersectingLink(TMP_Text text, Vector3 position, Camera camera) { }

	public static int FindIntersectingWord(TMP_Text text, Vector3 position, Camera camera) { }

	public static int FindNearestCharacter(TMP_Text text, Vector3 position, Camera camera, bool visibleOnly) { }

	public static int FindNearestCharacterOnLine(TMP_Text text, Vector3 position, int line, Camera camera, bool visibleOnly) { }

	public static int FindNearestLine(TMP_Text text, Vector3 position, Camera camera) { }

	public static int FindNearestLink(TMP_Text text, Vector3 position, Camera camera) { }

	public static int FindNearestWord(TMP_Text text, Vector3 position, Camera camera) { }

	public static int GetCursorIndexFromPosition(TMP_Text textComponent, Vector3 position, Camera camera) { }

	public static int GetCursorIndexFromPosition(TMP_Text textComponent, Vector3 position, Camera camera, out CaretPosition cursor) { }

	public static int GetHashCode(string s) { }

	public static int GetSimpleHashCode(string s) { }

	public static uint GetSimpleHashCodeLowercase(string s) { }

	public static int HexToInt(char hex) { }

	private static bool IntersectLinePlane(LineSegment line, Vector3 point, Vector3 normal, out Vector3 intersectingPoint) { }

	public static bool IsIntersectingRectTransform(RectTransform rectTransform, Vector3 position, Camera camera) { }

	private static bool PointIntersectRectangle(Vector3 m, Vector3 a, Vector3 b, Vector3 c, Vector3 d) { }

	public static bool ScreenPointToWorldPointInRectangle(Transform transform, Vector2 screenPoint, Camera cam, out Vector3 worldPoint) { }

	public static int StringHexToInt(string s) { }

	public static char ToLowerFast(char c) { }

	internal static uint ToUpperASCIIFast(uint c) { }

	public static char ToUpperFast(char c) { }

}

