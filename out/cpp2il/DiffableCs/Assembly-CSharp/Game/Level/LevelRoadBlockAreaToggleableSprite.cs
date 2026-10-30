namespace Game.Level;

[RequireComponent(typeof(LevelRoadBlockAreaHandler))]
public class LevelRoadBlockAreaToggleableSprite : LevelToggleableSprite
{
	private LevelRoadBlockAreaHandler blockAreaHandler; //Field offset: 0x88

	public LevelRoadBlockAreaToggleableSprite() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	public virtual void OnPointerClick(PointerEventData eventData) { }

}

