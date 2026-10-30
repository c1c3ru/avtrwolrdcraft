namespace TMPro;

public class Compute_DT_EventArgs
{
	public Compute_DistanceTransform_EventTypes EventType; //Field offset: 0x10
	public float ProgressPercentage; //Field offset: 0x14
	public Color[] Colors; //Field offset: 0x18

	public Compute_DT_EventArgs(Compute_DistanceTransform_EventTypes type, float progress) { }

	public Compute_DT_EventArgs(Compute_DistanceTransform_EventTypes type, Color[] colors) { }

}

