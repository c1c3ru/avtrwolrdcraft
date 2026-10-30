namespace UnityEngine;

[NativeHeader("Runtime/Graphics/GraphicsScriptBindings.h")]
[NativeHeader("Runtime/Graphics/Renderer.h")]
[RequireComponent(typeof(Transform))]
[UsedByNativeCode]
public class Renderer : Component
{

	public Bounds bounds
	{
		[FreeFunction(Name = "RendererScripting::GetWorldBounds", HasExplicitThis = True)]
		 get { } //Length: 104
	}

	public bool enabled
	{
		 get { } //Length: 60
		 set { } //Length: 68
	}

	public bool isVisible
	{
		[NativeName("IsVisibleInScene")]
		 get { } //Length: 60
	}

	public LightProbeUsage lightProbeUsage
	{
		 get { } //Length: 60
		 set { } //Length: 68
	}

	public Material material
	{
		 get { } //Length: 60
		 set { } //Length: 68
	}

	public Material[] materials
	{
		 get { } //Length: 60
		 set { } //Length: 4
	}

	public MotionVectorGenerationMode motionVectorGenerationMode
	{
		 get { } //Length: 60
		 set { } //Length: 68
	}

	public Transform probeAnchor
	{
		 get { } //Length: 60
		 set { } //Length: 68
	}

	public bool receiveShadows
	{
		 get { } //Length: 60
		 set { } //Length: 68
	}

	public ReflectionProbeUsage reflectionProbeUsage
	{
		 get { } //Length: 60
		 set { } //Length: 68
	}

	public ShadowCastingMode shadowCastingMode
	{
		 get { } //Length: 60
		 set { } //Length: 68
	}

	public Material sharedMaterial
	{
		 get { } //Length: 60
		 set { } //Length: 68
	}

	public Material[] sharedMaterials
	{
		 get { } //Length: 60
		 set { } //Length: 4
	}

	internal int sortingGroupID
	{
		internal get { } //Length: 60
	}

	internal int sortingGroupOrder
	{
		internal get { } //Length: 60
	}

	public int sortingLayerID
	{
		 get { } //Length: 60
		 set { } //Length: 68
	}

	public string sortingLayerName
	{
		 set { } //Length: 68
	}

	public int sortingOrder
	{
		 get { } //Length: 60
		 set { } //Length: 68
	}

	public Renderer() { }

	[FreeFunction(Name = "RendererScripting::GetWorldBounds", HasExplicitThis = True)]
	public Bounds get_bounds() { }

	private void get_bounds_Injected(out Bounds ret) { }

	public bool get_enabled() { }

	[NativeName("IsVisibleInScene")]
	public bool get_isVisible() { }

	public LightProbeUsage get_lightProbeUsage() { }

	public Material get_material() { }

	public Material[] get_materials() { }

	public MotionVectorGenerationMode get_motionVectorGenerationMode() { }

	public Transform get_probeAnchor() { }

	public bool get_receiveShadows() { }

	public ReflectionProbeUsage get_reflectionProbeUsage() { }

	public ShadowCastingMode get_shadowCastingMode() { }

	public Material get_sharedMaterial() { }

	public Material[] get_sharedMaterials() { }

	internal int get_sortingGroupID() { }

	internal int get_sortingGroupOrder() { }

	public int get_sortingLayerID() { }

	public int get_sortingOrder() { }

	[FreeFunction(Name = "RendererScripting::GetMaterial", HasExplicitThis = True)]
	private Material GetMaterial() { }

	[FreeFunction(Name = "RendererScripting::GetMaterialArray", HasExplicitThis = True)]
	private Material[] GetMaterialArray() { }

	public void GetPropertyBlock(MaterialPropertyBlock properties) { }

	public void GetPropertyBlock(MaterialPropertyBlock properties, int materialIndex) { }

	[FreeFunction(Name = "RendererScripting::GetSharedMaterial", HasExplicitThis = True)]
	private Material GetSharedMaterial() { }

	[NativeName("GetMaterialArray")]
	private Material[] GetSharedMaterialArray() { }

	[FreeFunction(Name = "RendererScripting::HasPropertyBlock", HasExplicitThis = True)]
	public bool HasPropertyBlock() { }

	[FreeFunction(Name = "RendererScripting::GetPropertyBlock", HasExplicitThis = True)]
	internal void Internal_GetPropertyBlock(MaterialPropertyBlock dest) { }

	[FreeFunction(Name = "RendererScripting::GetPropertyBlockMaterialIndex", HasExplicitThis = True)]
	internal void Internal_GetPropertyBlockMaterialIndex(MaterialPropertyBlock dest, int materialIndex) { }

	[FreeFunction(Name = "RendererScripting::SetPropertyBlock", HasExplicitThis = True)]
	internal void Internal_SetPropertyBlock(MaterialPropertyBlock properties) { }

	[FreeFunction(Name = "RendererScripting::SetPropertyBlockMaterialIndex", HasExplicitThis = True)]
	internal void Internal_SetPropertyBlockMaterialIndex(MaterialPropertyBlock properties, int materialIndex) { }

	public void set_enabled(bool value) { }

	public void set_lightProbeUsage(LightProbeUsage value) { }

	public void set_material(Material value) { }

	public void set_materials(Material[] value) { }

	public void set_motionVectorGenerationMode(MotionVectorGenerationMode value) { }

	public void set_probeAnchor(Transform value) { }

	public void set_receiveShadows(bool value) { }

	public void set_reflectionProbeUsage(ReflectionProbeUsage value) { }

	public void set_shadowCastingMode(ShadowCastingMode value) { }

	public void set_sharedMaterial(Material value) { }

	public void set_sharedMaterials(Material[] value) { }

	public void set_sortingLayerID(int value) { }

	public void set_sortingLayerName(string value) { }

	public void set_sortingOrder(int value) { }

	[FreeFunction(Name = "RendererScripting::SetMaterial", HasExplicitThis = True)]
	private void SetMaterial(Material m) { }

	private void SetMaterialArray(Material[] m) { }

	[FreeFunction(Name = "RendererScripting::SetMaterialArray", HasExplicitThis = True)]
	private void SetMaterialArray(Material[] m, int length) { }

	public void SetPropertyBlock(MaterialPropertyBlock properties, int materialIndex) { }

	public void SetPropertyBlock(MaterialPropertyBlock properties) { }

}

