namespace Game.Level;

public class LevelPaddle : LevelItem
{
	[SerializeField]
	private GameObject _sprite; //Field offset: 0x348

	public LevelPaddle() { }

	protected virtual void OnBeginLand(LevelDropArea dropArea) { }

	private void OnKayakSetActive(bool value, bool snap) { }

	protected virtual void OnLevelPostInit() { }

	protected virtual bool ShouldTryFixFlippedStateOnFlippedDropAreaBeginLand() { }

	protected virtual void TweenToProperPositionOnDropArea(Vector2 position, LevelDropArea dropArea, bool useJumpTween = true, Nullable<Vector2> overrideLocalPositionDestination = null) { }

}

