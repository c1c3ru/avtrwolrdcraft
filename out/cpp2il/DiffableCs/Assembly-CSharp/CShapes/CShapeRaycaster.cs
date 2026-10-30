namespace CShapes;

[AddComponentMenu("Event/CShapes Raycaster")]
[RequireComponent(typeof(Camera))]
public class CShapeRaycaster : BaseRaycaster
{
	internal sealed class TryOverridePointPositionDelegate : MulticastDelegate
	{

		public TryOverridePointPositionDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(PointerEventData pointerEventData, out Vector2 position, AsyncCallback callback, object object) { }

		public override bool EndInvoke(out Vector2 position, IAsyncResult result) { }

		public override bool Invoke(PointerEventData pointerEventData, out Vector2 position) { }

	}

	private Camera _camera; //Field offset: 0x28
	[CompilerGenerated]
	private int <LastResultCount>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	private TryOverridePointPositionDelegate TryOverridePointPositionAction; //Field offset: 0x38
	[CompilerGenerated]
	private Action OnBeforeRaycastAction; //Field offset: 0x40

	public event Action OnBeforeRaycastAction
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public event TryOverridePointPositionDelegate TryOverridePointPositionAction
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public virtual Camera eventCamera
	{
		 get { } //Length: 132
	}

	public private int LastResultCount
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public CShapeRaycaster() { }

	[CompilerGenerated]
	public void add_OnBeforeRaycastAction(Action value) { }

	[CompilerGenerated]
	public void add_TryOverridePointPositionAction(TryOverridePointPositionDelegate value) { }

	public virtual Camera get_eventCamera() { }

	[CompilerGenerated]
	public int get_LastResultCount() { }

	private bool IsTouchBeginPhase(PointerEventData eventData) { }

	protected virtual void OnDestroy() { }

	public virtual void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList) { }

	[CompilerGenerated]
	public void remove_OnBeforeRaycastAction(Action value) { }

	[CompilerGenerated]
	public void remove_TryOverridePointPositionAction(TryOverridePointPositionDelegate value) { }

	[CompilerGenerated]
	private void set_LastResultCount(int value) { }

}

