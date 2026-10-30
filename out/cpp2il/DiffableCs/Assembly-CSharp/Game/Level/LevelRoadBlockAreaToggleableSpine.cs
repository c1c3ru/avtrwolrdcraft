namespace Game.Level;

[RequireComponent(typeof(LevelRoadBlockAreaHandler))]
public class LevelRoadBlockAreaToggleableSpine : LevelSimpleToggleableSpine
{
	private LevelRoadBlockAreaHandler blockAreaHandler; //Field offset: 0x80

	public LevelRoadBlockAreaToggleableSpine() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	public virtual void OnPointerClick(PointerEventData eventData) { }

}

