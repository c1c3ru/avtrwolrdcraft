namespace PWC.Level;

[HideParentPropertiesInInspector(new IL2CPP_TYPE_STRING[] {"_sliderType", "_minValue", "_maxValue", "_minValueVector", "_maxValueVector"})]
public class LevelFreePositionSlider : LevelSlider
{
	[SerializeField]
	private Vector2 _xBounds; //Field offset: 0x1B8
	[SerializeField]
	private Vector2 _yBounds; //Field offset: 0x1C0
	[SerializeField]
	[Space]
	private bool _drawGizmos; //Field offset: 0x1C8
	[ConditionalField("_drawGizmos", True, True, (array) null)]
	[SerializeField]
	private Color _gizmosColor; //Field offset: 0x1CC

	public LevelFreePositionSlider() { }

	protected virtual void Awake() { }

	private void OnDrawGizmos() { }

	public virtual void OnPointerClick(PointerEventData eventData) { }

	protected virtual void OnSyncPosition(Vector2 pointerPosition) { }

}

