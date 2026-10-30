namespace Game.Level;

public class LevelKayak : LevelItem, IHasDragBehaviorInsideWaterArea
{
	private const string ANIMATION_NAME = "Paddling"; //Field offset: 0x0
	[SerializeField]
	private LevelSitArea _sitArea; //Field offset: 0x348
	[SerializeField]
	private LevelPaddleArea _paddleArea; //Field offset: 0x350
	private LevelPaddle _levelPaddle; //Field offset: 0x358

	public LevelKayak() { }

	private void ApplyOnCharacter(Action<LevelCharacter> action) { }

	private void OnBeginDragWithCharacter(LevelCharacter character) { }

	private void OnEndDragWithCharacter(LevelCharacter character) { }

	private void OnGetOutOfWater(LevelCharacter character) { }

	private override void PWC.Level.Water.IHasDragBehaviorInsideWaterArea.OnBeginDragWhileInWater(LevelWaterArea waterArea, PointerEventData eventData) { }

	private override void PWC.Level.Water.IHasDragBehaviorInsideWaterArea.OnEndDragWhileInWater(LevelWaterArea waterArea, PointerEventData eventData) { }

	private override void PWC.Level.Water.IHasDragBehaviorInsideWaterArea.OnGettingOutOfWater(LevelWaterArea waterArea) { }

	private void ReturnPaddleToItsArea() { }

}

