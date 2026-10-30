namespace Spine.Unity;

[HelpURL("http://esotericsoftware.com/spine-unity#SkeletonRenderSeparator")]
[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
public class SkeletonPartsRenderer : MonoBehaviour
{
	internal sealed class SkeletonPartsRendererDelegate : MulticastDelegate
	{

		public SkeletonPartsRendererDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(SkeletonPartsRenderer skeletonPartsRenderer, AsyncCallback callback, object object) { }

		public override void EndInvoke(IAsyncResult result) { }

		public override void Invoke(SkeletonPartsRenderer skeletonPartsRenderer) { }

	}

	private MeshGenerator meshGenerator; //Field offset: 0x20
	private MeshRenderer meshRenderer; //Field offset: 0x28
	private MeshFilter meshFilter; //Field offset: 0x30
	[CompilerGenerated]
	private SkeletonPartsRendererDelegate OnMeshAndMaterialsUpdated; //Field offset: 0x38
	private MeshRendererBuffers buffers; //Field offset: 0x40
	private SkeletonRendererInstruction currentInstructions; //Field offset: 0x48

	public event SkeletonPartsRendererDelegate OnMeshAndMaterialsUpdated
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public MeshFilter MeshFilter
	{
		 get { } //Length: 24
	}

	public MeshGenerator MeshGenerator
	{
		 get { } //Length: 24
	}

	public MeshRenderer MeshRenderer
	{
		 get { } //Length: 24
	}

	public SkeletonPartsRenderer() { }

	[CompilerGenerated]
	public void add_OnMeshAndMaterialsUpdated(SkeletonPartsRendererDelegate value) { }

	public void ClearMesh() { }

	public MeshFilter get_MeshFilter() { }

	public MeshGenerator get_MeshGenerator() { }

	public MeshRenderer get_MeshRenderer() { }

	private void LazyIntialize() { }

	public static SkeletonPartsRenderer NewPartsRendererGameObject(Transform parent, string name, int sortingOrder = 0) { }

	private void OnDestroy() { }

	[CompilerGenerated]
	public void remove_OnMeshAndMaterialsUpdated(SkeletonPartsRendererDelegate value) { }

	public void RenderParts(ExposedList<SubmeshInstruction> instructions, int startSubmesh, int endSubmesh) { }

	public void SetPropertyBlock(MaterialPropertyBlock block) { }

}

