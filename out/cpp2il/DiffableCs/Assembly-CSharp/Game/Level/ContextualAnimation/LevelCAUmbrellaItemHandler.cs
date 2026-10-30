namespace Game.Level.ContextualAnimation;

public class LevelCAUmbrellaItemHandler : LevelCAItemWithSkinHandlerBase, IHasPersistentData, IRequirePDSceneObject
{
	private const string OPEN_UMBRELLA = "Open_Umbrella"; //Field offset: 0x0
	private const string CLOSE_UMBRELLA = "Close_Umbrella"; //Field offset: 0x0
	[SerializeField]
	private string _umbrellaSkinName; //Field offset: 0xB0
	[SerializeField]
	private LevelParticleSpawnOnDropArea _particles; //Field offset: 0xB8
	private bool _isOpen; //Field offset: 0xC0
	private ICATarget _holder; //Field offset: 0xC8
	private Action<Material> _sutInitSingleColortMaterial; //Field offset: 0xD0
	private readonly List<Skin> _addedSkins; //Field offset: 0xD8
	private readonly List<LevelCAConfig> _closedConfigs; //Field offset: 0xE0
	private readonly List<LevelCAConfig> _openedConfigs; //Field offset: 0xE8

	public LevelCAUmbrellaItemHandler() { }

	[CompilerGenerated]
	private void <UpdateSpineAsset>b__15_0(Material material) { }

	protected virtual void Awake() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	protected virtual string GetSkinName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsLockedToTarget() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	protected virtual void OnDestroy() { }

	private void OnParentSyncPosition(LevelItem levelItem, Vector2 position) { }

	private void OnRemovedFromAvatar(ILevelAvatar avatar) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	protected virtual void OnSkinAdded() { }

	private void OnSyncPosition(DragDropItemBase dragDropItemBase, Vector2 position) { }

	private void OnWeatherChange(WeatherType weatherType) { }

	private void RefreshSkeletonAnimation(LevelCharacter character) { }

	private void RemoveSkin(Skin mainSkin, Skin skinToRemove) { }

	private void SetMaterialStrightAlpha(Material material) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SyncParticlesPosition() { }

	private void SyncPosition() { }

	private void UpdateParticlePosition(LevelCharacter character) { }

	private void UpdateSpineAsset(LevelCharacter character) { }

}

