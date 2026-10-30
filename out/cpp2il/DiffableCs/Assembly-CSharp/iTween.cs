//Type is in global namespace

public class iTween : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <Start>d__229 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public iTween <>4__this; //Field offset: 0x20

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <Start>d__229(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <TweenDelay>d__145 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public iTween <>4__this; //Field offset: 0x20

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <TweenDelay>d__145(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <TweenRestart>d__147 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public iTween <>4__this; //Field offset: 0x20

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <TweenRestart>d__147(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	private sealed class ApplyTween : MulticastDelegate
	{

		public ApplyTween(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(AsyncCallback callback, object object) { }

		public override void EndInvoke(IAsyncResult result) { }

		public override void Invoke() { }

	}

	private class CRSpline
	{
		public Vector3[] pts; //Field offset: 0x10

		public CRSpline(Vector3[] pts) { }

		public Vector3 Interp(float t) { }

	}

	internal static class Defaults
	{
		public static float time; //Field offset: 0x0
		public static float delay; //Field offset: 0x4
		public static NamedValueColor namedColorValue; //Field offset: 0x8
		public static LoopType loopType; //Field offset: 0xC
		public static EaseType easeType; //Field offset: 0x10
		public static float lookSpeed; //Field offset: 0x14
		public static bool isLocal; //Field offset: 0x18
		public static Space space; //Field offset: 0x1C
		public static bool orientToPath; //Field offset: 0x20
		public static Color color; //Field offset: 0x24
		public static float updateTimePercentage; //Field offset: 0x34
		public static float updateTime; //Field offset: 0x38
		public static float lookAhead; //Field offset: 0x3C
		public static bool useRealTime; //Field offset: 0x40
		public static Vector3 up; //Field offset: 0x44

		private static Defaults() { }

	}

	internal enum EaseType
	{
		easeInQuad = 0,
		easeOutQuad = 1,
		easeInOutQuad = 2,
		easeInCubic = 3,
		easeOutCubic = 4,
		easeInOutCubic = 5,
		easeInQuart = 6,
		easeOutQuart = 7,
		easeInOutQuart = 8,
		easeInQuint = 9,
		easeOutQuint = 10,
		easeInOutQuint = 11,
		easeInSine = 12,
		easeOutSine = 13,
		easeInOutSine = 14,
		easeInExpo = 15,
		easeOutExpo = 16,
		easeInOutExpo = 17,
		easeInCirc = 18,
		easeOutCirc = 19,
		easeInOutCirc = 20,
		linear = 21,
		spring = 22,
		easeInBounce = 23,
		easeOutBounce = 24,
		easeInOutBounce = 25,
		easeInBack = 26,
		easeOutBack = 27,
		easeInOutBack = 28,
		easeInElastic = 29,
		easeOutElastic = 30,
		easeInOutElastic = 31,
		punch = 32,
	}

	private sealed class EasingFunction : MulticastDelegate
	{

		public EasingFunction(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(float start, float end, float Value, AsyncCallback callback, object object) { }

		public override float EndInvoke(IAsyncResult result) { }

		public override float Invoke(float start, float end, float Value) { }

	}

	internal enum LoopType
	{
		none = 0,
		loop = 1,
		pingPong = 2,
	}

	internal enum NamedValueColor
	{
		_Color = 0,
		_SpecColor = 1,
		_Emission = 2,
		_ReflectColor = 3,
	}

	public static List<Hashtable> tweens; //Field offset: 0x0
	public string id; //Field offset: 0x20
	public string type; //Field offset: 0x28
	public string method; //Field offset: 0x30
	public EaseType easeType; //Field offset: 0x38
	public float time; //Field offset: 0x3C
	public float delay; //Field offset: 0x40
	public LoopType loopType; //Field offset: 0x44
	public bool isRunning; //Field offset: 0x48
	public bool isPaused; //Field offset: 0x49
	public string _name; //Field offset: 0x50
	[CompilerGenerated]
	private bool <IsDisposed>k__BackingField; //Field offset: 0x58
	private float runningTime; //Field offset: 0x5C
	private float percentage; //Field offset: 0x60
	private float delayStarted; //Field offset: 0x64
	private bool isLocal; //Field offset: 0x68
	private bool loop; //Field offset: 0x69
	private bool reverse; //Field offset: 0x6A
	private bool wasPaused; //Field offset: 0x6B
	private Hashtable tweenArguments; //Field offset: 0x70
	private Space space; //Field offset: 0x78
	private EasingFunction ease; //Field offset: 0x80
	private ApplyTween apply; //Field offset: 0x88
	private AudioSource audioSource; //Field offset: 0x90
	private Vector3[] vector3s; //Field offset: 0x98
	private Vector2[] vector2s; //Field offset: 0xA0
	private Color[2] colors; //Field offset: 0xA8
	private Single[] floats; //Field offset: 0xB0
	private Rect[] rects; //Field offset: 0xB8
	private CRSpline path; //Field offset: 0xC0
	private NamedValueColor namedcolorvalue; //Field offset: 0xC8
	private float lastRealTime; //Field offset: 0xCC
	private bool useRealTime; //Field offset: 0xD0
	private Transform thisTransform; //Field offset: 0xD8

	public private bool IsDisposed
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	private static iTween() { }

	private iTween(Hashtable h) { }

	private void ApplyAudioToTargets() { }

	private void ApplyColorTargets() { }

	private void ApplyColorToTargets() { }

	private void ApplyFloatTargets() { }

	private void ApplyLookToTargets() { }

	private void ApplyMoveByTargets() { }

	private void ApplyMoveToPathTargets() { }

	private void ApplyMoveToTargets() { }

	private void ApplyPunchPositionTargets() { }

	private void ApplyPunchRotationTargets() { }

	private void ApplyPunchScaleTargets() { }

	private void ApplyRectTargets() { }

	private void ApplyRotateAddTargets() { }

	private void ApplyRotateToTargets() { }

	private void ApplyScaleToTargets() { }

	private void ApplyShakePositionTargets() { }

	private void ApplyShakeRotationTargets() { }

	private void ApplyShakeScaleTargets() { }

	private void ApplyStabTargets() { }

	private void ApplyVector2Targets() { }

	private void ApplyVector3Targets() { }

	public static void AudioFrom(GameObject target, Hashtable args) { }

	public static void AudioFrom(GameObject target, float volume, float pitch, float time) { }

	public static void AudioTo(GameObject target, float volume, float pitch, float time) { }

	public static void AudioTo(GameObject target, Hashtable args) { }

	public static void AudioUpdate(GameObject target, float volume, float pitch, float time) { }

	public static void AudioUpdate(GameObject target, Hashtable args) { }

	private void Awake() { }

	private void CallBack(string callbackType) { }

	private static Hashtable CleanArgs(Hashtable args) { }

	private float clerp(float start, float end, float value) { }

	public static void ColorFrom(GameObject target, Color color, float time) { }

	public static void ColorFrom(GameObject target, Hashtable args) { }

	public static void ColorTo(GameObject target, Color color, float time) { }

	public static void ColorTo(GameObject target, Hashtable args) { }

	public static void ColorUpdate(GameObject target, Hashtable args) { }

	public static void ColorUpdate(GameObject target, Color color, float time) { }

	private void ConflictCheck() { }

	public static int Count(GameObject target) { }

	public static int Count(GameObject target, string type) { }

	public static int Count() { }

	public static int Count(string type) { }

	private void Dispose() { }

	public static void DrawLine(Transform[] line) { }

	public static void DrawLine(Vector3[] line, Color color) { }

	public static void DrawLine(Transform[] line, Color color) { }

	public static void DrawLine(Vector3[] line) { }

	public static void DrawLineGizmos(Vector3[] line) { }

	public static void DrawLineGizmos(Vector3[] line, Color color) { }

	public static void DrawLineGizmos(Transform[] line) { }

	public static void DrawLineGizmos(Transform[] line, Color color) { }

	public static void DrawLineHandles(Vector3[] line) { }

	public static void DrawLineHandles(Transform[] line, Color color) { }

	public static void DrawLineHandles(Transform[] line) { }

	public static void DrawLineHandles(Vector3[] line, Color color) { }

	private static void DrawLineHelper(Vector3[] line, Color color, string method) { }

	public static void DrawPath(Vector3[] path) { }

	public static void DrawPath(Vector3[] path, Color color) { }

	public static void DrawPath(Transform[] path) { }

	public static void DrawPath(Transform[] path, Color color) { }

	public static void DrawPathGizmos(Transform[] path, Color color) { }

	public static void DrawPathGizmos(Transform[] path) { }

	public static void DrawPathGizmos(Vector3[] path, Color color) { }

	public static void DrawPathGizmos(Vector3[] path) { }

	public static void DrawPathHandles(Transform[] path, Color color) { }

	public static void DrawPathHandles(Vector3[] path) { }

	public static void DrawPathHandles(Vector3[] path, Color color) { }

	public static void DrawPathHandles(Transform[] path) { }

	private static void DrawPathHelper(Vector3[] path, Color color, string method) { }

	private float easeInBack(float start, float end, float value) { }

	private float easeInBounce(float start, float end, float value) { }

	private float easeInCirc(float start, float end, float value) { }

	private float easeInCubic(float start, float end, float value) { }

	private float easeInElastic(float start, float end, float value) { }

	private float easeInExpo(float start, float end, float value) { }

	private float easeInOutBack(float start, float end, float value) { }

	private float easeInOutBounce(float start, float end, float value) { }

	private float easeInOutCirc(float start, float end, float value) { }

	private float easeInOutCubic(float start, float end, float value) { }

	private float easeInOutElastic(float start, float end, float value) { }

	private float easeInOutExpo(float start, float end, float value) { }

	private float easeInOutQuad(float start, float end, float value) { }

	private float easeInOutQuart(float start, float end, float value) { }

	private float easeInOutQuint(float start, float end, float value) { }

	private float easeInOutSine(float start, float end, float value) { }

	private float easeInQuad(float start, float end, float value) { }

	private float easeInQuart(float start, float end, float value) { }

	private float easeInQuint(float start, float end, float value) { }

	private float easeInSine(float start, float end, float value) { }

	private float easeOutBack(float start, float end, float value) { }

	private float easeOutBounce(float start, float end, float value) { }

	private float easeOutCirc(float start, float end, float value) { }

	private float easeOutCubic(float start, float end, float value) { }

	private float easeOutElastic(float start, float end, float value) { }

	private float easeOutExpo(float start, float end, float value) { }

	private float easeOutQuad(float start, float end, float value) { }

	private float easeOutQuart(float start, float end, float value) { }

	private float easeOutQuint(float start, float end, float value) { }

	private float easeOutSine(float start, float end, float value) { }

	private void EnableKinematic() { }

	public static void FadeFrom(GameObject target, float alpha, float time) { }

	public static void FadeFrom(GameObject target, Hashtable args) { }

	public static void FadeTo(GameObject target, Hashtable args) { }

	public static void FadeTo(GameObject target, float alpha, float time) { }

	public static void FadeUpdate(GameObject target, Hashtable args) { }

	public static void FadeUpdate(GameObject target, float alpha, float time) { }

	public static float FloatUpdate(float currentValue, float targetValue, float speed) { }

	private void GenerateAudioToTargets() { }

	private void GenerateColorTargets() { }

	private void GenerateColorToTargets() { }

	private void GenerateFloatTargets() { }

	private static string GenerateID() { }

	private void GenerateLookToTargets() { }

	private void GenerateMoveByTargets() { }

	private void GenerateMoveToPathTargets() { }

	private void GenerateMoveToTargets() { }

	private void GeneratePunchPositionTargets() { }

	private void GeneratePunchRotationTargets() { }

	private void GeneratePunchScaleTargets() { }

	private void GenerateRectTargets() { }

	private void GenerateRotateAddTargets() { }

	private void GenerateRotateByTargets() { }

	private void GenerateRotateToTargets() { }

	private void GenerateScaleAddTargets() { }

	private void GenerateScaleByTargets() { }

	private void GenerateScaleToTargets() { }

	private void GenerateShakePositionTargets() { }

	private void GenerateShakeRotationTargets() { }

	private void GenerateShakeScaleTargets() { }

	private void GenerateStabTargets() { }

	private void GenerateTargets() { }

	private void GenerateVector2Targets() { }

	private void GenerateVector3Targets() { }

	[CompilerGenerated]
	public bool get_IsDisposed() { }

	private void GetEasingFunction() { }

	public static Hashtable Hash(Object[] args) { }

	public static void Init(GameObject target) { }

	private static Vector3 Interp(Vector3[] pts, float t) { }

	private static string Launch(GameObject target, Hashtable args) { }

	private float linear(float start, float end, float value) { }

	public static void LookFrom(GameObject target, Hashtable args) { }

	public static void LookFrom(GameObject target, Vector3 looktarget, float time) { }

	public static void LookTo(GameObject target, Hashtable args) { }

	public static void LookTo(GameObject target, Vector3 looktarget, float time) { }

	public static void LookUpdate(GameObject target, Hashtable args) { }

	public static void LookUpdate(GameObject target, Vector3 looktarget, float time) { }

	public static void MoveAdd(GameObject target, Vector3 amount, float time) { }

	public static void MoveAdd(GameObject target, Hashtable args) { }

	public static void MoveBy(GameObject target, Hashtable args) { }

	public static void MoveBy(GameObject target, Vector3 amount, float time) { }

	public static void MoveFrom(GameObject target, Hashtable args) { }

	public static void MoveFrom(GameObject target, Vector3 position, float time) { }

	public static void MoveTo(GameObject target, Vector3 position, float time) { }

	public static void MoveTo(GameObject target, Hashtable args) { }

	public static void MoveUpdate(GameObject target, Hashtable args) { }

	public static void MoveUpdate(GameObject target, Vector3 position, float time) { }

	private void OnDestroy() { }

	private void OnEnable() { }

	private static Vector3[] PathControlPointGenerator(Vector3[] path) { }

	public static float PathLength(Transform[] path) { }

	public static float PathLength(Vector3[] path) { }

	public static void Pause(GameObject target) { }

	public static void Pause(GameObject target, string type) { }

	public static void Pause(GameObject target, string type, bool includechildren) { }

	public static void Pause() { }

	public static void Pause(string type) { }

	public static void Pause(GameObject target, bool includechildren) { }

	public static Vector3 PointOnPath(Transform[] path, float percent) { }

	public static Vector3 PointOnPath(Vector3[] path, float percent) { }

	private float punch(float amplitude, float value) { }

	public static void PunchPosition(GameObject target, Hashtable args) { }

	public static void PunchPosition(GameObject target, Vector3 amount, float time) { }

	public static void PunchRotation(GameObject target, Hashtable args) { }

	public static void PunchRotation(GameObject target, Vector3 amount, float time) { }

	public static void PunchScale(GameObject target, Hashtable args) { }

	public static void PunchScale(GameObject target, Vector3 amount, float time) { }

	public static void PutOnPath(Transform target, Transform[] path, float percent) { }

	public static void PutOnPath(GameObject target, Transform[] path, float percent) { }

	public static void PutOnPath(Transform target, Vector3[] path, float percent) { }

	public static void PutOnPath(GameObject target, Vector3[] path, float percent) { }

	public static Rect RectUpdate(Rect currentValue, Rect targetValue, float speed) { }

	public static void Resume(GameObject target, bool includechildren) { }

	public static void Resume() { }

	public static void Resume(GameObject target, string type, bool includechildren) { }

	public static void Resume(GameObject target, string type) { }

	public static void Resume(string type) { }

	public static void Resume(GameObject target) { }

	private void ResumeDelay() { }

	private void RetrieveArgs() { }

	public static void RotateAdd(GameObject target, Vector3 amount, float time) { }

	public static void RotateAdd(GameObject target, Hashtable args) { }

	public static void RotateBy(GameObject target, Vector3 amount, float time) { }

	public static void RotateBy(GameObject target, Hashtable args) { }

	public static void RotateFrom(GameObject target, Hashtable args) { }

	public static void RotateFrom(GameObject target, Vector3 rotation, float time) { }

	public static void RotateTo(GameObject target, Hashtable args) { }

	public static void RotateTo(GameObject target, Vector3 rotation, float time) { }

	public static void RotateUpdate(GameObject target, Hashtable args) { }

	public static void RotateUpdate(GameObject target, Vector3 rotation, float time) { }

	public static void ScaleAdd(GameObject target, Vector3 amount, float time) { }

	public static void ScaleAdd(GameObject target, Hashtable args) { }

	public static void ScaleBy(GameObject target, Vector3 amount, float time) { }

	public static void ScaleBy(GameObject target, Hashtable args) { }

	public static void ScaleFrom(GameObject target, Hashtable args) { }

	public static void ScaleFrom(GameObject target, Vector3 scale, float time) { }

	public static void ScaleTo(GameObject target, Hashtable args) { }

	public static void ScaleTo(GameObject target, Vector3 scale, float time) { }

	public static void ScaleUpdate(GameObject target, Vector3 scale, float time) { }

	public static void ScaleUpdate(GameObject target, Hashtable args) { }

	[CompilerGenerated]
	private void set_IsDisposed(bool value) { }

	public static void ShakePosition(GameObject target, Hashtable args) { }

	public static void ShakePosition(GameObject target, Vector3 amount, float time) { }

	public static void ShakeRotation(GameObject target, Hashtable args) { }

	public static void ShakeRotation(GameObject target, Vector3 amount, float time) { }

	public static void ShakeScale(GameObject target, Hashtable args) { }

	public static void ShakeScale(GameObject target, Vector3 amount, float time) { }

	private float spring(float start, float end, float value) { }

	public static void Stab(GameObject target, Hashtable args) { }

	public static void Stab(GameObject target, AudioClip audioclip, float delay) { }

	[IteratorStateMachine(typeof(<Start>d__229))]
	private IEnumerator Start() { }

	public static void Stop(string type) { }

	public static void Stop() { }

	public static void Stop(GameObject target) { }

	public static void Stop(GameObject target, bool includechildren) { }

	public static void Stop(GameObject target, string type) { }

	public static void Stop(GameObject target, string type, bool includechildren) { }

	public static void StopByName(string name) { }

	public static void StopByName(GameObject target, string name) { }

	public static void StopByName(GameObject target, string name, bool includechildren) { }

	private void TweenComplete() { }

	[IteratorStateMachine(typeof(<TweenDelay>d__145))]
	private IEnumerator TweenDelay() { }

	private void TweenLoop() { }

	[IteratorStateMachine(typeof(<TweenRestart>d__147))]
	private IEnumerator TweenRestart() { }

	private void TweenStart() { }

	private void TweenUpdate() { }

	private void Update() { }

	private void UpdatePercentage() { }

	public static string ValueTo(GameObject target, Hashtable args) { }

	public static Vector2 Vector2Update(Vector2 currentValue, Vector2 targetValue, float speed) { }

	public static Vector3 Vector3Update(Vector3 currentValue, Vector3 targetValue, float speed) { }

}

