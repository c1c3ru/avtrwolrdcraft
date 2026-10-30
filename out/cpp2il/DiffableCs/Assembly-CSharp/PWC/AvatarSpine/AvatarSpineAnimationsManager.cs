namespace PWC.AvatarSpine;

public static class AvatarSpineAnimationsManager
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass2_0
	{
		public Animation animation; //Field offset: 0x10
		public SkeletonAnimation skeletonAnimation; //Field offset: 0x18
		public TrackEntry trackEntry; //Field offset: 0x20
		public SpineType spineType; //Field offset: 0x28

		public <>c__DisplayClass2_0() { }

		internal void <AddAnimation>b__0(TrackEntry start) { }

	}


	public static TrackEntry AddAnimation(SkeletonAnimation skeletonAnimation, int trackIndex, string animationName, bool loop, float delay, SpineType spineType) { }

	private static Material CreateCustomMaterial(SkeletonAnimation skeletonAnimation, Material originalMaterial) { }

	private static List<Material> CreateCustomMaterialsIfNeeded(Animation animation, SkeletonAnimation skeletonAnimation, SpineType spineType) { }

	private static void OnAnimationStartActions(Animation animation, SkeletonAnimation skeletonAnimation, TrackEntry trackEntry, SpineType spineType) { }

	public static TrackEntry SetAnimation(SkeletonAnimation skeletonAnimation, int trackIndex, string animationName, bool loop, SpineType spineType) { }

	public static TrackEntry SetAnimation(SkeletonAnimation skeletonAnimation, int trackIndex, Animation animation, bool loop, SpineType spineType) { }

}

