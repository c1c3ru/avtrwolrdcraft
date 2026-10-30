namespace Game.Level;

public class LevelSafe : LevelStationaryItem
{
	[SerializeField]
	private LevelDoor _door; //Field offset: 0x60
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x68
	[SerializeField]
	private LevelSafePermutationNumber[] _numberButtons; //Field offset: 0x70
	private LitSpine _litSpine; //Field offset: 0x78

	public LevelSafe() { }

	private void AddSkin(Skin toSkin, string skinName) { }

	protected virtual void Awake() { }

	private bool CanOpenDoor() { }

	private void Init() { }

	protected virtual void OnDestroy() { }

	private void OnLevelPostInit() { }

	private void RefreshSkeletonAnimation() { }

	public void SyncView() { }

	public void TryOpen() { }

}

