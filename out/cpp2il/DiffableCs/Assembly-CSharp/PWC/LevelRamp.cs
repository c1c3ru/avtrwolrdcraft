namespace PWC;

public class LevelRamp : LevelConsumerAreaBase
{
	internal sealed class ChangeDiractionAction : MulticastDelegate
	{

		public ChangeDiractionAction(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(bool isRTL, AsyncCallback callback, object object) { }

		public override void EndInvoke(IAsyncResult result) { }

		public override void Invoke(bool isRTL) { }

	}

	private enum Direction
	{
		LTR = 0,
		RTL = 1,
	}

	internal enum Environment
	{
		Normal = 0,
		Snow = 1,
	}

	internal enum RampType
	{
		None = 0,
		Ramp = 1,
		Rail = 2,
		Moggles = 3,
	}

	private class RiderData
	{
		public int currentSegmentIndex; //Field offset: 0x10
		public float slideStartHeight; //Field offset: 0x14
		public float currentT; //Field offset: 0x18
		public int firstsSegmentOfFalling; //Field offset: 0x1C
		public Direction dir; //Field offset: 0x20
		public ChangeDiractionAction changeDiractionCallback; //Field offset: 0x28

		public RiderData() { }

	}

	private const float MIN_DT = 0,02; //Field offset: 0x0
	private const float MAX_DT = 0,4; //Field offset: 0x0
	private const float SPEED_FACTOR = 0,33333334; //Field offset: 0x0
	[SerializeField]
	private bool _isFlipped; //Field offset: 0x51
	[SerializeField]
	private SortingGroup _sortingGroup; //Field offset: 0x58
	[SerializeField]
	private float _minHeightOfRamp; //Field offset: 0x60
	[SerializeField]
	private RampType _type; //Field offset: 0x64
	[SerializeField]
	private LevelRamp _nextRamp; //Field offset: 0x68
	[SerializeField]
	private bool _isDropAreaAnimationRouteOverride; //Field offset: 0x70
	[ConditionalField("_isDropAreaAnimationRouteOverride", True, True, (array) null)]
	[SerializeField]
	private Transform _point; //Field offset: 0x78
	[ConditionalField("_isDropAreaAnimationRouteOverride", True, True, (array) null)]
	[SerializeField]
	private float _timeToPoint; //Field offset: 0x80
	[SerializeField]
	private float _speedMultiplier; //Field offset: 0x84
	[SerializeField]
	private bool _isOneSidedRamp; //Field offset: 0x88
	[SerializeField]
	private LevelDropArea _landingArea; //Field offset: 0x90
	[SerializeField]
	private Environment _environment; //Field offset: 0x98
	[SerializeField]
	private float _rampEnteringDutation; //Field offset: 0x9C
	[SerializeField]
	private bool _isForceConstantSpeed; //Field offset: 0xA0
	private Vector2[] _rampPoints; //Field offset: 0xA8
	private Single[] _normalAnglesAtPoints; //Field offset: 0xB0
	private Single[] _normalAnglesOfSegments; //Field offset: 0xB8
	private Single[] _slopeFactorOfSegments; //Field offset: 0xC0
	private Dictionary<String, RiderData> _ridersDataDictionary; //Field offset: 0xC8
	[CompilerGenerated]
	private Action<LevelItem> OnItemStartSlideAction; //Field offset: 0xD0
	[CompilerGenerated]
	private Action<LevelItem> OnItemEndSlideAction; //Field offset: 0xD8

	public event Action<LevelItem> OnItemEndSlideAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<LevelItem> OnItemStartSlideAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public Environment GetEnvironment
	{
		 get { } //Length: 8
	}

	public bool IsDropAreaAnimationRouteOverride
	{
		 get { } //Length: 8
	}

	public LevelDropArea LandingArea
	{
		 get { } //Length: 8
	}

	public LevelRamp NextRamp
	{
		 get { } //Length: 8
	}

	public Transform Point
	{
		 get { } //Length: 8
	}

	public float RampEnteringDutation
	{
		 get { } //Length: 8
	}

	public SortingGroup SortingGroup
	{
		 get { } //Length: 8
	}

	public float TimeToPoint
	{
		 get { } //Length: 8
	}

	public RampType Type
	{
		 get { } //Length: 8
	}

	public LevelRamp() { }

	[CompilerGenerated]
	public void add_OnItemEndSlideAction(Action<LevelItem> value) { }

	[CompilerGenerated]
	public void add_OnItemStartSlideAction(Action<LevelItem> value) { }

	protected virtual void Awake() { }

	private void CalculateClosestPoint(Vector2 point, out int segmentIndex, out float t, out Vector2 closestPoint) { }

	private void CalculateNormalAnglesForEachPoint() { }

	private float CalculateSlopeFactor(int segmentIndex) { }

	public virtual bool CanConsumeItem(LevelItem levelItem) { }

	private float FindAngleFromPoints(Vector2 A, Vector2 B) { }

	public Environment get_GetEnvironment() { }

	public bool get_IsDropAreaAnimationRouteOverride() { }

	public LevelDropArea get_LandingArea() { }

	public LevelRamp get_NextRamp() { }

	public Transform get_Point() { }

	public float get_RampEnteringDutation() { }

	public SortingGroup get_SortingGroup() { }

	public float get_TimeToPoint() { }

	public RampType get_Type() { }

	public void GetAngleAndClosestPointOfRamp(Vector2 skateBoardPos, out float angle, out Vector2 closestPoint) { }

	private float GetDistanceOfPointFromLine(Vector2 point, Vector2 A, Vector2 B, out float t, out Vector2 closestPoint) { }

	public bool GetNextPointWhileFalling(string sceneGUID, Vector2 skateBoardPos, out float nextAngle, out Vector2 nextPosition) { }

	private void GetPointOnRamp(string sceneGUID, out float nextAngle, out Vector2 nextPosition) { }

	public void OnEndSlide(LevelItem levelItem) { }

	public void OnStartSlide(LevelItem levelItem) { }

	[CompilerGenerated]
	public void remove_OnItemEndSlideAction(Action<LevelItem> value) { }

	[CompilerGenerated]
	public void remove_OnItemStartSlideAction(Action<LevelItem> value) { }

	private void SavePoints(Vector2[] points) { }

	public bool StartFalling(string sceneGUID, Vector2 skateBoardPos, out float angle, out Vector2 closestPoint, ChangeDiractionAction onChangeDirectionOfSlide) { }

}

