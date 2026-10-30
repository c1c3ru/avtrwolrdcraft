namespace Spine.Unity;

public class SkeletonRendererInstruction
{
	public readonly ExposedList<SubmeshInstruction> submeshInstructions; //Field offset: 0x10
	public bool immutableTriangles; //Field offset: 0x18
	public bool hasActiveClipping; //Field offset: 0x19
	public int rawVertexCount; //Field offset: 0x1C
	public readonly ExposedList<Attachment> attachments; //Field offset: 0x20

	public SkeletonRendererInstruction() { }

	public void Clear() { }

	public void Dispose() { }

	public static bool GeometryNotEqual(SkeletonRendererInstruction a, SkeletonRendererInstruction b) { }

	public void Set(SkeletonRendererInstruction other) { }

	public void SetWithSubset(ExposedList<SubmeshInstruction> instructions, int startSubmesh, int endSubmesh) { }

}

