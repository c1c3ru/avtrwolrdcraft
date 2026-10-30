namespace UnityEngine.EventSystems;

[RequireComponent(typeof(EventSystem))]
public abstract class BaseInputModule : UIBehaviour
{
	protected List<RaycastResult> m_RaycastResultCache; //Field offset: 0x20
	[SerializeField]
	private bool m_SendPointerHoverToParent; //Field offset: 0x28
	private AxisEventData m_AxisEventData; //Field offset: 0x30
	private EventSystem m_EventSystem; //Field offset: 0x38
	private BaseEventData m_BaseEventData; //Field offset: 0x40
	protected BaseInput m_InputOverride; //Field offset: 0x48
	private BaseInput m_DefaultInput; //Field offset: 0x50

	protected EventSystem eventSystem
	{
		 get { } //Length: 8
	}

	public BaseInput input
	{
		 get { } //Length: 560
	}

	public BaseInput inputOverride
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	protected private bool sendPointerHoverToParent
	{
		private get { } //Length: 8
		private set { } //Length: 12
	}

	protected BaseInputModule() { }

	public override void ActivateModule() { }

	public override int ConvertUIToolkitPointerId(PointerEventData sourcePointerData) { }

	public override void DeactivateModule() { }

	protected static MoveDirection DetermineMoveDirection(float x, float y) { }

	protected static MoveDirection DetermineMoveDirection(float x, float y, float deadZone) { }

	protected static GameObject FindCommonRoot(GameObject g1, GameObject g2) { }

	protected static RaycastResult FindFirstRaycast(List<RaycastResult> candidates) { }

	protected EventSystem get_eventSystem() { }

	public BaseInput get_input() { }

	public BaseInput get_inputOverride() { }

	protected private bool get_sendPointerHoverToParent() { }

	protected override AxisEventData GetAxisEventData(float x, float y, float moveDeadZone) { }

	protected override BaseEventData GetBaseEventData() { }

	protected void HandlePointerExitAndEnter(PointerEventData currentPointerData, GameObject newEnterTarget) { }

	public override bool IsModuleSupported() { }

	public override bool IsPointerOverGameObject(int pointerId) { }

	protected virtual void OnDisable() { }

	protected virtual void OnEnable() { }

	public abstract void Process() { }

	public void set_inputOverride(BaseInput value) { }

	protected private void set_sendPointerHoverToParent(bool value) { }

	public override bool ShouldActivateModule() { }

	public override void UpdateModule() { }

}

