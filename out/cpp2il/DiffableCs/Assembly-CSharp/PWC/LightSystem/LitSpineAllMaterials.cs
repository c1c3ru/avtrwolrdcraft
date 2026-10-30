namespace PWC.LightSystem;

public class LitSpineAllMaterials : LitBase
{
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x58
	private MeshRenderer _meshRenderer; //Field offset: 0x60
	private MeshRenderer[] _separatedMeshRenderers; //Field offset: 0x68
	private bool _didCheckForMaterialOverrides; //Field offset: 0x70
	private readonly int _LightColorID; //Field offset: 0x74

	public LitSpineAllMaterials() { }

	public virtual void ApplyIntensity() { }

	protected virtual void Awake() { }

	public void EnsureMateirals() { }

	public virtual Vector2 GetPointForDistanceCheck() { }

	private void InitMaterial(Material material) { }

	protected virtual bool IsInsideLightArea(LightArea lightArea) { }

	public virtual bool IsVisible() { }

	public void SetEnabled(bool isEnabled) { }

}

