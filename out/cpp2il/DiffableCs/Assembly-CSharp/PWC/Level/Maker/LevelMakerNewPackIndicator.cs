namespace PWC.Level.Maker;

public class LevelMakerNewPackIndicator : GameUIElement, IPointerClickHandler, IEventSystemHandler
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_0
	{
		public EventSystem eventSystem; //Field offset: 0x10
		public LevelMakerNewPackIndicator <>4__this; //Field offset: 0x18
		public Coroutine coroutine; //Field offset: 0x20

		public <>c__DisplayClass6_0() { }

		internal void <UnityEngine.EventSystems.IPointerClickHandler.OnPointerClick>b__0() { }

		internal void <UnityEngine.EventSystems.IPointerClickHandler.OnPointerClick>b__1(TrackEntry x) { }

	}

	[SerializeField]
	[SpineAnimation(null, "_skeletonGraphic", True, False, False)]
	private string _clickAnimationName; //Field offset: 0x28
	[SerializeField]
	private SkeletonGraphic _skeletonGraphic; //Field offset: 0x30
	private LevelMakerCategoryButton _categoryButton; //Field offset: 0x38
	private string _packName; //Field offset: 0x40
	private DataType _dataType; //Field offset: 0x48

	public LevelMakerNewPackIndicator() { }

	public void Init(LevelMakerCategoryButton categoryButton, string packName, DataType dataType) { }

	private override void UnityEngine.EventSystems.IPointerClickHandler.OnPointerClick(PointerEventData eventData) { }

}

