//Type is in global namespace

[Extension]
public static class LeanTweenExt
{

	[Extension]
	public static LTDescr LeanAlpha(GameObject gameObject, float to, float time) { }

	[Extension]
	public static LTDescr LeanAlpha(RectTransform rectTransform, float to, float time) { }

	[Extension]
	public static LTDescr LeanAlpha(CanvasGroup canvas, float to, float time) { }

	[Extension]
	public static LTDescr LeanAlphaText(RectTransform rectTransform, float to, float time) { }

	[Extension]
	public static LTDescr LeanAlphaVertex(GameObject gameObject, float to, float time) { }

	[Extension]
	public static void LeanCancel(GameObject gameObject) { }

	[Extension]
	public static void LeanCancel(GameObject gameObject, bool callOnComplete) { }

	[Extension]
	public static void LeanCancel(GameObject gameObject, int uniqueId, bool callOnComplete = false) { }

	[Extension]
	public static void LeanCancel(RectTransform rectTransform) { }

	[Extension]
	public static Color LeanColor(Transform transform) { }

	[Extension]
	public static LTDescr LeanColor(GameObject gameObject, Color to, float time) { }

	[Extension]
	public static LTDescr LeanColorText(RectTransform rectTransform, Color to, float time) { }

	[Extension]
	public static LTDescr LeanDelayedCall(GameObject gameObject, float delayTime, Action<Object> callback) { }

	[Extension]
	public static LTDescr LeanDelayedCall(GameObject gameObject, float delayTime, Action callback) { }

	[Extension]
	public static bool LeanIsPaused(GameObject gameObject) { }

	[Extension]
	public static bool LeanIsPaused(RectTransform rectTransform) { }

	[Extension]
	public static bool LeanIsTweening(GameObject gameObject) { }

	[Extension]
	public static LTDescr LeanMove(Transform transform, LTSpline to, float time) { }

	[Extension]
	public static LTDescr LeanMove(Transform transform, LTBezierPath to, float time) { }

	[Extension]
	public static LTDescr LeanMove(Transform transform, Vector3[] to, float time) { }

	[Extension]
	public static LTDescr LeanMove(GameObject gameObject, LTSpline to, float time) { }

	[Extension]
	public static LTDescr LeanMove(GameObject gameObject, LTBezierPath to, float time) { }

	[Extension]
	public static LTDescr LeanMove(Transform transform, Vector2 to, float time) { }

	[Extension]
	public static LTDescr LeanMove(RectTransform rectTransform, Vector3 to, float time) { }

	[Extension]
	public static LTDescr LeanMove(Transform transform, Vector3 to, float time) { }

	[Extension]
	public static LTDescr LeanMove(GameObject gameObject, Vector3 to, float time) { }

	[Extension]
	public static LTDescr LeanMove(GameObject gameObject, Vector3[] to, float time) { }

	[Extension]
	public static LTDescr LeanMove(GameObject gameObject, Vector2 to, float time) { }

	[Extension]
	public static LTDescr LeanMoveLocal(Transform transform, LTBezierPath to, float time) { }

	[Extension]
	public static LTDescr LeanMoveLocal(Transform transform, LTSpline to, float time) { }

	[Extension]
	public static LTDescr LeanMoveLocal(GameObject gameObject, LTSpline to, float time) { }

	[Extension]
	public static LTDescr LeanMoveLocal(GameObject gameObject, LTBezierPath to, float time) { }

	[Extension]
	public static LTDescr LeanMoveLocal(GameObject gameObject, Vector3 to, float time) { }

	[Extension]
	public static LTDescr LeanMoveLocal(Transform transform, Vector3 to, float time) { }

	[Extension]
	public static LTDescr LeanMoveLocalX(GameObject gameObject, float to, float time) { }

	[Extension]
	public static LTDescr LeanMoveLocalX(Transform transform, float to, float time) { }

	[Extension]
	public static LTDescr LeanMoveLocalY(GameObject gameObject, float to, float time) { }

	[Extension]
	public static LTDescr LeanMoveLocalY(Transform transform, float to, float time) { }

	[Extension]
	public static LTDescr LeanMoveLocalZ(GameObject gameObject, float to, float time) { }

	[Extension]
	public static LTDescr LeanMoveLocalZ(Transform transform, float to, float time) { }

	[Extension]
	public static LTDescr LeanMoveSpline(Transform transform, LTSpline to, float time) { }

	[Extension]
	public static LTDescr LeanMoveSpline(GameObject gameObject, LTSpline to, float time) { }

	[Extension]
	public static LTDescr LeanMoveSpline(GameObject gameObject, Vector3[] to, float time) { }

	[Extension]
	public static LTDescr LeanMoveSpline(Transform transform, Vector3[] to, float time) { }

	[Extension]
	public static LTDescr LeanMoveSplineLocal(GameObject gameObject, Vector3[] to, float time) { }

	[Extension]
	public static LTDescr LeanMoveSplineLocal(Transform transform, Vector3[] to, float time) { }

	[Extension]
	public static LTDescr LeanMoveX(GameObject gameObject, float to, float time) { }

	[Extension]
	public static LTDescr LeanMoveX(Transform transform, float to, float time) { }

	[Extension]
	public static LTDescr LeanMoveX(RectTransform rectTransform, float to, float time) { }

	[Extension]
	public static LTDescr LeanMoveY(RectTransform rectTransform, float to, float time) { }

