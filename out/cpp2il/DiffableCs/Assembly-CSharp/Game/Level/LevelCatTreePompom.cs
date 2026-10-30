namespace Game.Level;

public class LevelCatTreePompom : LevelStationaryItem, IPointerClickHandler, IEventSystemHandler
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public float angle; //Field offset: 0x10
		public LevelCatTreePompom <>4__this; //Field offset: 0x18

		public <>c__DisplayClass5_0() { }

		internal void <RotateRecursive>b__0() { }

	}

	private const float MAX_ANGLE = 20; //Field offset: 0x0
	private const float ANGLE_DIFF = 2,5; //Field offset: 0x0
	private const float MAX_TIME = 0,5; //Field offset: 0x0
	private bool _isInteractable; //Field offset: 0x60

	public LevelCatTreePompom() { }

	private float GetNextTeenAngle(float currentAngle) { }

	private float GetNextTweenTime(float currentAngle) { }

	public override void OnPointerClick(PointerEventData eventData) { }

	private void RotateRecursive(float angle, float time) { }

}

