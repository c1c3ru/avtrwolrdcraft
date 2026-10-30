namespace PWC.TAS;

public class TakeAvatarScreenshot : MonoBehaviour
{
	[SerializeField]
	private Camera _camera; //Field offset: 0x20

	public TakeAvatarScreenshot() { }

	public static Texture2D CreateAvatarPicture(int avatarId, float scaleFactor = 1) { }

	private Texture2D CreateScreenshot(int avatarId, float scaleFactor) { }

}

