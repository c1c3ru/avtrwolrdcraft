namespace Game.Level;

[AddComponentMenu(null)]
public class LevelSponge : LevelItem
{
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x348
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x350

	public LevelSponge() { }

	protected virtual void OnBeginDragInternal(PointerEventData eventData) { }

	protected virtual void OnEndDragInternal(PointerEventData eventData) { }

	public void ParticleSystemSetActive(bool value) { }

}

