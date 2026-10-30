namespace Game.Level;

[AddComponentMenu(null)]
public class LevelDiamond : LevelItem
{
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x348

	public LevelDiamond() { }

	protected virtual void OnBeginDragInternal(PointerEventData eventData) { }

	protected virtual void OnEndDragInternal(PointerEventData eventData) { }

}