	[Extension]
	public static LTDescr LeanMoveY(Transform transform, float to, float time) { }

	[Extension]
	public static LTDescr LeanMoveY(GameObject gameObject, float to, float time) { }

	[Extension]
	public static LTDescr LeanMoveZ(GameObject gameObject, float to, float time) { }

	[Extension]
	public static LTDescr LeanMoveZ(Transform transform, float to, float time) { }

	[Extension]
	public static LTDescr LeanMoveZ(RectTransform rectTransform, float to, float time) { }

	[Extension]
	public static void LeanPause(GameObject gameObject) { }

	[Extension]
	public static LTDescr LeanPlay(RectTransform rectTransform, Sprite[] sprites) { }

	[Extension]
	public static void LeanResume(GameObject gameObject) { }

	[Extension]
	public static LTDescr LeanRotate(Transform transform, Vector3 to, float time) { }

	[Extension]
	public static LTDescr LeanRotate(RectTransform rectTransform, Vector3 to, float time) { }

	[Extension]
	public static LTDescr LeanRotate(GameObject gameObject, Vector3 to, float time) { }

	[Extension]
	public static LTDescr LeanRotateAround(GameObject gameObject, Vector3 axis, float add, float time) { }

	[Extension]
	public static LTDescr LeanRotateAround(Transform transform, Vector3 axis, float add, float time) { }

	[Extension]
	public static LTDescr LeanRotateAround(RectTransform rectTransform, Vector3 axis, float add, float time) { }

	[Extension]
	public static LTDescr LeanRotateAroundLocal(GameObject gameObject, Vector3 axis, float add, float time) { }

	[Extension]
	public static LTDescr LeanRotateAroundLocal(RectTransform rectTransform, Vector3 axis, float add, float time) { }

	[Extension]
	public static LTDescr LeanRotateAroundLocal(Transform transform, Vector3 axis, float add, float time) { }

	[Extension]
	public static LTDescr LeanRotateX(GameObject gameObject, float to, float time) { }

	[Extension]
	public static LTDescr LeanRotateX(Transform transform, float to, float time) { }

	[Extension]
	public static LTDescr LeanRotateY(GameObject gameObject, float to, float time) { }

	[Extension]
	public static LTDescr LeanRotateY(Transform transform, float to, float time) { }

	[Extension]
	public static LTDescr LeanRotateZ(Transform transform, float to, float time) { }

	[Extension]
	public static LTDescr LeanRotateZ(GameObject gameObject, float to, float time) { }

	[Extension]
	public static LTDescr LeanScale(RectTransform rectTransform, Vector3 to, float time) { }

	[Extension]
	public static LTDescr LeanScale(GameObject gameObject, Vector3 to, float time) { }

	[Extension]
	public static LTDescr LeanScale(Transform transform, Vector3 to, float time) { }

	[Extension]
	public static LTDescr LeanScaleX(GameObject gameObject, float to, float time) { }

	[Extension]
	public static LTDescr LeanScaleX(Transform transform, float to, float time) { }

	[Extension]
	public static LTDescr LeanScaleY(GameObject gameObject, float to, float time) { }

	[Extension]
	public static LTDescr LeanScaleY(Transform transform, float to, float time) { }

	[Extension]
	public static LTDescr LeanScaleZ(GameObject gameObject, float to, float time) { }

	[Extension]
	public static LTDescr LeanScaleZ(Transform transform, float to, float time) { }

	[Extension]
	public static void LeanSetLocalPosX(Transform transform, float val) { }

	[Extension]
	public static void LeanSetLocalPosY(Transform transform, float val) { }

	[Extension]
	public static void LeanSetLocalPosZ(Transform transform, float val) { }

	[Extension]
	public static void LeanSetPosX(Transform transform, float val) { }

	[Extension]
	public static void LeanSetPosY(Transform transform, float val) { }

	[Extension]
	public static void LeanSetPosZ(Transform transform, float val) { }

	[Extension]
	public static LTDescr LeanSize(RectTransform rectTransform, Vector2 to, float time) { }

	[Extension]
	public static LTDescr LeanValue(GameObject gameObject, Vector3 from, Vector3 to, float time) { }

	[Extension]
	public static LTDescr LeanValue(GameObject gameObject, float from, float to, float time) { }

	[Extension]
	public static LTDescr LeanValue(GameObject gameObject, Action<Single, Single> callOnUpdate, float from, float to, float time) { }

	[Extension]
	public static LTDescr LeanValue(GameObject gameObject, Action<Single, Object> callOnUpdate, float from, float to, float time) { }

	[Extension]
	public static LTDescr LeanValue(GameObject gameObject, Action<Color> callOnUpdate, Color from, Color to, float time) { }

	[Extension]
	public static LTDescr LeanValue(GameObject gameObject, Action<Vector2> callOnUpdate, Vector2 from, Vector2 to, float time) { }

	[Extension]
	public static LTDescr LeanValue(GameObject gameObject, Action<Vector3> callOnUpdate, Vector3 from, Vector3 to, float time) { }

	[Extension]
	public static LTDescr LeanValue(GameObject gameObject, Color from, Color to, float time) { }

	[Extension]
	public static LTDescr LeanValue(GameObject gameObject, Vector2 from, Vector2 to, float time) { }

	[Extension]
	public static LTDescr LeanValue(GameObject gameObject, Action<Single> callOnUpdate, float from, float to, float time) { }

}

