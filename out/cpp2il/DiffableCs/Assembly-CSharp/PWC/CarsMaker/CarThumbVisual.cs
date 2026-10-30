namespace PWC.CarsMaker;

public class CarThumbVisual : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass14_0
	{
		public int topOrder; //Field offset: 0x10
		public CarThumbVisual <>4__this; //Field offset: 0x18
		public int shift; //Field offset: 0x20

		public <>c__DisplayClass14_0() { }

		internal void <ApplySorting>b__0(SortingGroup group) { }

		internal void <ApplySorting>b__1(SpriteRenderer renderer) { }

		internal void <ApplySorting>b__2(SortingGroup group) { }

		internal void <ApplySorting>b__3(SpriteRenderer renderer) { }

	}

	private static readonly CarCategoryType[] ACCESSORY_CATEGORIES; //Field offset: 0x0
	[SerializeField]
	private Transform _carParent; //Field offset: 0x20
	[SerializeField]
	private Vector2 _fitSize; //Field offset: 0x28
	[SerializeField]
	private Vector2 _offset; //Field offset: 0x30
	[SerializeField]
	private SpriteRenderer _sortingReference; //Field offset: 0x38
	[SerializeField]
	private int _sortingOrderOffset; //Field offset: 0x40
	private GameObject _carInstance; //Field offset: 0x48
	private CarView _carView; //Field offset: 0x50
	private SpriteRenderer[] _carRenderers; //Field offset: 0x58
	private readonly HashSet<SpriteRenderer> _accessoryRenderers; //Field offset: 0x60

	private Transform CarParent
	{
		private get { } //Length: 128
	}

	private static CarThumbVisual() { }

	public CarThumbVisual() { }

	private void ApplySorting() { }

	private void ClearCar() { }

	private void CollectAccessoryRenderers() { }

	private void FitToThumb() { }

	private Transform get_CarParent() { }

	private static SortingGroup GetSortingGroupAbove(Transform from, Transform root) { }

	public void Hide() { }

	private static bool IsActiveWithinCar(Transform transform, Transform root) { }

	private static bool IsWithin(Transform transform, Transform root) { }

	private bool Rebuild(string breed) { }

	public bool Show(int carId) { }

	private bool TryGetDrawnSize(out Vector2 size) { }

}

