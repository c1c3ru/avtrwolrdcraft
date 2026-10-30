namespace Game.Level;

public class LevelHelicopter : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass52_0
	{
		public LevelHelicopter <>4__this; //Field offset: 0x10
		public Action onComplete; //Field offset: 0x18

		public <>c__DisplayClass52_0() { }

		internal void <PlayFlyOutOutro>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass56_0
	{
		public float flareDistance; //Field offset: 0x10
		public LevelHelicopter <>4__this; //Field offset: 0x18

		public <>c__DisplayClass56_0() { }

		internal void <Land>b__1() { }

	}

	private enum HelicopterState
	{
		Ground = 0,
		Flying = 1,
	}

	[SerializeField]
	private HelicopterState _helicopterState; //Field offset: 0x20
	[SerializeField]
	private float _minYPosition; //Field offset: 0x24
	[SerializeField]
	private float _maxYPosition; //Field offset: 0x28
	[SerializeField]
	private float _flightSpeed; //Field offset: 0x2C
	[SerializeField]
	private float _takeOffDelay; //Field offset: 0x30
	[SerializeField]
	private float _landingDelay; //Field offset: 0x34
	[SerializeField]
	private float _postLandingDelay; //Field offset: 0x38
	[SerializeField]
	private float _tiltAngle; //Field offset: 0x3C
	[SerializeField]
	private float _tiltDuration; //Field offset: 0x40
	[SerializeField]
	private float _takeOffHopDistance; //Field offset: 0x44
	[SerializeField]
	private float _landingFlareRatio; //Field offset: 0x48
	[SerializeField]
	private float _landingFlareSpeedMultiplier; //Field offset: 0x4C
	[SerializeField]
	private float _landingLevelOutDuration; //Field offset: 0x50
	[SerializeField]
	private bool _startsAirborne; //Field offset: 0x54
	[SerializeField]
	private GameObject _clickBlocker; //Field offset: 0x58
	[SerializeField]
	private LevelSitArea[] _seatAreas; //Field offset: 0x60
	[SerializeField]
	private LevelLevelSwitcher _destinationSwitcher; //Field offset: 0x68
	[SerializeField]
	private float _idleFlightBobHeight; //Field offset: 0x70
	[SerializeField]
	private float _idleFlightBobDuration; //Field offset: 0x74
	[SerializeField]
	private float _idleFlightBoostBobHeight; //Field offset: 0x78
	[SerializeField]
	private float _idleFlightBoostBobDuration; //Field offset: 0x7C
	[SerializeField]
	private float _idleFlightBoostTiltAngle; //Field offset: 0x80
	[SerializeField]
	private bool _flyInOnStart; //Field offset: 0x84
	[SerializeField]
	private float _flyInOffsetX; //Field offset: 0x88
	[SerializeField]
	private float _flyInDuration; //Field offset: 0x8C
	[SerializeField]
	private float _flyOutOffsetX; //Field offset: 0x90
	[SerializeField]
	private float _flyOutDuration; //Field offset: 0x94
	private bool _isGrounded; //Field offset: 0x98
	private bool _isFlightTransitioning; //Field offset: 0x99
	private int _movementTweenId; //Field offset: 0x9C
	private int _delayTweenId; //Field offset: 0xA0
	private int _postLandingDelayTweenId; //Field offset: 0xA4
	private int _tiltTweenId; //Field offset: 0xA8
	private int _idleFlightTweenId; //Field offset: 0xAC
	private int _idleFlightBoostTweenId; //Field offset: 0xB0
	private int _flyTransitionTweenId; //Field offset: 0xB4
	private float _flightHomeY; //Field offset: 0xB8
	private float _flightHomeX; //Field offset: 0xBC
	public UnityEvent OnTakeOffPreBeginAction; //Field offset: 0xC0
	public UnityEvent OnTakeOffBeginAction; //Field offset: 0xC8
	public UnityEvent OnTakeOffCompleteAction; //Field offset: 0xD0
	public UnityEvent OnLandingPreBeginAction; //Field offset: 0xD8
	public UnityEvent OnLandingCompleteAction; //Field offset: 0xE0
	public UnityEvent OnPostLandingCompleteAction; //Field offset: 0xE8

	public LevelHelicopter() { }

	[CompilerGenerated]
	private void <BoostFlightMovement>b__50_0() { }

	[CompilerGenerated]
	private void <Land>b__56_0() { }

	[CompilerGenerated]
	private void <Land>b__56_2() { }

	[CompilerGenerated]
	private void <Land>b__56_3() { }

	[CompilerGenerated]
	private void <PlayFlyInIntro>b__51_0() { }

	[CompilerGenerated]
	private void <TakeOff>b__55_0() { }

	[CompilerGenerated]
	private void <TakeOff>b__55_1() { }

	[CompilerGenerated]
	private void <TakeOff>b__55_2() { }

	private void Awake() { }

	public void BoostFlightMovement(float duration) { }

	private void CancelMovementTweens() { }

	private float GetFlightDuration(float targetY) { }

	public float GetMaxYPosition() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public bool IsGrounded() { }

	public void Land() { }

	private void OnDestroy() { }

	private void OnLevelPermanentPostInit() { }

	private void OnLevelPostInit() { }

	private void PlayFlyInIntro() { }

	public void PlayFlyOutAndTransportSeatedAvatars() { }

	private void PlayFlyOutOutro(Action onComplete) { }

	private void PrepareSeatsForNextFloor() { }

	private void SeatAvatarsRestoredByCrossLevelDropAreas() { }

	private void SetClickBlocker(bool isActive) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SetRotationZ(float angle) { }

	private void SetX(float x) { }

	private void SetY(float y) { }

	private void StartIdleFlight() { }

	private void StartIdleFlight(float bobHeight, float bobDuration) { }

	public void TakeOff() { }

	private void Tilt(float angle, float duration) { }

	private void Tilt(float angle) { }

	public void TransportSeatedAvatarsAndLoadScene() { }

}

