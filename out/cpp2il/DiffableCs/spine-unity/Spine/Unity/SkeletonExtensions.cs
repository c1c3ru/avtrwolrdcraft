namespace Spine.Unity;

[Extension]
public static class SkeletonExtensions
{
	private const float ByteToFloat = 0,003921569; //Field offset: 0x0

	[Extension]
	public static Color GetColor(Skeleton s) { }

	[Extension]
	public static Color GetColor(RegionAttachment a) { }

	[Extension]
	public static Color GetColor(MeshAttachment a) { }

	[Extension]
	public static Color GetColor(Slot s) { }

	[Extension]
	public static Color GetColorTintBlack(Slot s) { }

	[Extension]
	public static Vector2 GetLocalPosition(Bone bone) { }

	[Extension]
	public static Quaternion GetLocalQuaternion(Bone bone) { }

	[Extension]
	public static Vector2 GetLocalScale(Skeleton skeleton) { }

	[Extension]
	public static Vector2[] GetLocalVertices(VertexAttachment va, Slot slot, Vector2[] buffer) { }

	[Extension]
	public static Material GetMaterial(Attachment a) { }

	[Extension]
	public static Matrix4x4 GetMatrix4x4(Bone bone) { }

	[Extension]
	public static Quaternion GetQuaternion(Bone bone) { }

	[Extension]
	public static Vector2 GetSkeletonSpacePosition(Bone bone) { }

	[Extension]
	public static Vector2 GetSkeletonSpacePosition(Bone bone, Vector2 boneLocal) { }

	[Extension]
	public static Vector3 GetWorldPosition(Bone bone, Transform spineGameObjectTransform, float positionScale, Vector2 positionOffset) { }

	[Extension]
	public static Vector3 GetWorldPosition(Bone bone, Transform spineGameObjectTransform, float positionScale) { }

	[Extension]
	public static Vector3 GetWorldPosition(Bone bone, Transform spineGameObjectTransform) { }

	[Extension]
	public static Vector3 GetWorldPosition(PointAttachment attachment, Bone bone, Transform spineGameObjectTransform) { }

	[Extension]
	public static Vector3 GetWorldPosition(PointAttachment attachment, Slot slot, Transform spineGameObjectTransform) { }

	[Extension]
	public static void GetWorldToLocalMatrix(Bone bone, out float ia, out float ib, out float ic, out float id) { }

	[Extension]
	public static Vector2[] GetWorldVertices(VertexAttachment a, Slot slot, Vector2[] buffer) { }

	[Extension]
	public static void SetColor(MeshAttachment attachment, Color32 color) { }

	[Extension]
	public static void SetColor(MeshAttachment attachment, Color color) { }

	[Extension]
	public static void SetColor(RegionAttachment attachment, Color32 color) { }

	[Extension]
	public static void SetColor(RegionAttachment attachment, Color color) { }

	[Extension]
	public static void SetColor(Slot slot, Color32 color) { }

	[Extension]
	public static void SetColor(Slot slot, Color color) { }

	[Extension]
	public static void SetColor(Skeleton skeleton, Color32 color) { }

	[Extension]
	public static void SetColor(Skeleton skeleton, Color color) { }

	[Extension]
	public static void SetLocalPosition(Bone bone, Vector2 position) { }

	[Extension]
	public static void SetLocalPosition(Bone bone, Vector3 position) { }

	[Extension]
	public static void SetLocalScale(Skeleton skeleton, Vector2 scale) { }

	[Extension]
	public static Vector2 SetPositionSkeletonSpace(Bone bone, Vector2 skeletonSpacePosition) { }

	[Extension]
	public static Vector2 WorldToLocal(Bone bone, Vector2 worldPosition) { }

}

