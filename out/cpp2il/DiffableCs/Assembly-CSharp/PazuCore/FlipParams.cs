namespace PazuCore;

public class FlipParams : MonoBehaviour
{
	internal class FlipParam
	{
		public bool dontFlip; //Field offset: 0x10
		public bool dontChangeAnchor; //Field offset: 0x11
		public bool dontChangePivot; //Field offset: 0x12
		public bool dontChangePosition; //Field offset: 0x13

		public FlipParam() { }

	}

	public FlipParam param; //Field offset: 0x20

	public FlipParams() { }

}

