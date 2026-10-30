//Type is in global namespace

public class LTDescr
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static ActionMethodDelegate <>9__113_0; //Field offset: 0x8
		public static ActionMethodDelegate <>9__114_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal void <setCallback>b__113_0() { }

		internal void <setValue3>b__114_0() { }

	}

	internal sealed class ActionMethodDelegate : MulticastDelegate
	{

		public ActionMethodDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(AsyncCallback callback, object object) { }

		public override void EndInvoke(IAsyncResult result) { }

		public override void Invoke() { }

	}

	internal sealed class EaseTypeDelegate : MulticastDelegate
	{

		public EaseTypeDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(AsyncCallback callback, object object) { }

		public override Vector3 EndInvoke(IAsyncResult result) { }

		public override Vector3 Invoke() { }

	}

	public static float val; //Field offset: 0x0
	public static float dt; //Field offset: 0x4
	public static Vector3 newVect; //Field offset: 0x8
	public bool toggle; //Field offset: 0x10
	public bool useEstimatedTime; //Field offset: 0x11
	public bool useFrames; //Field offset: 0x12
	public bool useManualTime; //Field offset: 0x13
	public bool usesNormalDt; //Field offset: 0x14
	public bool hasInitiliazed; //Field offset: 0x15
	public bool hasExtraOnCompletes; //Field offset: 0x16
	public bool hasPhysics; //Field offset: 0x17
	public bool onCompleteOnRepeat; //Field offset: 0x18
	public bool onCompleteOnStart; //Field offset: 0x19
	public bool useRecursion; //Field offset: 0x1A
	public float ratioPassed; //Field offset: 0x1C
	public float passed; //Field offset: 0x20
	public float delay; //Field offset: 0x24
	public float time; //Field offset: 0x28
	public float speed; //Field offset: 0x2C
	public float lastVal; //Field offset: 0x30
	private uint _id; //Field offset: 0x34
	public int loopCount; //Field offset: 0x38
	public uint counter; //Field offset: 0x3C
	public float direction; //Field offset: 0x40
	public float directionLast; //Field offset: 0x44
	public float overshoot; //Field offset: 0x48
	public float period; //Field offset: 0x4C
	public float scale; //Field offset: 0x50
	public bool destroyOnComplete; //Field offset: 0x54
	public Transform trans; //Field offset: 0x58
	internal Vector3 fromInternal; //Field offset: 0x60
	internal Vector3 toInternal; //Field offset: 0x6C
	internal Vector3 diff; //Field offset: 0x78
	internal Vector3 diffDiv2; //Field offset: 0x84
	public TweenAction type; //Field offset: 0x90
	private LeanTweenType easeType; //Field offset: 0x94
	public LeanTweenType loopType; //Field offset: 0x98
	public bool hasUpdateCallback; //Field offset: 0x9C
	public EaseTypeDelegate easeMethod; //Field offset: 0xA0
	[CompilerGenerated]
	private ActionMethodDelegate <easeInternal>k__BackingField; //Field offset: 0xA8
	[CompilerGenerated]
	private ActionMethodDelegate <initInternal>k__BackingField; //Field offset: 0xB0
	public SpriteRenderer spriteRen; //Field offset: 0xB8
	public RectTransform rectTransform; //Field offset: 0xC0
	public Text uiText; //Field offset: 0xC8
	public Image uiImage; //Field offset: 0xD0
	public RawImage rawImage; //Field offset: 0xD8
	public Sprite[] sprites; //Field offset: 0xE0
	public LTDescrOptional _optional; //Field offset: 0xE8

	public ActionMethodDelegate easeInternal
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public Vector3 from
	{
		 get { } //Length: 12
		 set { } //Length: 12
	}

	public int id
	{
		 get { } //Length: 16
	}

	public ActionMethodDelegate initInternal
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public LTDescrOptional optional
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public Vector3 to
	{
		 get { } //Length: 12
		 set { } //Length: 12
	}

	public Transform toTrans
	{
		 get { } //Length: 28
	}

	public int uniqueId
	{
		 get { } //Length: 16
	}

	public LTDescr() { }

	[CompilerGenerated]
	private void <setAlpha>b__93_0() { }

	[CompilerGenerated]
	private void <setAlpha>b__93_1() { }

	[CompilerGenerated]
	private void <setAlpha>b__93_2() { }

	[CompilerGenerated]
	private void <setAlphaVertex>b__95_0() { }

	[CompilerGenerated]
	private void <setAlphaVertex>b__95_1() { }

	[CompilerGenerated]
	private void <setCallbackColor>b__97_0() { }

	[CompilerGenerated]
	private void <setCallbackColor>b__97_1() { }

	[CompilerGenerated]
	private void <setCanvasAlpha>b__99_0() { }

	[CompilerGenerated]
	private void <setCanvasAlpha>b__99_1() { }

	[CompilerGenerated]
	private void <setCanvasColor>b__101_0() { }

	[CompilerGenerated]
	private void <setCanvasColor>b__101_1() { }

	[CompilerGenerated]
	private void <setCanvasGroupAlpha>b__100_0() { }

	[CompilerGenerated]
	private void <setCanvasGroupAlpha>b__100_1() { }

	[CompilerGenerated]
	private void <setCanvasMove>b__109_0() { }

	[CompilerGenerated]
	private void <setCanvasMove>b__109_1() { }

	[CompilerGenerated]
	private void <setCanvasMoveX>b__102_0() { }

	[CompilerGenerated]
	private void <setCanvasMoveX>b__102_1() { }

	[CompilerGenerated]
	private void <setCanvasMoveY>b__103_0() { }

	[CompilerGenerated]
	private void <setCanvasMoveY>b__103_1() { }

	[CompilerGenerated]
	private void <setCanvasMoveZ>b__104_0() { }

	[CompilerGenerated]
	private void <setCanvasMoveZ>b__104_1() { }

	[CompilerGenerated]
	private void <setCanvasPlaySprite>b__108_0() { }

	[CompilerGenerated]
	private void <setCanvasPlaySprite>b__108_1() { }

	[CompilerGenerated]
	private void <setCanvasRotateAround>b__106_0() { }

	[CompilerGenerated]
	private void <setCanvasRotateAroundLocal>b__107_0() { }

	[CompilerGenerated]
	private void <setCanvasScale>b__110_0() { }

	[CompilerGenerated]
	private void <setCanvasScale>b__110_1() { }

	[CompilerGenerated]
	private void <setCanvasSizeDelta>b__111_0() { }

	[CompilerGenerated]
	private void <setCanvasSizeDelta>b__111_1() { }

	[CompilerGenerated]
	private void <setColor>b__96_0() { }

	[CompilerGenerated]
	private void <setColor>b__96_1() { }

	[CompilerGenerated]
	private void <setDelayedSound>b__126_0() { }

	[CompilerGenerated]
	private void <setGUIAlpha>b__124_0() { }

	[CompilerGenerated]
	private void <setGUIAlpha>b__124_1() { }

	[CompilerGenerated]
	private void <setGUIMove>b__121_0() { }

	[CompilerGenerated]
	private void <setGUIMove>b__121_1() { }

	[CompilerGenerated]
	private void <setGUIMoveMargin>b__122_0() { }

	[CompilerGenerated]
	private void <setGUIMoveMargin>b__122_1() { }

	[CompilerGenerated]
	private void <setGUIRotate>b__125_0() { }

	[CompilerGenerated]
	private void <setGUIRotate>b__125_1() { }

	[CompilerGenerated]
	private void <setGUIScale>b__123_0() { }

	[CompilerGenerated]
	private void <setGUIScale>b__123_1() { }

	[CompilerGenerated]
	private void <setMove>b__115_0() { }

	[CompilerGenerated]
	private void <setMove>b__115_1() { }

	[CompilerGenerated]
	private void <setMoveCurved>b__81_0() { }

	[CompilerGenerated]
	private void <setMoveCurvedLocal>b__82_0() { }

	[CompilerGenerated]
	private void <setMoveLocal>b__116_0() { }

	[CompilerGenerated]
	private void <setMoveLocal>b__116_1() { }

	[CompilerGenerated]
	private void <setMoveLocalX>b__76_0() { }

	[CompilerGenerated]
	private void <setMoveLocalX>b__76_1() { }

	[CompilerGenerated]
	private void <setMoveLocalY>b__77_0() { }

	[CompilerGenerated]
	private void <setMoveLocalY>b__77_1() { }

	[CompilerGenerated]
	private void <setMoveLocalZ>b__78_0() { }

	[CompilerGenerated]
	private void <setMoveLocalZ>b__78_1() { }

	[CompilerGenerated]
	private void <setMoveSpline>b__83_0() { }

	[CompilerGenerated]
	private void <setMoveSplineLocal>b__84_0() { }

	[CompilerGenerated]
	private void <setMoveToTransform>b__117_0() { }

	[CompilerGenerated]
	private void <setMoveToTransform>b__117_1() { }

	[CompilerGenerated]
	private void <setMoveX>b__73_0() { }

	[CompilerGenerated]
	private void <setMoveX>b__73_1() { }

	[CompilerGenerated]
	private void <setMoveY>b__74_0() { }

	[CompilerGenerated]
	private void <setMoveY>b__74_1() { }

	[CompilerGenerated]
	private void <setMoveZ>b__75_0() { }

	[CompilerGenerated]
	private void <setMoveZ>b__75_1() { }

	[CompilerGenerated]
	private void <setRotate>b__118_0() { }

	[CompilerGenerated]
	private void <setRotate>b__118_1() { }

	[CompilerGenerated]
	private void <setRotateAround>b__91_0() { }

	[CompilerGenerated]
	private void <setRotateAround>b__91_1() { }

	[CompilerGenerated]
	private void <setRotateAroundLocal>b__92_0() { }

	[CompilerGenerated]
	private void <setRotateAroundLocal>b__92_1() { }

	[CompilerGenerated]
	private void <setRotateLocal>b__119_0() { }

	[CompilerGenerated]
	private void <setRotateLocal>b__119_1() { }

	[CompilerGenerated]
	private void <setRotateX>b__88_0() { }

	[CompilerGenerated]
	private void <setRotateX>b__88_1() { }

	[CompilerGenerated]
	private void <setRotateY>b__89_0() { }

	[CompilerGenerated]
	private void <setRotateY>b__89_1() { }

	[CompilerGenerated]
	private void <setRotateZ>b__90_0() { }

	[CompilerGenerated]
	private void <setRotateZ>b__90_1() { }

	[CompilerGenerated]
	private void <setScale>b__120_0() { }

	[CompilerGenerated]
	private void <setScale>b__120_1() { }

	[CompilerGenerated]
	private void <setScaleX>b__85_0() { }

	[CompilerGenerated]
	private void <setScaleX>b__85_1() { }

	[CompilerGenerated]
	private void <setScaleY>b__86_0() { }

	[CompilerGenerated]
	private void <setScaleY>b__86_1() { }

	[CompilerGenerated]
	private void <setScaleZ>b__87_0() { }

	[CompilerGenerated]
	private void <setScaleZ>b__87_1() { }

	[CompilerGenerated]
	private void <setTextAlpha>b__94_0() { }

	[CompilerGenerated]
	private void <setTextAlpha>b__94_1() { }

	[CompilerGenerated]
	private void <setTextColor>b__98_0() { }

	[CompilerGenerated]
	private void <setTextColor>b__98_1() { }

	private static void alphaRecursive(RectTransform rectTransform, float val, int recursiveLevel = 0) { }

	private static void alphaRecursive(Transform transform, float val, bool useRecursion = true) { }

	private static void alphaRecursiveSprite(Transform transform, float val) { }

	private void callback() { }

	public void callOnCompletes() { }

	[Obsolete("Use 'LeanTween.cancel( id )' instead")]
	public LTDescr cancel(GameObject gameObject) { }

	private static void colorRecursive(RectTransform rectTransform, Color toColor) { }

	private static void colorRecursive(Transform transform, Color toColor, bool useRecursion = true) { }

	private static void colorRecursiveSprite(Transform transform, Color toColor) { }

	private Vector3 easeInBack() { }

	private Vector3 easeInBounce() { }

	private Vector3 easeInCirc() { }

	private Vector3 easeInCubic() { }

	private Vector3 easeInElastic() { }

	private Vector3 easeInExpo() { }

	private Vector3 easeInOutBack() { }

	private Vector3 easeInOutBounce() { }

	private Vector3 easeInOutCirc() { }

	private Vector3 easeInOutCubic() { }

	private Vector3 easeInOutElastic() { }

	private Vector3 easeInOutExpo() { }

	private Vector3 easeInOutQuad() { }

	private Vector3 easeInOutQuart() { }

	private Vector3 easeInOutQuint() { }

	private Vector3 easeInOutSine() { }

	private Vector3 easeInQuad() { }

	private Vector3 easeInQuart() { }

	private Vector3 easeInQuint() { }

	private Vector3 easeInSine() { }

	private Vector3 easeLinear() { }

	private Vector3 easeOutBack() { }

	private Vector3 easeOutBounce() { }

	private Vector3 easeOutCirc() { }

	private Vector3 easeOutCubic() { }

	private Vector3 easeOutElastic() { }

	private Vector3 easeOutExpo() { }

	private Vector3 easeOutQuad() { }

	private Vector3 easeOutQuart() { }

	private Vector3 easeOutQuint() { }

	private Vector3 easeOutSine() { }

	private Vector3 easeSpring() { }

	[CompilerGenerated]
	public ActionMethodDelegate get_easeInternal() { }

	public Vector3 get_from() { }

	public int get_id() { }

	[CompilerGenerated]
	public ActionMethodDelegate get_initInternal() { }

	public LTDescrOptional get_optional() { }

	public Vector3 get_to() { }

	public Transform get_toTrans() { }

	public int get_uniqueId() { }

	private void init() { }

	private void initCanvasRotateAround() { }

	private void initFromInternal() { }

	private void initSpeed() { }

	public LTDescr pause() { }

	public void reset() { }

	public LTDescr resume() { }

	[CompilerGenerated]
	public void set_easeInternal(ActionMethodDelegate value) { }

	public void set_from(Vector3 value) { }

	[CompilerGenerated]
	public void set_initInternal(ActionMethodDelegate value) { }

	public void set_optional(LTDescrOptional value) { }

	public void set_to(Vector3 value) { }

	public LTDescr setAlpha() { }

	public LTDescr setAlphaVertex() { }

	public LTDescr setAudio(object audio) { }

	public LTDescr setAxis(Vector3 axis) { }

	public LTDescr setCallback() { }

	public LTDescr setCallbackColor() { }

	public LTDescr setCanvasAlpha() { }

	public LTDescr setCanvasColor() { }

	public LTDescr setCanvasGroupAlpha() { }

	public LTDescr setCanvasMove() { }

	public LTDescr setCanvasMoveX() { }

	public LTDescr setCanvasMoveY() { }

	public LTDescr setCanvasMoveZ() { }

	public LTDescr setCanvasPlaySprite() { }

	public LTDescr setCanvasRotateAround() { }

	public LTDescr setCanvasRotateAroundLocal() { }

	public LTDescr setCanvasScale() { }

	public LTDescr setCanvasSizeDelta() { }

	public LTDescr setColor() { }

	public LTDescr setDelay(float delay) { }

	public LTDescr setDelayedSound() { }

	public LTDescr setDestroyOnComplete(bool doesDestroy) { }

	public LTDescr setDiff(Vector3 diff) { }

	public LTDescr setDirection(float direction) { }

	public LTDescr setEase(AnimationCurve easeCurve) { }

	public LTDescr setEase(LeanTweenType easeType) { }

	public LTDescr setEaseInBack() { }

	public LTDescr setEaseInBounce() { }

	public LTDescr setEaseInCirc() { }

	public LTDescr setEaseInCubic() { }

	public LTDescr setEaseInElastic() { }

	public LTDescr setEaseInExpo() { }

	public LTDescr setEaseInOutBack() { }

	public LTDescr setEaseInOutBounce() { }

	public LTDescr setEaseInOutCirc() { }

	public LTDescr setEaseInOutCubic() { }

	public LTDescr setEaseInOutElastic() { }

	public LTDescr setEaseInOutExpo() { }

	public LTDescr setEaseInOutQuad() { }

	public LTDescr setEaseInOutQuart() { }

	public LTDescr setEaseInOutQuint() { }

	public LTDescr setEaseInOutSine() { }

	public LTDescr setEaseInQuad() { }

	public LTDescr setEaseInQuart() { }

	public LTDescr setEaseInQuint() { }

	public LTDescr setEaseInSine() { }

	public LTDescr setEaseLinear() { }

	public LTDescr setEaseOutBack() { }

	public LTDescr setEaseOutBounce() { }

	public LTDescr setEaseOutCirc() { }

	public LTDescr setEaseOutCubic() { }

	public LTDescr setEaseOutElastic() { }

	public LTDescr setEaseOutExpo() { }

	public LTDescr setEaseOutQuad() { }

	public LTDescr setEaseOutQuart() { }

	public LTDescr setEaseOutQuint() { }

	public LTDescr setEaseOutSine() { }

	public LTDescr setEasePunch() { }

	public LTDescr setEaseShake() { }

	public LTDescr setEaseSpring() { }

	public LTDescr setFollow() { }

	public LTDescr setFrameRate(float frameRate) { }

	public LTDescr setFrom(float from) { }

	public LTDescr setFrom(Vector3 from) { }

	public LTDescr setFromColor(Color col) { }

	public LTDescr setGUIAlpha() { }

	public LTDescr setGUIMove() { }

	public LTDescr setGUIMoveMargin() { }

	public LTDescr setGUIRotate() { }

	public LTDescr setGUIScale() { }

	public LTDescr setHasInitialized(bool has) { }

	public LTDescr setId(uint id, uint global_counter) { }

	public LTDescr setIgnoreTimeScale(bool useUnScaledTime) { }

	public LTDescr setLoopClamp() { }

	public LTDescr setLoopClamp(int loops) { }

	public LTDescr setLoopCount(int loopCount) { }

	public LTDescr setLoopOnce() { }

	public LTDescr setLoopPingPong() { }

	public LTDescr setLoopPingPong(int loops) { }

	public LTDescr setLoopType(LeanTweenType loopType) { }

	public LTDescr setMove() { }

	public LTDescr setMoveCurved() { }

	public LTDescr setMoveCurvedLocal() { }

	public LTDescr setMoveLocal() { }

	public LTDescr setMoveLocalX() { }

	public LTDescr setMoveLocalY() { }

	public LTDescr setMoveLocalZ() { }

	public LTDescr setMoveSpline() { }

	public LTDescr setMoveSplineLocal() { }

	public LTDescr setMoveToTransform() { }

	public LTDescr setMoveX() { }

	public LTDescr setMoveY() { }

	public LTDescr setMoveZ() { }

	public LTDescr setOffset(Vector3 offset) { }

	public LTDescr setOnComplete(Action onComplete) { }

	public LTDescr setOnComplete(Action<Object> onComplete, object onCompleteParam) { }

	public LTDescr setOnComplete(Action<Object> onComplete) { }

	public LTDescr setOnCompleteOnRepeat(bool isOn) { }

	public LTDescr setOnCompleteOnStart(bool isOn) { }

	public LTDescr setOnCompleteParam(object onCompleteParam) { }

	public LTDescr setOnStart(Action onStart) { }

	public LTDescr setOnUpdate(Action<Single> onUpdate) { }

	public LTDescr setOnUpdate(Action<Vector2> onUpdate, object onUpdateParam = null) { }

	public LTDescr setOnUpdate(Action<Vector3> onUpdate, object onUpdateParam = null) { }

	public LTDescr setOnUpdate(Action<Single, Object> onUpdate, object onUpdateParam = null) { }

	public LTDescr setOnUpdate(Action<Color, Object> onUpdate) { }

	public LTDescr setOnUpdate(Action<Color> onUpdate) { }

	public LTDescr setOnUpdate(Action<Vector3, Object> onUpdate, object onUpdateParam = null) { }

	public LTDescr setOnUpdateColor(Action<Color, Object> onUpdate) { }

	public LTDescr setOnUpdateColor(Action<Color> onUpdate) { }

	public LTDescr setOnUpdateObject(Action<Single, Object> onUpdate) { }

	public LTDescr setOnUpdateParam(object onUpdateParam) { }

	public LTDescr setOnUpdateRatio(Action<Single, Single> onUpdate) { }

	public LTDescr setOnUpdateVector2(Action<Vector2> onUpdate) { }

	public LTDescr setOnUpdateVector3(Action<Vector3> onUpdate) { }

	public LTDescr setOrientToPath(bool doesOrient) { }

	public LTDescr setOrientToPath2d(bool doesOrient2d) { }

	public LTDescr setOvershoot(float overshoot) { }

	public LTDescr setPassed(float passed) { }

	public LTDescr setPath(LTBezierPath path) { }

	public LTDescr setPeriod(float period) { }

	public LTDescr setPoint(Vector3 point) { }

	public LTDescr setRect(LTRect rect) { }

	public LTDescr setRect(Rect rect) { }

	public LTDescr setRect(RectTransform rect) { }

	public LTDescr setRecursive(bool useRecursion) { }

	public LTDescr setRepeat(int repeat) { }

	public LTDescr setRotate() { }

	public LTDescr setRotateAround() { }

	public LTDescr setRotateAroundLocal() { }

	public LTDescr setRotateLocal() { }

	public LTDescr setRotateX() { }

	public LTDescr setRotateY() { }

	public LTDescr setRotateZ() { }

	public LTDescr setScale() { }

	public LTDescr setScale(float scale) { }

	public LTDescr setScaleX() { }

	public LTDescr setScaleY() { }

	public LTDescr setScaleZ() { }

	public LTDescr setSpeed(float speed) { }

	public LTDescr setSprites(Sprite[] sprites) { }

	public LTDescr setTarget(Transform trans) { }

	public LTDescr setTextAlpha() { }

	public LTDescr setTextColor() { }

	public LTDescr setTime(float time) { }

	public LTDescr setTo(Vector3 to) { }

	public LTDescr setTo(Transform to) { }

	public LTDescr setUseEstimatedTime(bool useEstimatedTime) { }

	public LTDescr setUseFrames(bool useFrames) { }

	public LTDescr setUseManualTime(bool useManualTime) { }

	public LTDescr setValue3() { }

	private static void textAlphaChildrenRecursive(Transform trans, float val, bool useRecursion = true) { }

	private static void textAlphaRecursive(Transform trans, float val, bool useRecursion = true) { }

	private static void textColorRecursive(Transform trans, Color toColor) { }

	public virtual string ToString() { }

	private static Color tweenColor(LTDescr tween, float val) { }

	private Vector3 tweenOnCurve() { }

	public bool updateInternal() { }

	public LTDescr updateNow() { }

}

