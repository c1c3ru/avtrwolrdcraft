namespace PWC.AvatarMaker;

public class AvatarMakerCharacterThumbsConfig : AvatarMakerThumbsConfigBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass2_0
	{
		public ScrollRect scrollRect; //Field offset: 0x10

		public <>c__DisplayClass2_0() { }

		internal void <TryAlternateHandleScrollerPosition>b__0(float verticalNormalizedPosition) { }

	}


	public AvatarMakerCharacterThumbsConfig() { }

	public virtual void GetGridParams(int categoryType, out int padding, out float spacing, out int constraintCount, out ThumbType thumbType) { }

	public virtual void HandlePremadeThumbs(bool includePremades, int categoryType, ref List<Sprite>& itemSprites) { }

	public virtual void SetNewThumbs(List<AvatarMakerThumb> thumbs) { }

	public virtual bool TryAlternateHandleScrollerPosition(int categoryType, ScrollRect scrollRect) { }

}

