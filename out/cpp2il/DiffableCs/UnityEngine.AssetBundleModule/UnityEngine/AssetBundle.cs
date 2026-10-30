namespace UnityEngine;

[ExcludeFromPreset]
[NativeHeader("Runtime/Scripting/ScriptingUtility.h")]
[NativeHeader("Modules/AssetBundle/Public/AssetBundleSaveAndLoadHelper.h")]
[NativeHeader("Modules/AssetBundle/Public/AssetBundleUtility.h")]
[NativeHeader("Modules/AssetBundle/Public/AssetBundleLoadAssetUtility.h")]
[NativeHeader("Modules/AssetBundle/Public/AssetBundleLoadFromFileAsyncOperation.h")]
[NativeHeader("Modules/AssetBundle/Public/AssetBundleLoadFromManagedStreamAsyncOperation.h")]
[NativeHeader("Runtime/Scripting/ScriptingExportUtility.h")]
[NativeHeader("AssetBundleScriptingClasses.h")]
[NativeHeader("Runtime/Scripting/ScriptingObjectWithIntPtrField.h")]
[NativeHeader("Modules/AssetBundle/Public/AssetBundleLoadAssetOperation.h")]
[NativeHeader("Modules/AssetBundle/Public/AssetBundleLoadFromMemoryAsyncOperation.h")]
public class AssetBundle : object
{

	private AssetBundle() { }

	public static IEnumerable<AssetBundle> GetAllLoadedAssetBundles() { }

	[FreeFunction("GetAllAssetBundles")]
	internal static AssetBundle[] GetAllLoadedAssetBundles_Native() { }

	[NativeMethod("GetAllScenePaths")]
	public String[] GetAllScenePaths() { }

	public AssetBundleRequest LoadAllAssetsAsync() { }

	public AssetBundleRequest LoadAllAssetsAsync() { }

	public AssetBundleRequest LoadAllAssetsAsync(Type type) { }

	public AssetBundleRequest LoadAssetAsync(string name, Type type) { }

	[NativeMethod("LoadAssetAsync_Internal")]
	[NativeThrows]
	private AssetBundleRequest LoadAssetAsync_Internal(string name, Type type) { }

	public AssetBundleRequest LoadAssetWithSubAssetsAsync(string name, Type type) { }

	[NativeMethod("LoadAssetWithSubAssetsAsync_Internal")]
	[NativeThrows]
	private AssetBundleRequest LoadAssetWithSubAssetsAsync_Internal(string name, Type type) { }

	public static AssetBundleCreateRequest LoadFromFileAsync(string path) { }

	public static AssetBundleCreateRequest LoadFromFileAsync(string path, uint crc) { }

	[FreeFunction("LoadFromFileAsync")]
	internal static AssetBundleCreateRequest LoadFromFileAsync_Internal(string path, uint crc, ulong offset) { }

	[NativeMethod("Unload")]
	[NativeThrows]
	public void Unload(bool unloadAllLoadedObjects) { }

	[NativeMethod("UnloadAsync")]
	[NativeThrows]
	public AssetBundleUnloadOperation UnloadAsync(bool unloadAllLoadedObjects) { }

}

