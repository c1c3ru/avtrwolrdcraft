namespace Spine.Unity;

[ExecuteAlways]
[HelpURL("http://esotericsoftware.com/spine-unity#SkeletonRenderSeparator")]
public class SkeletonRenderSeparator : MonoBehaviour
{
	public const int DefaultSortingOrderIncrement = 5; //Field offset: 0x0
	[SerializeField]
	protected SkeletonRenderer skeletonRenderer; //Field offset: 0x20
	private MeshRenderer mainMeshRenderer; //Field offset: 0x28
	public bool copyPropertyBlock; //Field offset: 0x30
	[Tooltip("Copies MeshRenderer flags into each parts renderer")]
	public bool copyMeshRendererFlags; //Field offset: 0x31
	public List<SkeletonPartsRenderer> partsRenderers; //Field offset: 0x38
	public bool isVisible; //Field offset: 0x40
	[CompilerGenerated]
	private SkeletonRendererDelegate OnMeshAndMaterialsUpdated; //Field offset: 0x48
	private MaterialPropertyBlock copiedBlock; //Field offset: 0x50

	public event SkeletonRendererDelegate OnMeshAndMaterialsUpdated
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public SkeletonRenderer SkeletonRenderer
	{
		 get { } //Length: 8
		 set { } //Length: 300
	}

	public SkeletonRenderSeparator() { }

	[CompilerGenerated]
	public void add_OnMeshAndMaterialsUpdated(SkeletonRendererDelegate value) { }

	public SkeletonPartsRenderer AddPartsRenderer(int sortingOrderIncrement = 5, string name = null) { }

	public static SkeletonRenderSeparator AddToSkeletonRenderer(SkeletonRenderer skeletonRenderer, int sortingLayerID = 0, int extraPartsRenderers = 0, int sortingOrderIncrement = 5, int baseSortingOrder = 0, bool addMinimumPartsRenderers = true) { }

	protected void ClearPartsRendererMeshes() { }

	public SkeletonRenderer get_SkeletonRenderer() { }

	private void HandleRender(SkeletonRendererInstruction instruction) { }

	public void OnDisable() { }

	public void OnEnable() { }

	[CompilerGenerated]
	public void remove_OnMeshAndMaterialsUpdated(SkeletonRendererDelegate value) { }

	public void set_SkeletonRenderer(SkeletonRenderer value) { }

	public void Update() { }

	public void UpdateVisibility() { }

}

