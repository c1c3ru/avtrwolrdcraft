namespace Game.Level.BarbershopMachine;

public class LevelBarbershopMachine : MonoBehaviour, ILevelMakerUIMenuItem
{
	private class PackHairData
	{
		public TextAsset HairData; //Field offset: 0x10
		public InventoryFlagType FlagType; //Field offset: 0x18

		public PackHairData() { }

	}

	[SerializeField]
	private int _skinId; //Field offset: 0x20
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x28
	[SerializeField]
	private TextAsset _dataTextAsset; //Field offset: 0x30
	[SerializeField]
	private LevelBarbershopMachineTablet _tablet; //Field offset: 0x38
	[SerializeField]
	private LevelSitArea _sitArea; //Field offset: 0x40
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x48
	[SerializeField]
	private PackHairData[] _packHairData; //Field offset: 0x50
	[SerializeField]
	private GameObject _premiumFront; //Field offset: 0x58
	private LevelBarbershopMachineHairsData _data; //Field offset: 0x60
	private Skin _skin; //Field offset: 0x68
	private int _changeHairTweenId; //Field offset: 0x70
	private LevelCharacter _currentCharacter; //Field offset: 0x78
	[CompilerGenerated]
	private bool <IsInProgress>k__BackingField; //Field offset: 0x80

	public private bool IsInProgress
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public LevelBarbershopMachine() { }

	[CompilerGenerated]
	private void <Init>b__20_0() { }

	[CompilerGenerated]
	private void <OnGoButtonClick>b__33_0(TrackEntry _) { }

	[CompilerGenerated]
	private void <OnGoButtonClick>b__33_1() { }

	private void AddPackHairDataIfNeeded() { }

	private void AddSkin(string skinName, bool refreshSpine = false) { }

	private void Awake() { }

	[CompilerGenerated]
	public bool get_IsInProgress() { }

	public Hair GetHairData(int index) { }

	public int GetHairsCout() { }

	private void Init() { }

	private void OnAvatarEndDrop(LevelAvatarRestAreaBase restArea, ILevelAvatar avatar) { }

	private void OnAvatarPickUp(LevelAvatarRestAreaBase restArea, ILevelAvatar avatar) { }

	private void OnDestroy() { }

	public void OnGoButtonClick() { }

	private void OnLevelPostInit() { }

	private override void PWC.Level.Maker.ILevelMakerUIMenuItem.OnCreatedInsideUIItem() { }

	private void RefreshSkeletonAnimation() { }

	[CompilerGenerated]
	private void set_IsInProgress(bool value) { }

	private void SetGoButtonAppearance(bool interactable) { }

	public void SetHair(int index, AvatarSpineSkinsManagerBase skinsManager, bool isMaksed, bool saveData = false) { }

	private void SetHair(Hair hairData, AvatarSpineSkinsManagerBase skinsManager, bool isMaksed, bool saveData = false) { }

	public int SetHairBySkinName(string skinName, AvatarSpineSkinsManagerBase skinsManager, bool isMaksed, bool saveData = false) { }

	private void TryOverrideOnClaimSuccess(StoreClaimItemCloudResponse response, ref bool didOverride) { }

}

