namespace PazuCore;

public class ScrollingIcons : MonoBehaviour
{
	[SerializeField]
	private InfiniteScroll _scrollingIcons; //Field offset: 0x20
	[SerializeField]
	private ElementIcons _elementIconsUp; //Field offset: 0x28
	[SerializeField]
	private ElementIcons _elementIconsDown; //Field offset: 0x30
	[CompilerGenerated]
	private float <Scale>k__BackingField; //Field offset: 0x38

	public float Scale
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public ScrollingIcons() { }

	[CompilerGenerated]
	public float get_Scale() { }

	[CompilerGenerated]
	public void set_Scale(float value) { }

	private void Start() { }

	private void Update() { }

}

