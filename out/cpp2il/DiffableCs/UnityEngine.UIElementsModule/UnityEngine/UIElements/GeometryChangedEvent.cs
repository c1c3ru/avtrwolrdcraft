namespace UnityEngine.UIElements;

[EventCategory(EventCategory::Geometry (6))]
public class GeometryChangedEvent : EventBase<GeometryChangedEvent>
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0

		private static <>c() { }

		public <>c() { }

		internal GeometryChangedEvent <.cctor>b__0_0() { }

	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Rect <oldRect>k__BackingField; //Field offset: 0x84
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Rect <newRect>k__BackingField; //Field offset: 0x94
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private int <layoutPass>k__BackingField; //Field offset: 0xA4

	internal int layoutPass
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	public private Rect newRect
	{
		[CompilerGenerated]
		 get { } //Length: 12
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public private Rect oldRect
	{
		[CompilerGenerated]
		 get { } //Length: 12
		[CompilerGenerated]
		private set { } //Length: 12
	}

	private static GeometryChangedEvent() { }

	public GeometryChangedEvent() { }

	[CompilerGenerated]
	internal int get_layoutPass() { }

	[CompilerGenerated]
	public Rect get_newRect() { }

	[CompilerGenerated]
	public Rect get_oldRect() { }

	public static GeometryChangedEvent GetPooled(Rect oldRect, Rect newRect) { }

	protected virtual void Init() { }

	private void LocalInit() { }

	[CompilerGenerated]
	internal void set_layoutPass(int value) { }

	[CompilerGenerated]
	private void set_newRect(Rect value) { }

	[CompilerGenerated]
	private void set_oldRect(Rect value) { }

}

