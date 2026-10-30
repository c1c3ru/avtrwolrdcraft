namespace PWC;

public static class PWCSpineUtils
{

	public static Animation CreateAnimationWithOnlyWithBoneIndexes(Animation animation, HashSet<Int32> bonesIndexesToUse) { }

	public static BoneFollower FollowBone(Transform target, Transform followerParent, SkeletonAnimation skeletonAnimation, string boneName, bool followRotation = false, bool followScale = false) { }

	public static void GetAllBonesHieararchyUnderBone(Bone bone, List<Bone> result) { }

	public static HashSet<Int32> GetIndexesOfHierarchyChildrenBones(SkeletonAnimation skeletonAnimation, Bone bone) { }

	private static Rect GetRect(AtlasRegion atlasRegion) { }

	public static Sprite GetSprite(Atlas atlas, string name) { }

	private static Material GetUsedMaterial(AtlasRegion atlasRegion) { }

	public static Texture2D GetUsedTexture(AtlasRegion atlasRegion) { }

	public static bool TryGetSprite(Atlas atlas, string name, out Sprite sprite) { }

}

