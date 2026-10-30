namespace PWC.AvatarMaker;

public class AvatarMakerCharacterManager : AvatarMakerAvatarManagerBase
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<CharacterCategoryType> <>9__3_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <RandomizeSkins>b__3_0(CharacterCategoryType categoryType) { }

	}


	public AvatarMakerCharacterManager() { }

	[CompilerGenerated]
	private void <OnThumbClick>b__0_0(string removedSkinName) { }

	[CompilerGenerated]
	private void <RandomizeSkins>b__3_3(string removedSkinName) { }

	[CompilerGenerated]
	private void <RandomizeSkins>g__AddRandomSkin|3_1(int categoryTypeToAdd) { }

	[CompilerGenerated]
	private void <RandomizeSkins>g__ColorRandomSkin|3_2(int categoryTypeToColor) { }

	public void ChangeSizeType(AvatarSizeType sizeType, bool isInstant = false) { }

	protected virtual string GetLookAtAnimationName(int categoryType) { }

	protected virtual void OnThumbClick(AvatarMakerThumb thumb) { }

	public virtual void RandomizeSkins() { }

}

