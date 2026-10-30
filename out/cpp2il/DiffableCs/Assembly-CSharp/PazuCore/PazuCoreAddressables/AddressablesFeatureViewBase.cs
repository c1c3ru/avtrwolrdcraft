namespace PazuCore.PazuCoreAddressables;

public abstract class AddressablesFeatureViewBase : MonoBehaviour
{
	internal enum OrientationType
	{
		None = 0,
		Portrait = 1,
		Landscape = 2,
	}

	[CompilerGenerated]
	private static Action<AddressablesFeatureType> OnOpenAction; //Field offset: 0x0
	[CompilerGenerated]
	private static Action<AddressablesFeatureType> OnCloseAction; //Field offset: 0x8
	[SerializeField]
	private OrientationType _orientationType; //Field offset: 0x20
	[SerializeField]
	private bool _shouldMuteGameSound; //Field offset: 0x24
	[SerializeField]
	private bool _removeContextOnDestroy; //Field offset: 0x25
	[SerializeField]
	private string _analyticsID; //Field offset: 0x28
	[SerializeField]
	private UnityEvent _onCreated; //Field offset: 0x30
	private AddressablesFeatureBase _manager; //Field offset: 0x38
	[CompilerGenerated]
	private bool <IsAddressable>k__BackingField; //Field offset: 0x40

	public static event Action<AddressablesFeatureType> OnCloseAction
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	public static event Action<AddressablesFeatureType> OnOpenAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public string AnalyticsID
	{
		 get { } //Length: 8
	}

	public private bool IsAddressable
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	protected AddressablesFeatureViewBase() { }

	[CompilerGenerated]
	public static void add_OnCloseAction(Action<AddressablesFeatureType> value) { }

	[CompilerGenerated]
	public static void add_OnOpenAction(Action<AddressablesFeatureType> value) { }

	protected override void Awake() { }

	public string get_AnalyticsID() { }

	[CompilerGenerated]
	public bool get_IsAddressable() { }

	public OrientationType GetOrientationType() { }

	public void Init(AddressablesFeatureBase manager, bool isAddressable) { }

	public void OnCreated() { }

	protected override void OnDestroy() { }

	[CompilerGenerated]
	public static void remove_OnCloseAction(Action<AddressablesFeatureType> value) { }

	[CompilerGenerated]
	public static void remove_OnOpenAction(Action<AddressablesFeatureType> value) { }

	[CompilerGenerated]
	private void set_IsAddressable(bool value) { }

}

