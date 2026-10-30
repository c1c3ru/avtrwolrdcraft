namespace PazuCore.AF.Feed;

public class FeedItemView : ButtonBase
{
	[SerializeField]
	private Text _title; //Field offset: 0x20
	[SerializeField]
	private Text _description; //Field offset: 0x28
	[SerializeField]
	private Text _timeAgo; //Field offset: 0x30
	[SerializeField]
	private FeedTextureComponent _coverPhotoFeedTexture; //Field offset: 0x38
	[SerializeField]
	private FeedTextureComponent _roundFeedTexture; //Field offset: 0x40
	[CompilerGenerated]
	private FeedItemData <ItemModel>k__BackingField; //Field offset: 0x48
	private readonly Color _grayTimeAgoColor; //Field offset: 0x50

	public FeedTextureComponent CoverPhotoFeedTexture
	{
		 get { } //Length: 8
	}

	public private FeedItemData ItemModel
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public FeedTextureComponent RoundFeedTexture
	{
		 get { } //Length: 8
	}

	public FeedItemView() { }

	[CompilerGenerated]
	private void <OnClick>b__16_0(bool success) { }

	public void ExecuteCTA(Action<Boolean> onFinish) { }

	public FeedTextureComponent get_CoverPhotoFeedTexture() { }

	[CompilerGenerated]
	public FeedItemData get_ItemModel() { }

	public FeedTextureComponent get_RoundFeedTexture() { }

	protected virtual void OnClick() { }

	private void OnCTAExecuted() { }

	[CompilerGenerated]
	private void set_ItemModel(FeedItemData value) { }

	public void SetModel(FeedItemData itemModel) { }

}

