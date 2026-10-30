namespace PWC.LevelPhone.VehicleApp;

public class VehicleThumb : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass24_0
	{
		public Color color; //Field offset: 0x10
		public VehicleThumb <>4__this; //Field offset: 0x20

		public <>c__DisplayClass24_0() { }

		internal void <OverlaySetActive>b__0(float alphaValue) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass28_0
	{
		public Action onCompleteSetActiveAction; //Field offset: 0x10

		public <>c__DisplayClass28_0() { }

		internal void <Animate>b__0() { }

	}

	public const int NO_CAR_ID = -1; //Field offset: 0x0
	[CompilerGenerated]
	private static Action<VehicleData> OnVehicleThumbClickAction; //Field offset: 0x0
	[CompilerGenerated]
	private static Action<Int32> OnCarThumbClickAction; //Field offset: 0x8
	[SerializeField]
	private Image _image; //Field offset: 0x20
	[SerializeField]
	private SpriteRenderer _overlay; //Field offset: 0x28
	[SerializeField]
	private CarThumbVisual _carVisual; //Field offset: 0x30
	[SerializeField]
	private Sprite _carBackground; //Field offset: 0x38
	[SerializeField]
	private Sprite _defaultCarIcon; //Field offset: 0x40
	private int _tweenID; //Field offset: 0x48
	public VehicleData _vehicleData; //Field offset: 0x50
	[CompilerGenerated]
	private int <CarId>k__BackingField; //Field offset: 0x58

	public static event Action<Int32> OnCarThumbClickAction
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	public static event Action<VehicleData> OnVehicleThumbClickAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public private int CarId
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public bool IsPlayerCar
	{
		 get { } //Length: 16
	}

	public VehicleThumb() { }

	[CompilerGenerated]
	private bool <SyncOverlay>b__23_0(LevelPlayerVehicle x) { }

	[CompilerGenerated]
	public static void add_OnCarThumbClickAction(Action<Int32> value) { }

	[CompilerGenerated]
	public static void add_OnVehicleThumbClickAction(Action<VehicleData> value) { }

	public void Animate(bool value, float delay = 0, Action onCompleteSetActiveAction = null) { }

	private void Awake() { }

	[CompilerGenerated]
	public int get_CarId() { }

	public bool get_IsPlayerCar() { }

	private void OnDestroy() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	private void OnVehiclesPageSwipe() { }

	public void OverlaySetActive(bool value, bool isImmediate = false) { }

	[CompilerGenerated]
	public static void remove_OnCarThumbClickAction(Action<Int32> value) { }

	[CompilerGenerated]
	public static void remove_OnVehicleThumbClickAction(Action<VehicleData> value) { }

	[CompilerGenerated]
	private void set_CarId(int value) { }

	public void SetCarData(int carId) { }

	public void SetData(VehicleData vehicleData) { }

	private void ShowBreedIcon(int carId) { }

	private void SyncOverlay() { }

}

