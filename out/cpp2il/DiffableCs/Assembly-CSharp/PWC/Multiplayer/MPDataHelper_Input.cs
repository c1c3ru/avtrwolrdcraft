namespace PWC.Multiplayer;

public static class MPDataHelper_Input
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0

		private static <>c() { }

		public <>c() { }

		internal void <.cctor>b__10_0(PointerEventData eventData, IPointerDownHandler target) { }

		internal void <.cctor>b__10_1(PointerEventData eventData, IPointerUpHandler target) { }

		internal void <.cctor>b__10_2(PointerEventData eventData, IPointerClickHandler target) { }

		internal void <.cctor>b__10_3(PointerEventData eventData, IBeginDragHandler target) { }

		internal void <.cctor>b__10_4(PointerEventData eventData, IDragHandler target) { }

		internal void <.cctor>b__10_5(PointerEventData eventData, IEndDragHandler target) { }

	}

	private static readonly Action<PointerEventData, IPointerDownHandler> _onPointerDownAction; //Field offset: 0x0
	private static readonly Action<PointerEventData, IPointerUpHandler> _onPointerUpAction; //Field offset: 0x8
	private static readonly Action<PointerEventData, IPointerClickHandler> _onPointerClickAction; //Field offset: 0x10
	private static readonly Action<PointerEventData, IBeginDragHandler> _onBeginDragAction; //Field offset: 0x18
	private static readonly Action<PointerEventData, IDragHandler> _onDragAction; //Field offset: 0x20
	private static readonly Action<PointerEventData, IEndDragHandler> _onEndDragAction; //Field offset: 0x28

	private static MPDataHelper_Input() { }

	private static PointerEventData CreatePointerEventData(GameObject targetGameObject, MPData_Input data) { }

	private static void Execute(GameObject targetGameObject, PointerEventData eventData, Action<PointerEventData, T> aciton) { }

	public static void HandleData(MPData_Input inputData) { }

	public static void TrySendEvent(GameObject gameObject, MPInputEventType eventType, PointerEventData eventData, MPOneCallGeneratorData oneCallData) { }

}

