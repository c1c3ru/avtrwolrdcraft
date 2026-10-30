namespace PWC;

public class SpineDynamicSeperator : MonoBehaviour
{
	private Mesh _mesh; //Field offset: 0x20
	private MeshRenderer _meshRenderer; //Field offset: 0x28
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x30
	private readonly HashSet<Int32> _slotIndexesToKeep; //Field offset: 0x38
	private readonly MeshGenerator _meshGenerator; //Field offset: 0x40

	public SpineDynamicSeperator() { }

	public static SpineDynamicSeperator Create(SkeletonAnimation skeletonAnimation, String[] rootBonesNames) { }

	private void Init(SkeletonAnimation skeletonAnimation, String[] rootBonesNames) { }

	private void OnDestroy() { }

	private void OnMeshAndMaterialsUpdated(SkeletonRenderer skeletonRenderer) { }

}

