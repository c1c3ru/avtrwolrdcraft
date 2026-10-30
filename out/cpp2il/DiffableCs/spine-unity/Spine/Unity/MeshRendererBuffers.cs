namespace Spine.Unity;

public class MeshRendererBuffers : IDisposable
{
	internal class SmartMesh : IDisposable
	{
		public Mesh mesh; //Field offset: 0x10
		public SkeletonRendererInstruction instructionUsed; //Field offset: 0x18

		public SmartMesh() { }

		public void Clear() { }

		public override void Dispose() { }

	}

	private DoubleBuffered<SmartMesh> doubleBufferedMesh; //Field offset: 0x10
	internal readonly ExposedList<Material> submeshMaterials; //Field offset: 0x18
	internal Material[] sharedMaterials; //Field offset: 0x20

	public MeshRendererBuffers() { }

	public void Clear() { }

	public override void Dispose() { }

	public SmartMesh GetNextMesh() { }

	public Material[] GetUpdatedSharedMaterialsArray() { }

	public void Initialize() { }

	public bool MaterialsChangedInLastUpdate() { }

	public void UpdateSharedMaterials(ExposedList<SubmeshInstruction> instructions) { }

}

