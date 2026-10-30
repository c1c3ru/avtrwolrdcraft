namespace UnityEngine.UIElements;

public abstract class Manipulator : IManipulator
{
	private VisualElement m_Target; //Field offset: 0x10

	public override VisualElement target
	{
		 get { } //Length: 8
		 set { } //Length: 104
	}

	protected Manipulator() { }

	public override VisualElement get_target() { }

	protected abstract void RegisterCallbacksOnTarget() { }

	public override void set_target(VisualElement value) { }

	protected abstract void UnregisterCallbacksFromTarget() { }

}

