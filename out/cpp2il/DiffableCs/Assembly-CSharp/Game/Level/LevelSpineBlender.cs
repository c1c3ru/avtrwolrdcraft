namespace Game.Level;

public class LevelSpineBlender : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerClickHandler, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass13_0
	{
		public LevelSpineBlender <>4__this; //Field offset: 0x10
		public TrackEntry trackEntry; //Field offset: 0x18
		public TrackEntryDelegate <>9__2; //Field offset: 0x20

		public <>c__DisplayClass13_0() { }

		internal void <OnPointerClick>b__0(TrackEntry x) { }

		internal void <OnPointerClick>b__1(TrackEntry y) { }

		internal void <OnPointerClick>b__2(TrackEntry y) { }

	}

	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x20
	[SerializeField]
	private LevelBlenderFoodDropArea _dropArea; //Field offset: 0x28
	[SerializeField]
	private GameObject _foodBlocker; //Field offset: 0x30
	[SerializeField]
	private SkeletonPartsRenderer _lid; //Field offset: 0x38
	[SerializeField]
	private LevelDrinkDispenserLiquid _liquid; //Field offset: 0x40
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x48
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x50
	[SerializeField]
	private string _slotName; //Field offset: 0x58
	private bool _isInteractable; //Field offset: 0x60
	private bool _isClosed; //Field offset: 0x61
	private bool _isFull; //Field offset: 0x62
	private Color _currentColor; //Field offset: 0x64

	public LevelSpineBlender() { }

	private void ColorLiquidSlot() { }

	private string GetIdleAnimationNameForPD() { }

	private Color GetLiquidColor(List<LevelItem> items) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void LiquidSetActive(bool value) { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void OnPointerDown(PointerEventData eventData) { }

	private TrackEntry SetAnimation() { }

	private void SetInteractable(bool value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void ToggleLidLayer(bool value) { }

}

