namespace TMPro;

public class TMP_UpdateManager
{
	private static TMP_UpdateManager s_Instance; //Field offset: 0x0
	private static ProfilerMarker k_RegisterTextObjectForUpdateMarker; //Field offset: 0x8
	private static ProfilerMarker k_RegisterTextElementForGraphicRebuildMarker; //Field offset: 0x10
	private static ProfilerMarker k_RegisterTextElementForCullingUpdateMarker; //Field offset: 0x18
	private static ProfilerMarker k_UnregisterTextObjectForUpdateMarker; //Field offset: 0x20
	private static ProfilerMarker k_UnregisterTextElementForGraphicRebuildMarker; //Field offset: 0x28
	private readonly HashSet<Int32> m_LayoutQueueLookup; //Field offset: 0x10
	private readonly List<TMP_Text> m_LayoutRebuildQueue; //Field offset: 0x18
	private readonly HashSet<Int32> m_GraphicQueueLookup; //Field offset: 0x20
	private readonly List<TMP_Text> m_GraphicRebuildQueue; //Field offset: 0x28
	private readonly HashSet<Int32> m_InternalUpdateLookup; //Field offset: 0x30
	private readonly List<TMP_Text> m_InternalUpdateQueue; //Field offset: 0x38
	private readonly HashSet<Int32> m_CullingUpdateLookup; //Field offset: 0x40
	private readonly List<TMP_Text> m_CullingUpdateQueue; //Field offset: 0x48

	private static TMP_UpdateManager instance
	{
		private get { } //Length: 176
	}

	private static TMP_UpdateManager() { }

	private TMP_UpdateManager() { }

	private void DoRebuilds() { }

	private static TMP_UpdateManager get_instance() { }

	private void InternalRegisterTextElementForCullingUpdate(TMP_Text element) { }

	private void InternalRegisterTextElementForGraphicRebuild(TMP_Text element) { }

	private void InternalRegisterTextElementForLayoutRebuild(TMP_Text element) { }

	private void InternalRegisterTextObjectForUpdate(TMP_Text textObject) { }

	private void InternalUnRegisterTextElementForGraphicRebuild(TMP_Text element) { }

	private void InternalUnRegisterTextElementForLayoutRebuild(TMP_Text element) { }

	private void InternalUnRegisterTextObjectForUpdate(TMP_Text textObject) { }

	private void OnCameraPreCull() { }

	public static void RegisterTextElementForCullingUpdate(TMP_Text element) { }

	public static void RegisterTextElementForGraphicRebuild(TMP_Text element) { }

	public static void RegisterTextElementForLayoutRebuild(TMP_Text element) { }

	internal static void RegisterTextObjectForUpdate(TMP_Text textObject) { }

	public static void UnRegisterTextElementForRebuild(TMP_Text element) { }

	internal static void UnRegisterTextObjectForUpdate(TMP_Text textObject) { }

}

