namespace Game.Level.ContextualAnimation;

public abstract class LevelCASpecialClothingSpineSkinHandler : LevelCASpineSkinHandlerBase, IHasPersistentData, IRequirePDSceneObject
{
	protected string _skinNumber; //Field offset: 0x98
	protected string _skinNamePath; //Field offset: 0xA0
	protected AvatarSpineSkinsManagerBase _spineSkinManager; //Field offset: 0xA8
	protected bool _didEventHappened; //Field offset: 0xB0
	protected bool _isSecondState; //Field offset: 0xB1
	private bool _isInitialized; //Field offset: 0xB2

	protected LevelCASpecialClothingSpineSkinHandler() { }

	public virtual bool AllowReturnToIdleAnimationWhenRemovedFromTarget() { }

	protected virtual void Awake() { }

	protected void EnsureInitialized() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public virtual int GetPriority() { }

	protected abstract int GetSpecialCategoryType() { }

	protected abstract String[] GetSwitchableTextures() { }

	protected abstract string GetTextureSurffix() { }

	protected void InitSkin() { }

	public virtual bool IsSilent() { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	protected override void OnSkinRemoved(string skinName) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	protected void SetSkin(ICATarget target, bool isModOn) { }

	protected override void Start() { }

	protected abstract void TakeOffClothing(ICATarget avatar) { }

	private void ToggleSkin(ICATarget target) { }

	protected override void UpdateTexture() { }

}

