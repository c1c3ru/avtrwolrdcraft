namespace Game.Level;

[AddComponentMenu(null)]
public class LevelSoapBar : LevelItem
{
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x348
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x350

	public LevelSoapBar() { }

	protected virtual void OnBeginDragInternal(PointerEventData eventData) { }

	protected virtual void OnEndDragInternal(PointerEventData eventData) { }

}

