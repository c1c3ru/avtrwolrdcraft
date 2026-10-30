namespace PWC.CarsMaker;

public class CarSpriteAnimator : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass20_0
	{
		public Transform shakeTarget; //Field offset: 0x10
		public Vector3 restPosition; //Field offset: 0x18

		public <>c__DisplayClass20_0() { }

		internal void <ShakeEngineStart>b__0(float progress) { }

		internal void <ShakeEngineStart>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass22_0
	{
		public Transform targetTransform; //Field offset: 0x10
		public Vector3 authoredEuler; //Field offset: 0x18

		public <>c__DisplayClass22_0() { }

		internal void <TryTweenSpin>b__0(float angle) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass23_0
	{
		public CarSpriteAnimator <>4__this; //Field offset: 0x10
		public Renderer renderer; //Field offset: 0x18
		public int propertyId; //Field offset: 0x20

		public <>c__DisplayClass23_0() { }

		internal void <TweenShaderFloat>b__0(float value) { }

	}

	private const string ENGINE_STARTS_ANIMATION_NAME = "Idles/Engine_Starts"; //Field offset: 0x0
	private const float ENGINE_SHAKE_DURATION = 1,75; //Field offset: 0x0
	private const float ENGINE_SHAKE_STRENGTH = 0,03; //Field offset: 0x0
	private const float ENGINE_SHAKE_FREQUENCY = 25; //Field offset: 0x0
	[SerializeField]
	private List<CarSpriteAnimation> _animations; //Field offset: 0x20
	private Dictionary<String, CarSpriteAnimation> _animationsByName; //Field offset: 0x28
	private readonly Dictionary<Transform, Pose> _authoredPoseByTarget; //Field offset: 0x30
	private readonly Dictionary<Int32, List`1<Int32>> _tweenIdsByTrack; //Field offset: 0x38
	private readonly Dictionary<Int32, CarSpriteAnimation> _animationByTrack; //Field offset: 0x40
	private readonly HashSet<Int32> _stoppedTracks; //Field offset: 0x48
	[TupleElementNames(new IL2CPP_TYPE_STRING[] {"renderer", "propertyId"})]
	private readonly Dictionary<ValueTuple`2<Renderer, Int32>, Single> _authoredShaderFloatByTarget; //Field offset: 0x50
	private MaterialPropertyBlock _propertyBlock; //Field offset: 0x58
	private Nullable<Int32> _engineShakeTweenId; //Field offset: 0x60

	public CarSpriteAnimator() { }

	private static void ApplyVisibility(CarSpriteAnimation animation, bool isPlaying) { }

	private void Awake() { }

	private void CancelTrack(int trackIndex) { }

	private Pose CapturePose(Transform target) { }

	private static float GetShaderFloatValue(CarSpriteAnimationTarget target, Renderer renderer) { }

	private List<Int32> GetTweenIds(int trackIndex) { }

	public bool HasAnimation(string animationName) { }

	private void InitCollectionsIfNeeded() { }

	private static bool IsEndless(CarSpriteAnimation animation) { }

	public void PlayAnimation(int trackIndex, string animationName) { }

	private void RaiseStopped(int trackIndex, CarSpriteAnimation animation) { }

	private void RestoreAuthoredPose(CarSpriteAnimation animation) { }

	private void RestoreAuthoredShaderFloat(CarSpriteAnimationTarget target) { }

	private static void SetActive(List<GameObject> objects, bool value) { }

	private void SetShaderFloat(Renderer renderer, int propertyId, float value) { }

	private void ShakeEngineStart() { }

	public void StopAnimation(int trackIndex) { }

	private void StopEndlessTrack(int trackIndex) { }

	private bool TryTweenSpin(List<Int32> tweenIds, CarSpriteAnimationTarget target, Pose authoredPose) { }

	private void TweenShaderFloat(List<Int32> tweenIds, CarSpriteAnimation animation, CarSpriteAnimationTarget target) { }

	private void TweenTargets(int trackIndex, CarSpriteAnimation animation) { }

}

