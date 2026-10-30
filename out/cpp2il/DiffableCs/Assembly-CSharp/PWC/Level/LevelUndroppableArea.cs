namespace PWC.Level;

public class LevelUndroppableArea : LevelConsumerAreaBase
{
	public static readonly List<LevelUndroppableArea> List; //Field offset: 0x0
	[SerializeField]
	private float _minItemsHeight; //Field offset: 0x54
	[SerializeField]
	private bool _dontAllowForgivingTest; //Field offset: 0x58
	[SerializeField]
	private bool _dontAffectIfItemIsHigher; //Field offset: 0x59

	public bool DontAffectIfItemIsHigher
	{
		 get { } //Length: 8
	}

	public bool DontAllowForgivingTest
	{
		 get { } //Length: 8
	}

	public float MinItemsHeight
	{
		 get { } //Length: 8
	}

	private static LevelUndroppableArea() { }

	public LevelUndroppableArea() { }

	public bool get_DontAffectIfItemIsHigher() { }

	public bool get_DontAllowForgivingTest() { }

	public float get_MinItemsHeight() { }

	public float GetDroppableY(Bounds1D fromXBounds) { }

	protected virtual void OnDisable() { }

	protected virtual void OnEnable() { }

	public static void SortedUndroppableAreas() { }

}

