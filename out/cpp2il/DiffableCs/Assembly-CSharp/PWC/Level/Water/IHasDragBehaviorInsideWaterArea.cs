namespace PWC.Level.Water;

public interface IHasDragBehaviorInsideWaterArea
{

	public void OnBeginDragWhileInWater(LevelWaterArea waterArea, PointerEventData eventData) { }

	public void OnEndDragWhileInWater(LevelWaterArea waterArea, PointerEventData eventData) { }

	public void OnGettingOutOfWater(LevelWaterArea waterArea) { }

}

