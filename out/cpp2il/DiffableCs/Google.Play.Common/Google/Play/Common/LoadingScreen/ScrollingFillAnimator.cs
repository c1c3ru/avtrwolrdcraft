namespace Google.Play.Common.LoadingScreen;

[ExecuteInEditMode]
[RequireComponent(typeof(RawImage))]
[RequireComponent(typeof(RectTransform))]
public class ScrollingFillAnimator : MonoBehaviour
{
	[Tooltip("How fast the fill texture will scroll in units per second.")]
	public float ScrollSpeed; //Field offset: 0x20
	private RawImage _image; //Field offset: 0x28
	private RectTransform _rectTransform; //Field offset: 0x30

	public ScrollingFillAnimator() { }

	private void LazyInit() { }

	private Rect ScaleUvs(Rect uvRect) { }

	private Rect ScrollUvs(Rect uvRect) { }

	private void Update() { }

}

