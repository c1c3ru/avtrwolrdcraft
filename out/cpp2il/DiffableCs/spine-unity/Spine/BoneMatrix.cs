namespace Spine;

public struct BoneMatrix
{
	public float a; //Field offset: 0x0
	public float b; //Field offset: 0x4
	public float c; //Field offset: 0x8
	public float d; //Field offset: 0xC
	public float x; //Field offset: 0x10
	public float y; //Field offset: 0x14

	public BoneMatrix(BoneData boneData) { }

	public BoneMatrix(Bone bone) { }

	public static BoneMatrix CalculateSetupWorld(BoneData boneData) { }

	private static BoneMatrix GetInheritedInternal(BoneData boneData, BoneMatrix parentMatrix) { }

	public BoneMatrix TransformMatrix(BoneMatrix local) { }

}

