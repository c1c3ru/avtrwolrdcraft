namespace Game.Level.ContextualAnimation;

public class LevelCACarrierDogOnCharacterHandler : LevelCAPetOnCharacterHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA0
	private ICarrierNotifiable _carrierHandler; //Field offset: 0xA8
	private string _carrierSkinName; //Field offset: 0xB0
	private bool _isSkinOn; //Field offset: 0xB8

	public LevelCACarrierDogOnCharacterHandler() { }

	private void ApplyCarrierSkin() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	protected virtual string GetBoneName() { }

	public virtual string GetFolderName() { }

	protected virtual string GetIdleAnimationName() { }

	public virtual string GetLockedAnimationName() { }

	protected virtual Nullable<Vector2> GetPivotOnBone() { }

	public void InitCarrier(ICarrierNotifiable carrierHandler, string carrierSkinName) { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	protected virtual void OnReadyPostLoad() { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	protected virtual void PlayPetIdle() { }

	private void RemoveCarrierSkin() { }

	protected virtual bool ShouldDeferToCarrierSibling() { }

}

