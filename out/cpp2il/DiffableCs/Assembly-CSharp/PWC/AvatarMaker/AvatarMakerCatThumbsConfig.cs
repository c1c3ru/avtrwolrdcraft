namespace PWC.AvatarMaker;

public class AvatarMakerCatThumbsConfig : AvatarMakerThumbsConfigBase
{

	public AvatarMakerCatThumbsConfig() { }

	public virtual void GetGridParams(int categoryType, out int padding, out float spacing, out int constraintCount, out ThumbType thumbType) { }

	public virtual void HandlePremadeThumbs(bool includePremades, int categoryType, ref List<Sprite>& itemSprites) { }

}

