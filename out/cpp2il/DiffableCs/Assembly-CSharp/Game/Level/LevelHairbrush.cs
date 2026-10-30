namespace Game.Level;

[AddComponentMenu(null)]
public class LevelHairbrush : LevelItem
{
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x348

	public LevelHairbrush() { }

	protected virtual void OnBeginDragInternal(PointerEventData eventData) { }

	protected virtual void OnEndDragInternal(PointerEventData eventData) { }

}

