namespace PWC.UGC;

public class UGCMeshSkewGridItemHandler : MonoBehaviour, ILevelMakerUIMenuItem
{
	[SerializeField]
	private MeshSkew _meshSkew; //Field offset: 0x20
	[SerializeField]
	private SpriteRenderer[] _outlineSpriteRenderers; //Field offset: 0x28

	public UGCMeshSkewGridItemHandler() { }

	private override void PWC.Level.Maker.ILevelMakerUIMenuItem.OnCreatedInsideUIItem() { }

}

