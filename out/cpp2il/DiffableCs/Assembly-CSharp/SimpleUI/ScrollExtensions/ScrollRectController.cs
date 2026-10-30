namespace SimpleUI.ScrollExtensions;

[AddComponentMenu("Simple UI/ Scroll View Extensions/ Scroll Rect Controller", 1000)]
public class ScrollRectController : MonoBehaviour
{
	private bool initialized; //Field offset: 0x20
	private RectTransform m_ContentRect; //Field offset: 0x28
	private RectTransform m_ViewRect; //Field offset: 0x30
	private Vector3[] ViewRectWorldCoordinates; //Field offset: 0x38
	private Vector3[] ContentRectWorldCoordinates; //Field offset: 0x40
	private Vector3 centerPosition; //Field offset: 0x48
	private Vector3 difference; //Field offset: 0x54
	public ScrollRect scrollRect; //Field offset: 0x60
	private Vector2 viewRectWorldSize; //Field offset: 0x68
	private Vector2 contentRectWorldSize; //Field offset: 0x70
	private Vector2 normalizedDifference; //Field offset: 0x78

	public ScrollRectController() { }

	public override void Awake() { }

	public void CenterOn(RectTransform centerTransform) { }

	public Vector2 GetCenteredNormalizedPosition(RectTransform TransformToCenterOn) { }

	public void Initialize() { }

}

