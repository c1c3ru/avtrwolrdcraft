namespace UnityEngine.EventSystems;

public class BaseInput : UIBehaviour
{

	public override Vector2 compositionCursorPos
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public override string compositionString
	{
		 get { } //Length: 8
	}

	public override IMECompositionMode imeCompositionMode
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public override Vector2 mousePosition
	{
		 get { } //Length: 8
	}

	public override bool mousePresent
	{
		 get { } //Length: 8
	}

	public override Vector2 mouseScrollDelta
	{
		 get { } //Length: 8
	}

	public override int touchCount
	{
		 get { } //Length: 8
	}

	public override bool touchSupported
	{
		 get { } //Length: 8
	}

	public BaseInput() { }

	public override Vector2 get_compositionCursorPos() { }

	public override string get_compositionString() { }

	public override IMECompositionMode get_imeCompositionMode() { }

	public override Vector2 get_mousePosition() { }

	public override bool get_mousePresent() { }

	public override Vector2 get_mouseScrollDelta() { }

	public override int get_touchCount() { }

	public override bool get_touchSupported() { }

	public override float GetAxisRaw(string axisName) { }

	public override bool GetButtonDown(string buttonName) { }

	public override bool GetMouseButton(int button) { }

	public override bool GetMouseButtonDown(int button) { }

	public override bool GetMouseButtonUp(int button) { }

	public override Touch GetTouch(int index) { }

	public override void set_compositionCursorPos(Vector2 value) { }

	public override void set_imeCompositionMode(IMECompositionMode value) { }

}

