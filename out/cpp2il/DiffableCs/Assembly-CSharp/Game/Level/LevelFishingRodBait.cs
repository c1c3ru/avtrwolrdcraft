namespace Game.Level;

public class LevelFishingRodBait : LevelItem
{
	[SerializeField]
	protected bool _useAltTargets; //Field offset: 0x342
	[SerializeField]
	protected Transform _hangPoint; //Field offset: 0x348
	[SerializeField]
	protected PDPrefabReference _targetPrefab; //Field offset: 0x350
	[SerializeField]
	protected LevelDropArea _targetDropArea; //Field offset: 0x358
	private LevelFishingRodBaitAltTargets _altTargets; //Field offset: 0x360

	public LevelDropArea TargetDropArea
	{
		 get { } //Length: 8
	}

	public LevelFishingRodBait() { }

	[CompilerGenerated]
	private void <TweenToProperPositionOnDropArea>b__13_0() { }

	protected virtual void Awake() { }

	public LevelDropArea get_TargetDropArea() { }

	public Transform GetHandPoint() { }

	public Vector2 GetLocalBaitPositionInBaitArea() { }

	public LevelDropArea GetTargetDropArea() { }

	public PDPrefabReference GetTargetPrefab() { }

	public override void HandleTarget(LevelItem levelItem) { }

	protected virtual void OnDestroy() { }

	protected virtual void OnLevelPostInit() { }

	private void OnTargetPickUp(LevelItem levelItem) { }

	private void SyncTargetIfExists(LevelFishingRod fishingRod) { }

	protected virtual void TweenToProperPositionOnDropArea(Vector2 position, LevelDropArea dropArea, bool useJumpTween = true, Nullable<Vector2> overrideLocalPositionDestination = null) { }

}

