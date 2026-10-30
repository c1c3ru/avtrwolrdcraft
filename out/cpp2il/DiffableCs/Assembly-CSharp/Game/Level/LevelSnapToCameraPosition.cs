namespace Game.Level;

public class LevelSnapToCameraPosition : MonoBehaviour
{
	[SerializeField]
	private Vector2 _offset; //Field offset: 0x20

	public LevelSnapToCameraPosition() { }

	public void SnapToCameraX() { }

	public void SnapToCameraY() { }

	private bool TryGetCameraPosition(out Vector3 cameraPosition) { }

}

