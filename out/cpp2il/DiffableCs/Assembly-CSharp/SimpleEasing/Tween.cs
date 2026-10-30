namespace SimpleEasing;

public class Tween
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Single> <>9__61_0; //Field offset: 0x8
		public static Func<Single> <>9__61_1; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal float <TimeFunction>b__61_0() { }

		internal float <TimeFunction>b__61_1() { }

	}

	internal enum TweenType
	{
		delay = 0,
		f = 1,
		v2 = 2,
		v3 = 3,
		col = 4,
		quat = 5,
	}

	private static readonly Stack<Tween> pool; //Field offset: 0x0
	public float from; //Field offset: 0x10
	public float to; //Field offset: 0x14
	public float restTime; //Field offset: 0x18
	public float originalTime; //Field offset: 0x1C
	public float progress; //Field offset: 0x20
	public Vector2 fromVector2; //Field offset: 0x24
	public Vector2 toVector2; //Field offset: 0x2C
	public Vector3 fromVector3; //Field offset: 0x34
	public Vector3 toVector3; //Field offset: 0x40
	public Quaternion fromQuaternion; //Field offset: 0x4C
	public Quaternion toQuaternion; //Field offset: 0x5C
	public Color fromColor; //Field offset: 0x6C
	public Color toColor; //Field offset: 0x7C
	public Func<Single, Single, Single, Single> easeFunctionDelegate; //Field offset: 0x90
	private Action<Single> valueSetter; //Field offset: 0x98
	private Action<Vector2> valueSetterVector2; //Field offset: 0xA0
	private Action<Vector3> valueSetterVector3; //Field offset: 0xA8
	private Action<Quaternion> valueSetterQuaternion; //Field offset: 0xB0
	private Action<Color> valueSetterColor; //Field offset: 0xB8
	public Func<Single> deltaTimeDelegate; //Field offset: 0xC0
	public Action OnComplete; //Field offset: 0xC8
	public TweenType type; //Field offset: 0xD0
	public TweenRepeat repeat; //Field offset: 0xD4
	public Coroutine animationRoutine; //Field offset: 0xD8
	public bool pooled; //Field offset: 0xE0

	public Color ColorValue
	{
		 set { } //Length: 36
	}

	public float FloatValue
	{
		 set { } //Length: 36
	}

	public static int PoolSize
	{
		 get { } //Length: 112
	}

	public Quaternion QuaternionValue
	{
		 set { } //Length: 36
	}

	public Vector2 Vector2Value
	{
		 set { } //Length: 36
	}

	public Vector3 Vector3Value
	{
		 set { } //Length: 36
	}

	private static Tween() { }

	public Tween() { }

	public Tween(float seconds) { }

	public Tween(Action<Color> valueSetter, Color from, Color to, TweenSettings settings, Action OnComplete = null) { }

	public Tween(Action<Color> valueSetter, Color from, Color to, float length, AnimationCurve curve, bool unscaled = false, TweenRepeat repeat = 0, Action OnComplete = null) { }

	public Tween(Action<Color> valueSetter, Color from, Color to, float length, EasingTypes easeType = 0, bool unscaled = false, TweenRepeat repeat = 0, Action OnComplete = null) { }

	public Tween(Action<Quaternion> valueSetter, Quaternion from, Quaternion to, TweenSettings settings, Action OnComplete = null) { }

	public Tween(Action<Quaternion> valueSetter, Quaternion from, Quaternion to, float length, AnimationCurve curve, bool unscaled = false, TweenRepeat repeat = 0, Action OnComplete = null) { }

	public Tween(Action<Quaternion> valueSetter, Quaternion from, Quaternion to, float length, EasingTypes easeType = 0, bool unscaled = false, TweenRepeat repeat = 0, Action OnComplete = null) { }

	public Tween(Action<Single> valueSetter, float from, float to, float length, EasingTypes easeType = 0, bool unscaled = false, TweenRepeat repeat = 0, Action OnComplete = null) { }

	public Tween(Action<Vector3> valueSetter, Vector3 from, Vector3 to, float length, AnimationCurve curve, bool unscaled = false, TweenRepeat repeat = 0, Action OnComplete = null) { }

	public Tween(Action<Vector3> valueSetter, Vector3 from, Vector3 to, float length, EasingTypes easeType = 0, bool unscaled = false, TweenRepeat repeat = 0, Action OnComplete = null) { }

	public Tween(Action<Vector2> valueSetter, Vector2 from, Vector2 to, TweenSettings settings, Action OnComplete = null) { }

	public Tween(Action<Vector2> valueSetter, Vector2 from, Vector2 to, float length, AnimationCurve curve, bool unscaled = false, TweenRepeat repeat = 0, Action OnComplete = null) { }

	public Tween(Action<Vector2> valueSetter, Vector2 from, Vector2 to, float length, EasingTypes easeType = 0, bool unscaled = false, TweenRepeat repeat = 0, Action OnComplete = null) { }

	public Tween(Action<Single> valueSetter, float from, float to, TweenSettings settings, Action OnComplete = null) { }

	public Tween(Action<Single> valueSetter, float from, float to, float length, AnimationCurve curve, bool unscaled = false, TweenRepeat repeat = 0, Action OnComplete = null) { }

	public Tween(Action<Vector3> valueSetter, Vector3 from, Vector3 to, TweenSettings settings, Action OnComplete = null) { }

	public static Tween Get(Action<Vector3> valueSetter, Vector3 from, Vector3 to, TweenSettings settings, Action OnComplete = null) { }

	public static Tween Get(Action<Quaternion> valueSetter, Quaternion from, Quaternion to, TweenSettings settings, Action OnComplete = null) { }

	public static Tween Get(Action<Color> valueSetter, Color from, Color to, TweenSettings settings, Action OnComplete = null) { }

	public static Tween Get(Action<Vector2> valueSetter, Vector2 from, Vector2 to, TweenSettings settings, Action OnComplete = null) { }

	public static Tween Get(Action<Single> valueSetter, float from, float to, TweenSettings settings, Action OnComplete = null) { }

	public static int get_PoolSize() { }

	public Coroutine Play() { }

	public Coroutine PlayFromStart() { }

	public static void Release(Tween t) { }

	public void Reset() { }

	public void set_ColorValue(Color value) { }

	public void set_FloatValue(float value) { }

	public void set_QuaternionValue(Quaternion value) { }

	public void set_Vector2Value(Vector2 value) { }

	public void set_Vector3Value(Vector3 value) { }

	private void SetAnimationParameters(float length, Func<Single, Single, Single, Single> easingFunction, bool unscaled = false, TweenRepeat repeat = 0, Action OnComplete = null) { }

	private void SetAnimationParameters(TweenSettings settings, Action OnComplete = null) { }

	private void SetColorParameters(Action<Color> valueSetter, Color from, Color to) { }

	private void SetFloatParameters(Action<Single> valueSetter, float from, float to) { }

	public static void SetPool(int size) { }

	private void SetQuaternionParameters(Action<Quaternion> valueSetter, Quaternion from, Quaternion to) { }

	private void SetVector2Parameters(Action<Vector2> valueSetter, Vector2 from, Vector2 to) { }

	private void SetVector3Parameters(Action<Vector3> valueSetter, Vector3 from, Vector3 to) { }

	public void Stop() { }

	public void StopAndRelease() { }

	public static void Swap(ref T param1, ref T param2) { }

	public void SwitchTargets() { }

	public static Func<Single> TimeFunction(bool unscaled) { }

}

