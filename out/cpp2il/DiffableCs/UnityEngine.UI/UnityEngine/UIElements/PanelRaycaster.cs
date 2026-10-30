namespace UnityEngine.UIElements;

[AddComponentMenu("UI Toolkit/Panel Raycaster (UI Toolkit)")]
public class PanelRaycaster : BaseRaycaster, IRuntimePanelComponent
{
	private BaseRuntimePanel m_Panel; //Field offset: 0x28

	public virtual Camera eventCamera
	{
		 get { } //Length: 8
	}

	public override IPanel panel
	{
		 get { } //Length: 8
		 set { } //Length: 180
	}

	public virtual int renderOrderPriority
	{
		 get { } //Length: 116
	}

	private GameObject selectableGameObject
	{
		private get { } //Length: 24
	}

	public virtual int sortOrderPriority
	{
		 get { } //Length: 124
	}

	public PanelRaycaster() { }

	public virtual Camera get_eventCamera() { }

	public override IPanel get_panel() { }

	public virtual int get_renderOrderPriority() { }

	private GameObject get_selectableGameObject() { }

	public virtual int get_sortOrderPriority() { }

	private void OnPanelDestroyed() { }

	public virtual void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList) { }

	private void RegisterCallbacks() { }

	public override void set_panel(IPanel value) { }

	private void UnregisterCallbacks() { }

}

