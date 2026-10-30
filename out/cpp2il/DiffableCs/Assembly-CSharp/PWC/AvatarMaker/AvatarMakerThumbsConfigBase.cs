namespace PWC.AvatarMaker;

public abstract class AvatarMakerThumbsConfigBase : MonoBehaviour
{

	protected AvatarMakerThumbsConfigBase() { }

	private void Awake() { }

	public override string GetBreedFromThumbName(string thumbName) { }

	public abstract void GetGridParams(int categoryType, out int padding, out float spacing, out int constraintCount, out ThumbType thumbType) { }

	public override void GetSkinNamesWithoutThumbs(int categoryType, List<String> skinNames) { }

	public abstract void HandlePremadeThumbs(bool includePremades, int categoryType, ref List<Sprite>& itemSprites) { }

	public override bool IsPackOnlyPart(string skinName) { }

	private void OnDestroy() { }

	protected override void OnThumbClick(AvatarMakerThumb thumb) { }

	public override void SetNewThumbs(List<AvatarMakerThumb> thumbs) { }

	public override bool TryAlternateHandleScrollerPosition(int categoryType, ScrollRect scrollRect) { }

	public override bool TryFilterThumb(int categoryType, Sprite sprite) { }

	public override bool TryGetChildAlignment(int categoryType, out TextAnchor childAlignment) { }

	public override bool TryGetFallbackThumb(int categoryType, string skinName, out Sprite sprite) { }

	public override bool TryGetThumbOrder(int categoryType, InventoryFlagType flagType, out List<String>& skinNames) { }

	public override bool TryGetThumbSprites(int categoryType, out Sprite thumbSprite, out Sprite frameSprite) { }

}

