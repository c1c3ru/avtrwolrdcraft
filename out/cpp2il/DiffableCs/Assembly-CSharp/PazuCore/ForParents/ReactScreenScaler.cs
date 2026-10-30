namespace PazuCore.ForParents;

[RequireComponent(typeof(CanvasScaler))]
public class ReactScreenScaler : MonoBehaviour
{
	[SerializeField]
	private float _minZoom; //Field offset: 0x20
	[SerializeField]
	private float _maxZoom; //Field offset: 0x24
	[SerializeField]
	private Vector2 _baseScreen; //Field offset: 0x28

	public ReactScreenScaler() { }

	private void Awake() { }

}

