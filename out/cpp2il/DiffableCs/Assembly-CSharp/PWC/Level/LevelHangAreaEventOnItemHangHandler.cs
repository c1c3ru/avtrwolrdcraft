namespace PWC.Level;

public class LevelHangAreaEventOnItemHangHandler : MonoBehaviour
{
	[SerializeField]
	public UnityEvent OnItemHangAction; //Field offset: 0x20
	[SerializeField]
	public UnityEvent OnItemPickUpAction; //Field offset: 0x28
	[SerializeField]
	public UnityEvent OnHangAreaEmptyAction; //Field offset: 0x30
	[SerializeField]
	private bool _invokeOnLabel; //Field offset: 0x38
	[ConditionalField("_invokeOnLabel", True, True, (array) null)]
	[SerializeField]
	private string _labelToInvoke; //Field offset: 0x40
	protected LevelHangArea _hangArea; //Field offset: 0x48

	public LevelHangAreaEventOnItemHangHandler() { }

	protected override void Awake() { }

	private void OnDestroy() { }

	protected override void OnItemHang(LevelItem levelItem) { }

	protected override void OnItemPickUp(LevelItem levelItem) { }

}

