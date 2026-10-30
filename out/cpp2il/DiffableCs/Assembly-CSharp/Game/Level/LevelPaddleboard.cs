namespace Game.Level;

public class LevelPaddleboard : LevelItem, IHasDragBehaviorInsideWaterArea
{
	private const string ANIMATION_NAME = "Peddleboard"; //Field offset: 0x0
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x348

	public LevelPaddleboard() { }

	private void ApplyOnCharacters(Action<LevelCharacter> action) { }

	private void OnBeginDragWithCharacter(LevelCharacter character) { }

	private void OnEndDragWithCharacter(LevelCharacter character) { }

	private override void PWC.Level.Water.IHasDragBehaviorInsideWaterArea.OnBeginDragWhileInWater(LevelWaterArea waterArea, PointerEventData eventData) { }

	private override void PWC.Level.Water.IHasDragBehaviorInsideWaterArea.OnEndDragWhileInWater(LevelWaterArea waterArea, PointerEventData eventData) { }

}

