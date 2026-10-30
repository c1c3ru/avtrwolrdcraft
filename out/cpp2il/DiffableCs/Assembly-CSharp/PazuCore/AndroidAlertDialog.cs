namespace PazuCore;

public class AndroidAlertDialog : MonoBehaviour
{
	private class PositiveButtonListner : AndroidJavaProxy
	{

		public PositiveButtonListner(AndroidAlertDialog d) { }

		public void onClick(AndroidJavaObject obj, int value) { }

	}

	private AndroidJavaObject dialog; //Field offset: 0x20

	public AndroidAlertDialog() { }

	private void OnApplicationPause(bool pause) { }

	public void ShowDialog() { }

	private void Start() { }

}

