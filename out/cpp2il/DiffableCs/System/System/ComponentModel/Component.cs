namespace System.ComponentModel;

[ClassInterface(ClassInterfaceType::AutoDispatch (1))]
[ComVisible(True)]
[DesignerCategory("Component")]
public class Component : MarshalByRefObject, IComponent, IDisposable
{
	private static readonly object EventDisposed; //Field offset: 0x0
	private ISite site; //Field offset: 0x18
	private EventHandlerList events; //Field offset: 0x20

	protected override bool CanRaiseEvents
	{
		 get { } //Length: 8
	}

	internal bool CanRaiseEventsInternal
	{
		internal get { } //Length: 12
	}

	[Browsable(False)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility::Hidden (0))]
	protected bool DesignMode
	{
		 get { } //Length: 176
	}

	[Browsable(False)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility::Hidden (0))]
	public override ISite Site
	{
		 get { } //Length: 8
	}

	private static Component() { }

	public Component() { }

	public override void Dispose() { }

	protected override void Dispose(bool disposing) { }

	protected virtual void Finalize() { }

	protected override bool get_CanRaiseEvents() { }

	internal bool get_CanRaiseEventsInternal() { }

	protected bool get_DesignMode() { }

	public override ISite get_Site() { }

	protected override object GetService(Type service) { }

	public virtual string ToString() { }

}

