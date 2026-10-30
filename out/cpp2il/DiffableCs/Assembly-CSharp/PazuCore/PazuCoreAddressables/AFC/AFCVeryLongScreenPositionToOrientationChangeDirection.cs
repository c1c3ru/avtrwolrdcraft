namespace PazuCore.PazuCoreAddressables.AFC;

[RequireComponent(typeof(RectTransform))]
public class AFCVeryLongScreenPositionToOrientationChangeDirection : MonoBehaviour
{
	[SerializeField]
	private Vector2 _normal; //Field offset: 0x20
	[SerializeField]
	private Vector2 _reverse; //Field offset: 0x28
	private RectTransform _rectTransform; //Field offset: 0x30
	private bool _isVeryLong; //Field offset: 0x38

	public AFCVeryLongScreenPositionToOrientationChangeDirection() { }

	private void Awake() { }

	public Vector2 GetDifferenceBetweenNormalAndReverse() { }

	private void OnDestroy() { }

	private void OnOrientationChange(DeviceOrientation deviceOrientation) { }

}

