namespace PWC.LightSystem;

public class LitSpine : LitBase, ILevelMakerUIMenuItem
{
	protected SkeletonAnimation _skeletonAnimation; //Field offset: 0x58
	private MeshRenderer _meshRenderer; //Field offset: 0x60
	private MeshRenderer[] _separatedMeshRenderers; //Field offset: 0x68
	private bool _didCheckForMaterialOverrides; //Field offset: 0x70
	protected readonly int _LightColorID; //Field offset: 0x74

	public LitSpine() { }

	[CompilerGenerated]
	private void <EnsureMateirals>g__SetMaterialOverride|7_0(MeshRenderer meshRenderer) { }

	public virtual void ApplyIntensity() { }

	protected virtual void Awake() { }

	public void EnsureMateirals() { }

	public void EnsureMaterialsOverrideForSeparator() { }

	public virtual Vector2 GetPointForDistanceCheck() { }

	private void InitMaterial(Material material) { }

	protected virtual bool IsInsideLightArea(LightArea lightArea) { }

	public virtual bool IsVisible() { }

	private override void PWC.Level.Maker.ILevelMakerUIMenuItem.OnCreatedInsideUIItem() { }

	public void SetEnabled(bool isEnabled) { }

}

