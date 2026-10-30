namespace PazuCore.AF.Library;

public class LibraryHeaderOrFooterImage : MonoBehaviour
{
	[SerializeField]
	private RawImage _leftImage; //Field offset: 0x20
	[SerializeField]
	private RawImage _centerImage; //Field offset: 0x28
	[SerializeField]
	private RawImage _rightImage; //Field offset: 0x30

	public RawImage CenterImage
	{
		 get { } //Length: 8
	}

	public RawImage LeftImage
	{
		 get { } //Length: 8
	}

	public RawImage RightImage
	{
		 get { } //Length: 8
	}

	public LibraryHeaderOrFooterImage() { }

	public RawImage get_CenterImage() { }

	public RawImage get_LeftImage() { }

	public RawImage get_RightImage() { }

	public void SetCenterImage(RectTransform imageParent, bool isTiled, float extraHeaderOrFooterRightPadding) { }

	public void SetLeftImage() { }

	public void SetRightImage(float extraHeaderOrFooterRightPadding) { }

}

