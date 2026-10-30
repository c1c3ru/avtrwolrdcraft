//Type is in global namespace

public class UISpotlight : MonoBehaviour
{
	[SerializeField]
	private Material _material; //Field offset: 0x20
	[SerializeField]
	private RectTransform _rectTransfrom; //Field offset: 0x28
	private Vector2 _worldRectSize; //Field offset: 0x30
	private bool _didInit; //Field offset: 0x38
	private RenderMode _renderMode; //Field offset: 0x3C
	private Vector2 _uvFactors; //Field offset: 0x40
	private Transform _canvasTransform; //Field offset: 0x48

	public UISpotlight() { }

	public float GetRadius() { }

	public void Init() { }

	private float Remap01(float a, float b, float v) { }

	public void SetPosition(Vector2 position) { }

	public void SetRadius(float radius) { }

	public void SetSize() { }

	public void SetSoftness(float softness) { }

}

