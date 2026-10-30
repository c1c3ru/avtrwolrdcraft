namespace PWC.Level;

public class GreenScreenTextureLabelUnityEvent
{
	public string Label; //Field offset: 0x10
	[Space]
	public UnityEvent OnRecievedLabel; //Field offset: 0x18
	[Space]
	public UnityEvent OnRecievedOtherLabel; //Field offset: 0x20

	public GreenScreenTextureLabelUnityEvent() { }

	public void Invoke(string label) { }

}

