namespace PazuCore;

public class AndroidDialog : MonoBehaviour
{
	private class NegativeButtonListner : AndroidJavaProxy
	{
		private AndroidDialog mDialog; //Field offset: 0x20

		public NegativeButtonListner(AndroidDialog d) { }

		public void onClick(AndroidJavaObject obj, int value) { }

	}

	private class PositiveButtonListner : AndroidJavaProxy
	{

		public PositiveButtonListner(AndroidDialog d) { }

		public void onClick(AndroidJavaObject obj, int value) { }

	}

	private string mTitle; //Field offset: 0x20
	private string mMessage; //Field offset: 0x28
	private string mYes; //Field offset: 0x30
	private string mNo; //Field offset: 0x38

	public AndroidDialog() { }

	public void ShowDialog() { }

	private void Start() { }

}

