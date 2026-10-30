namespace UnityEngine;

public class GUILayout
{

	public static void BeginArea(Rect screenRect, GUIContent content, GUIStyle style) { }

	public static void BeginArea(Rect screenRect) { }

	public static void BeginArea(Rect screenRect, GUIStyle style) { }

	public static void BeginHorizontal(GUIStyle style, GUILayoutOption[] options) { }

	public static void BeginHorizontal(GUILayoutOption[] options) { }

	public static void BeginHorizontal(GUIContent content, GUIStyle style, GUILayoutOption[] options) { }

	public static Vector2 BeginScrollView(Vector2 scrollPosition, bool alwaysShowHorizontal, bool alwaysShowVertical, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, GUIStyle background, GUILayoutOption[] options) { }

	public static Vector2 BeginScrollView(Vector2 scrollPosition, GUILayoutOption[] options) { }

	public static void BeginVertical(GUIContent content, GUIStyle style, GUILayoutOption[] options) { }

	public static void BeginVertical(GUILayoutOption[] options) { }

	public static void Box(GUIContent content, GUIStyle style, GUILayoutOption[] options) { }

	public static bool Button(string text, GUILayoutOption[] options) { }

	public static bool Button(string text, GUIStyle style, GUILayoutOption[] options) { }

	public static bool Button(GUIContent content, GUIStyle style, GUILayoutOption[] options) { }

	private static void DoBox(GUIContent content, GUIStyle style, GUILayoutOption[] options) { }

	private static bool DoButton(GUIContent content, GUIStyle style, GUILayoutOption[] options) { }

	private static float DoHorizontalSlider(float value, float leftValue, float rightValue, GUIStyle slider, GUIStyle thumb, GUILayoutOption[] options) { }

	private static void DoLabel(GUIContent content, GUIStyle style, GUILayoutOption[] options) { }

	public static void EndArea() { }

	public static void EndHorizontal() { }

	public static void EndScrollView() { }

	internal static void EndScrollView(bool handleScrollWheel) { }

	public static void EndVertical() { }

	public static GUILayoutOption ExpandHeight(bool expand) { }

	public static GUILayoutOption ExpandWidth(bool expand) { }

	public static void FlexibleSpace() { }

	public static GUILayoutOption Height(float height) { }

	public static float HorizontalSlider(float value, float leftValue, float rightValue, GUIStyle slider, GUIStyle thumb, GUILayoutOption[] options) { }

	public static void Label(string text, GUIStyle style, GUILayoutOption[] options) { }

	public static void Label(string text, GUILayoutOption[] options) { }

	public static void Space(float pixels) { }

	public static GUILayoutOption Width(float width) { }

}

