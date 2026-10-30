namespace TMPro;

public class TMP_UpdateRegistry
{
	private static TMP_UpdateRegistry s_Instance; //Field offset: 0x0
	private readonly List<ICanvasElement> m_LayoutRebuildQueue; //Field offset: 0x10
	private HashSet<Int32> m_LayoutQueueLookup; //Field offset: 0x18
	private readonly List<ICanvasElement> m_GraphicRebuildQueue; //Field offset: 0x20
	private HashSet<Int32> m_GraphicQueueLookup; //Field offset: 0x28

	public static TMP_UpdateRegistry instance
	{
		 get { } //Length: 132
	}

	protected TMP_UpdateRegistry() { }

	public static TMP_UpdateRegistry get_instance() { }

	private bool InternalRegisterCanvasElementForGraphicRebuild(ICanvasElement element) { }

	private bool InternalRegisterCanvasElementForLayoutRebuild(ICanvasElement element) { }

	private void InternalUnRegisterCanvasElementForGraphicRebuild(ICanvasElement element) { }

	private void InternalUnRegisterCanvasElementForLayoutRebuild(ICanvasElement element) { }

	private void PerformUpdateForCanvasRendererObjects() { }

	private void PerformUpdateForMeshRendererObjects() { }

	public static void RegisterCanvasElementForGraphicRebuild(ICanvasElement element) { }

	public static void RegisterCanvasElementForLayoutRebuild(ICanvasElement element) { }

	public static void UnRegisterCanvasElementForRebuild(ICanvasElement element) { }

}

