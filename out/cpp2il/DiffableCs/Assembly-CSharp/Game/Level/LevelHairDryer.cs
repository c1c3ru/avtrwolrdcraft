namespace Game.Level;

[AddComponentMenu(null)]
public class LevelHairDryer : LevelItemOnCharacterBase
{
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x358
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x360

	public LevelHairDryer() { }

	[CompilerGenerated]
	private void <OnBeginDragInternal>b__2_0() { }

	protected virtual string GetCharacterAnimationName() { }

	protected virtual string GetCharacterBoneName() { }

	protected virtual void OnBeginDragInternal(PointerEventData eventData) { }

	protected virtual void OnEndDragInternal(PointerEventData eventData) { }

	private void ParticleSystemSetActive(bool value) { }

}

