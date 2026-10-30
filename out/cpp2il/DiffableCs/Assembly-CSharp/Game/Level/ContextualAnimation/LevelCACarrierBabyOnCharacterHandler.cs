namespace Game.Level.ContextualAnimation;

public class LevelCACarrierBabyOnCharacterHandler : LevelCABabyOnCharacterHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98
	private ICarrierNotifiable _carrierHandler; //Field offset: 0xA0
	private string _carrierSkinName; //Field offset: 0xA8
	private bool _isSkinOn; //Field offset: 0xB0

	public LevelCACarrierBabyOnCharacterHandler() { }

	private void ApplyCarrierSkin() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	protected virtual string GetBoneName() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public void InitCarrier(ICarrierNotifiable carrierHandler, string carrierSkinName) { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	protected virtual void PlayBabyIdle() { }

	private void RemoveCarrierSkin() { }

	protected virtual bool ShouldDeferToCarrierSibling() { }

}

