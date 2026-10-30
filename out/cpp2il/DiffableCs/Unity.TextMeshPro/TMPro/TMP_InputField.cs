namespace TMPro;

[AddComponentMenu("UI/TextMeshPro - Input Field", 11)]
public class TMP_InputField : Selectable, IUpdateSelectedHandler, IEventSystemHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler, ISubmitHandler, ICanvasElement, ILayoutElement, IScrollHandler
{
	[CompilerGenerated]
	private sealed class <CaretBlink>d__276 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public TMP_InputField <>4__this; //Field offset: 0x20

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <CaretBlink>d__276(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <MouseDragOutsideRect>d__294 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public TMP_InputField <>4__this; //Field offset: 0x20
		public PointerEventData eventData; //Field offset: 0x28

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <MouseDragOutsideRect>d__294(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	internal enum CharacterValidation
	{
		None = 0,
		Digit = 1,
		Integer = 2,
		Decimal = 3,
		Alphanumeric = 4,
		Name = 5,
		Regex = 6,
		EmailAddress = 7,
		CustomValidator = 8,
	}

	internal enum ContentType
	{
		Standard = 0,
		Autocorrected = 1,
		IntegerNumber = 2,
		DecimalNumber = 3,
		Alphanumeric = 4,
		Name = 5,
		EmailAddress = 6,
		Password = 7,
		Pin = 8,
		Custom = 9,
	}

	internal enum EditState
	{
		Continue = 0,
		Finish = 1,
	}

	internal enum InputType
	{
		Standard = 0,
		AutoCorrect = 1,
		Password = 2,
	}

	internal enum LineType
	{
		SingleLine = 0,
		MultiLineSubmit = 1,
		MultiLineNewline = 2,
	}

	internal class OnChangeEvent : UnityEvent<String>
	{

		public OnChangeEvent() { }

	}

	internal sealed class OnValidateInput : MulticastDelegate
	{

		public OnValidateInput(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(string text, int charIndex, char addedChar, AsyncCallback callback, object object) { }

		public override char EndInvoke(IAsyncResult result) { }

		public override char Invoke(string text, int charIndex, char addedChar) { }

	}

	internal class SelectionEvent : UnityEvent<String>
	{

		public SelectionEvent() { }

	}

	internal class SubmitEvent : UnityEvent<String>
	{

		public SubmitEvent() { }

	}

	internal class TextSelectionEvent : UnityEvent<String, Int32, Int32>
	{

		public TextSelectionEvent() { }

	}

	internal class TouchScreenKeyboardEvent : UnityEvent<Status>
	{

		public TouchScreenKeyboardEvent() { }

	}

	private const float kHScrollSpeed = 0,05; //Field offset: 0x0
	private static readonly Char[] kSeparators; //Field offset: 0x0
	private const string kEmailSpecialCharacters = "!#$%&'*+-/=?^_`{|}~"; //Field offset: 0x0
	private const float kVScrollSpeed = 0,1; //Field offset: 0x0
	protected TouchScreenKeyboard m_SoftKeyboard; //Field offset: 0x100
	protected RectTransform m_RectTransform; //Field offset: 0x108
	[SerializeField]
	protected RectTransform m_TextViewport; //Field offset: 0x110
	protected RectMask2D m_TextComponentRectMask; //Field offset: 0x118
	protected RectMask2D m_TextViewportRectMask; //Field offset: 0x120
	private Rect m_CachedViewportRect; //Field offset: 0x128
	[SerializeField]
	protected TMP_Text m_TextComponent; //Field offset: 0x138
	protected RectTransform m_TextComponentRectTransform; //Field offset: 0x140
	[SerializeField]
	protected Graphic m_Placeholder; //Field offset: 0x148
	[SerializeField]
	protected Scrollbar m_VerticalScrollbar; //Field offset: 0x150
	[SerializeField]
	protected TMP_ScrollbarEventHandler m_VerticalScrollbarEventHandler; //Field offset: 0x158
	private bool m_IsDrivenByLayoutComponents; //Field offset: 0x160
	[SerializeField]
	private LayoutGroup m_LayoutGroup; //Field offset: 0x168
	private IScrollHandler m_IScrollHandlerParent; //Field offset: 0x170
	private float m_ScrollPosition; //Field offset: 0x178
	[SerializeField]
	protected float m_ScrollSensitivity; //Field offset: 0x17C
	[SerializeField]
	private ContentType m_ContentType; //Field offset: 0x180
	[SerializeField]
	private InputType m_InputType; //Field offset: 0x184
	[SerializeField]
	private char m_AsteriskChar; //Field offset: 0x188
	[SerializeField]
	private TouchScreenKeyboardType m_KeyboardType; //Field offset: 0x18C
	[SerializeField]
	private LineType m_LineType; //Field offset: 0x190
	[SerializeField]
	private bool m_HideMobileInput; //Field offset: 0x194
	[SerializeField]
	private bool m_HideSoftKeyboard; //Field offset: 0x195
	[SerializeField]
	private CharacterValidation m_CharacterValidation; //Field offset: 0x198
	[SerializeField]
	private string m_RegexValue; //Field offset: 0x1A0
	[SerializeField]
	private float m_GlobalPointSize; //Field offset: 0x1A8
	[SerializeField]
	private int m_CharacterLimit; //Field offset: 0x1AC
	[SerializeField]
	private SubmitEvent m_OnEndEdit; //Field offset: 0x1B0
	[SerializeField]
	private SubmitEvent m_OnSubmit; //Field offset: 0x1B8
	[SerializeField]
	private SelectionEvent m_OnSelect; //Field offset: 0x1C0
	[SerializeField]
	private SelectionEvent m_OnDeselect; //Field offset: 0x1C8
	[SerializeField]
	private TextSelectionEvent m_OnTextSelection; //Field offset: 0x1D0
	[SerializeField]
	private TextSelectionEvent m_OnEndTextSelection; //Field offset: 0x1D8
	[SerializeField]
	private OnChangeEvent m_OnValueChanged; //Field offset: 0x1E0
	[SerializeField]
	private TouchScreenKeyboardEvent m_OnTouchScreenKeyboardStatusChanged; //Field offset: 0x1E8
	[SerializeField]
	private OnValidateInput m_OnValidateInput; //Field offset: 0x1F0
	[SerializeField]
	private Color m_CaretColor; //Field offset: 0x1F8
	[SerializeField]
	private bool m_CustomCaretColor; //Field offset: 0x208
	[SerializeField]
	private Color m_SelectionColor; //Field offset: 0x20C
	[SerializeField]
	[TextArea(5, 10)]
	protected string m_Text; //Field offset: 0x220
	[Range(0, 4)]
	[SerializeField]
	private float m_CaretBlinkRate; //Field offset: 0x228
	[Range(1, 5)]
	[SerializeField]
	private int m_CaretWidth; //Field offset: 0x22C
	[SerializeField]
	private bool m_ReadOnly; //Field offset: 0x230
	[SerializeField]
	private bool m_RichText; //Field offset: 0x231
	protected int m_StringPosition; //Field offset: 0x234
	protected int m_StringSelectPosition; //Field offset: 0x238
	protected int m_CaretPosition; //Field offset: 0x23C
	protected int m_CaretSelectPosition; //Field offset: 0x240
	private RectTransform caretRectTrans; //Field offset: 0x248
	protected UIVertex[] m_CursorVerts; //Field offset: 0x250
	private CanvasRenderer m_CachedInputRenderer; //Field offset: 0x258
	private Vector2 m_LastPosition; //Field offset: 0x260
	protected Mesh m_Mesh; //Field offset: 0x268
	private bool m_AllowInput; //Field offset: 0x270
	private bool m_ShouldActivateNextUpdate; //Field offset: 0x271
	private bool m_UpdateDrag; //Field offset: 0x272
	private bool m_DragPositionOutOfBounds; //Field offset: 0x273
	protected bool m_CaretVisible; //Field offset: 0x274
	private Coroutine m_BlinkCoroutine; //Field offset: 0x278
	private float m_BlinkStartTime; //Field offset: 0x280
	private Coroutine m_DragCoroutine; //Field offset: 0x288
	private string m_OriginalText; //Field offset: 0x290
	private bool m_WasCanceled; //Field offset: 0x298
	private bool m_HasDoneFocusTransition; //Field offset: 0x299
	private WaitForSecondsRealtime m_WaitForSecondsRealtime; //Field offset: 0x2A0
	private bool m_PreventCallback; //Field offset: 0x2A8
	private bool m_TouchKeyboardAllowsInPlaceEditing; //Field offset: 0x2A9
	private bool m_IsTextComponentUpdateRequired; //Field offset: 0x2AA
	private bool m_isLastKeyBackspace; //Field offset: 0x2AB
	private float m_PointerDownClickStartTime; //Field offset: 0x2AC
	private float m_KeyDownStartTime; //Field offset: 0x2B0
	private float m_DoubleClickDelay; //Field offset: 0x2B4
	private bool m_IsCompositionActive; //Field offset: 0x2B8
	private bool m_ShouldUpdateIMEWindowPosition; //Field offset: 0x2B9
	private int m_PreviousIMEInsertionLine; //Field offset: 0x2BC
	[SerializeField]
	protected TMP_FontAsset m_GlobalFontAsset; //Field offset: 0x2C0
	[SerializeField]
	protected bool m_OnFocusSelectAll; //Field offset: 0x2C8
	protected bool m_isSelectAll; //Field offset: 0x2C9
	[SerializeField]
	protected bool m_ResetOnDeActivation; //Field offset: 0x2CA
	private bool m_SelectionStillActive; //Field offset: 0x2CB
	private bool m_ReleaseSelection; //Field offset: 0x2CC
	private GameObject m_PreviouslySelectedObject; //Field offset: 0x2D0
	[SerializeField]
	private bool m_RestoreOriginalTextOnEscape; //Field offset: 0x2D8
	[SerializeField]
	protected bool m_isRichTextEditingAllowed; //Field offset: 0x2D9
	[SerializeField]
	protected int m_LineLimit; //Field offset: 0x2DC
	[SerializeField]
	protected TMP_InputValidator m_InputValidator; //Field offset: 0x2E0
	private bool m_isSelected; //Field offset: 0x2E8
	private bool m_IsStringPositionDirty; //Field offset: 0x2E9
	private bool m_IsCaretPositionDirty; //Field offset: 0x2EA
	private bool m_forceRectTransformAdjustment; //Field offset: 0x2EB
	private Event m_ProcessingEvent; //Field offset: 0x2F0

	public char asteriskChar
	{
		 get { } //Length: 8
		 set { } //Length: 116
	}

	public float caretBlinkRate
	{
		 get { } //Length: 8
		 set { } //Length: 124
	}

	public Color caretColor
	{
		 get { } //Length: 68
		 set { } //Length: 44
	}

	public int caretPosition
	{
		 get { } //Length: 24
		 set { } //Length: 52
	}

	protected int caretPositionInternal
	{
		 get { } //Length: 24
		 set { } //Length: 16
	}

	protected int caretSelectPositionInternal
	{
		 get { } //Length: 24
		 set { } //Length: 16
	}

	public int caretWidth
	{
		 get { } //Length: 8
		 set { } //Length: 116
	}

	public int characterLimit
	{
		 get { } //Length: 8
		 set { } //Length: 192
	}

	public CharacterValidation characterValidation
	{
		 get { } //Length: 8
		 set { } //Length: 132
	}

	private static string clipboard
	{
		private get { } //Length: 80
		private set { } //Length: 88
	}

	private int compositionLength
	{
		private get { } //Length: 44
	}

	private string compositionString
	{
		private get { } //Length: 148
	}

	public ContentType contentType
	{
		 get { } //Length: 8
		 set { } //Length: 116
	}

	public bool customCaretColor
	{
		 get { } //Length: 8
		 set { } //Length: 28
	}

	public override float flexibleHeight
	{
		 get { } //Length: 8
	}

	public override float flexibleWidth
	{
		 get { } //Length: 8
	}

	public TMP_FontAsset fontAsset
	{
		 get { } //Length: 8
		 set { } //Length: 128
	}

	private bool hasSelection
	{
		private get { } //Length: 60
	}

	private BaseInput inputSystem
	{
		private get { } //Length: 272
	}

	public InputType inputType
	{
		 get { } //Length: 8
		 set { } //Length: 132
	}

	public TMP_InputValidator inputValidator
	{
		 get { } //Length: 8
		 set { } //Length: 132
	}

	public bool isFocused
	{
		 get { } //Length: 8
	}

	public bool isRichTextEditingAllowed
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public TouchScreenKeyboardType keyboardType
	{
		 get { } //Length: 8
		 set { } //Length: 132
	}

	public override int layoutPriority
	{
		 get { } //Length: 8
	}

	public int lineLimit
	{
		 get { } //Length: 8
		 set { } //Length: 108
	}

	public LineType lineType
	{
		 get { } //Length: 8
		 set { } //Length: 192
	}

	protected Mesh mesh
	{
		 get { } //Length: 168
	}

	public override float minHeight
	{
		 get { } //Length: 8
	}

	public override float minWidth
	{
		 get { } //Length: 8
	}

	public bool multiLine
	{
		 get { } //Length: 20
	}

	public SelectionEvent onDeselect
	{
		 get { } //Length: 8
		 set { } //Length: 88
	}

	public SubmitEvent onEndEdit
	{
		 get { } //Length: 8
		 set { } //Length: 88
	}

	public TextSelectionEvent onEndTextSelection
	{
		 get { } //Length: 8
		 set { } //Length: 88
	}

	public bool onFocusSelectAll
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public SelectionEvent onSelect
	{
		 get { } //Length: 8
		 set { } //Length: 88
	}

	public SubmitEvent onSubmit
	{
		 get { } //Length: 8
		 set { } //Length: 88
	}

	public TextSelectionEvent onTextSelection
	{
		 get { } //Length: 8
		 set { } //Length: 88
	}

	public TouchScreenKeyboardEvent onTouchScreenKeyboardStatusChanged
	{
		 get { } //Length: 8
		 set { } //Length: 88
	}

	public OnValidateInput onValidateInput
	{
		 get { } //Length: 8
		 set { } //Length: 88
	}

	public OnChangeEvent onValueChanged
	{
		 get { } //Length: 8
		 set { } //Length: 88
	}

	public Graphic placeholder
	{
		 get { } //Length: 8
		 set { } //Length: 88
	}

	public float pointSize
	{
		 get { } //Length: 8
		 set { } //Length: 180
	}

	public override float preferredHeight
	{
		 get { } //Length: 304
	}

	public override float preferredWidth
	{
		 get { } //Length: 304
	}

	public bool readOnly
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public bool resetOnDeActivation
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public bool restoreOriginalTextOnEscape
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public bool richText
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public float scrollSensitivity
	{
		 get { } //Length: 8
		 set { } //Length: 116
	}

	public int selectionAnchorPosition
	{
		 get { } //Length: 24
		 set { } //Length: 60
	}

	public Color selectionColor
	{
		 get { } //Length: 20
		 set { } //Length: 44
	}

	public int selectionFocusPosition
	{
		 get { } //Length: 24
		 set { } //Length: 60
	}

	public int selectionStringAnchorPosition
	{
		 get { } //Length: 24
		 set { } //Length: 88
	}

	public int selectionStringFocusPosition
	{
		 get { } //Length: 24
		 set { } //Length: 88
	}

	public bool shouldHideMobileInput
	{
		 get { } //Length: 136
		 set { } //Length: 188
	}

	public bool shouldHideSoftKeyboard
	{
		 get { } //Length: 248
		 set { } //Length: 380
	}

	public int stringPosition
	{
		 get { } //Length: 24
		 set { } //Length: 52
	}

	protected int stringPositionInternal
	{
		 get { } //Length: 24
		 set { } //Length: 56
	}

	protected int stringSelectPositionInternal
	{
		 get { } //Length: 24
		 set { } //Length: 56
	}

	public string text
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public TMP_Text textComponent
	{
		 get { } //Length: 8
		 set { } //Length: 116
	}

	public RectTransform textViewport
	{
		 get { } //Length: 8
		 set { } //Length: 88
	}

	public Scrollbar verticalScrollbar
	{
		 get { } //Length: 8
		 set { } //Length: 436
	}

	public bool wasCanceled
	{
		 get { } //Length: 8
	}

	private static TMP_InputField() { }

	protected TMP_InputField() { }

	public void ActivateInputField() { }

	private void ActivateInputFieldInternal() { }

	private void AdjustRectTransformRelativeToViewport(Vector2 startPosition, float height, bool isCharVisible) { }

	private void AdjustTextPositionRelativeToViewport(float relativePosition) { }

	protected override void Append(string input) { }

	protected override void Append(char input) { }

	private void AssignPositioningIfNeeded() { }

	private void Backspace() { }

	public override void CalculateLayoutInputHorizontal() { }

	public override void CalculateLayoutInputVertical() { }

	[IteratorStateMachine(typeof(<CaretBlink>d__276))]
	private IEnumerator CaretBlink() { }

	protected void ClampCaretPos(ref int pos) { }

	protected void ClampStringPos(ref int pos) { }

	private void CreateCursorVerts() { }

	public void DeactivateInputField(bool clearSelection = false) { }

	private void Delete() { }

	private void DeleteKey() { }

	protected virtual void DoStateTransition(SelectionState state, bool instant) { }

	private void EnforceContentType() { }

	private int FindNextWordBegin() { }

	private int FindPrevWordBegin() { }

	public void ForceLabelUpdate() { }

	private void GenerateCaret(VertexHelper vbo, Vector2 roundingOffset) { }

	private void GenerateHightlight(VertexHelper vbo, Vector2 roundingOffset) { }

	public char get_asteriskChar() { }

	public float get_caretBlinkRate() { }

	public Color get_caretColor() { }

	public int get_caretPosition() { }

	protected int get_caretPositionInternal() { }

	protected int get_caretSelectPositionInternal() { }

	public int get_caretWidth() { }

	public int get_characterLimit() { }

	public CharacterValidation get_characterValidation() { }

	private static string get_clipboard() { }

	private int get_compositionLength() { }

	private string get_compositionString() { }

	public ContentType get_contentType() { }

	public bool get_customCaretColor() { }

	public override float get_flexibleHeight() { }

	public override float get_flexibleWidth() { }

	public TMP_FontAsset get_fontAsset() { }

	private bool get_hasSelection() { }

	private BaseInput get_inputSystem() { }

	public InputType get_inputType() { }

	public TMP_InputValidator get_inputValidator() { }

	public bool get_isFocused() { }

	public bool get_isRichTextEditingAllowed() { }

	public TouchScreenKeyboardType get_keyboardType() { }

	public override int get_layoutPriority() { }

	public int get_lineLimit() { }

	public LineType get_lineType() { }

	protected Mesh get_mesh() { }

	public override float get_minHeight() { }

	public override float get_minWidth() { }

	public bool get_multiLine() { }

	public SelectionEvent get_onDeselect() { }

	public SubmitEvent get_onEndEdit() { }

	public TextSelectionEvent get_onEndTextSelection() { }

	public bool get_onFocusSelectAll() { }

	public SelectionEvent get_onSelect() { }

	public SubmitEvent get_onSubmit() { }

	public TextSelectionEvent get_onTextSelection() { }

	public TouchScreenKeyboardEvent get_onTouchScreenKeyboardStatusChanged() { }

	public OnValidateInput get_onValidateInput() { }

	public OnChangeEvent get_onValueChanged() { }

	public Graphic get_placeholder() { }

	public float get_pointSize() { }

	public override float get_preferredHeight() { }

	public override float get_preferredWidth() { }

	public bool get_readOnly() { }

	public bool get_resetOnDeActivation() { }

	public bool get_restoreOriginalTextOnEscape() { }

	public bool get_richText() { }

	public float get_scrollSensitivity() { }

	public int get_selectionAnchorPosition() { }

	public Color get_selectionColor() { }

	public int get_selectionFocusPosition() { }

	public int get_selectionStringAnchorPosition() { }

	public int get_selectionStringFocusPosition() { }

	public bool get_shouldHideMobileInput() { }

	public bool get_shouldHideSoftKeyboard() { }

	public int get_stringPosition() { }

	protected int get_stringPositionInternal() { }

	protected int get_stringSelectPositionInternal() { }

	public string get_text() { }

	public TMP_Text get_textComponent() { }

	public RectTransform get_textViewport() { }

	public Scrollbar get_verticalScrollbar() { }

	public bool get_wasCanceled() { }

	private int GetCaretPositionFromStringIndex(int stringIndex) { }

	private int GetMaxCaretPositionFromStringIndex(int stringIndex) { }

	private int GetMinCaretPositionFromStringIndex(int stringIndex) { }

	private float GetScrollPositionRelativeToViewport() { }

	private string GetSelectedString() { }

	private int GetStringIndexFromCaretPosition(int caretPosition) { }

	public override void GraphicUpdateComplete() { }

	private bool InPlaceEditing() { }

	private void Insert(char c) { }

	private bool isKeyboardUsingEvents() { }

	protected override bool IsValidChar(char c) { }

	protected EditState KeyPressed(Event evt) { }

	protected override void LateUpdate() { }

	public override void LayoutComplete() { }

	private int LineDownCharacterPosition(int originalPos, bool goToLastChar) { }

	private int LineUpCharacterPosition(int originalPos, bool goToFirstChar) { }

	private void MarkGeometryAsDirty() { }

	private bool MayDrag(PointerEventData eventData) { }

	[IteratorStateMachine(typeof(<MouseDragOutsideRect>d__294))]
	private IEnumerator MouseDragOutsideRect(PointerEventData eventData) { }

	private void MoveDown(bool shift) { }

	private void MoveDown(bool shift, bool goToLastChar) { }

	private void MoveLeft(bool shift, bool ctrl) { }

	private void MovePageDown(bool shift) { }

	private void MovePageDown(bool shift, bool goToLastChar) { }

	private void MovePageUp(bool shift) { }

	private void MovePageUp(bool shift, bool goToFirstChar) { }

	private void MoveRight(bool shift, bool ctrl) { }

	public void MoveTextEnd(bool shift) { }

	public void MoveTextStart(bool shift) { }

	public void MoveToEndOfLine(bool shift, bool ctrl) { }

	public void MoveToStartOfLine(bool shift, bool ctrl) { }

	private void MoveUp(bool shift, bool goToFirstChar) { }

	private void MoveUp(bool shift) { }

	private void ON_TEXT_CHANGED(object obj) { }

	public override void OnBeginDrag(PointerEventData eventData) { }

	public void OnControlClick() { }

	public virtual void OnDeselect(BaseEventData eventData) { }

	protected virtual void OnDisable() { }

	public override void OnDrag(PointerEventData eventData) { }

	protected virtual void OnEnable() { }

	public override void OnEndDrag(PointerEventData eventData) { }

	private void OnFillVBO(Mesh vbo) { }

	protected void OnFocus() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public virtual void OnPointerDown(PointerEventData eventData) { }

	public override void OnScroll(PointerEventData eventData) { }

	private void OnScrollbarValueChange(float value) { }

	public virtual void OnSelect(BaseEventData eventData) { }

	public override void OnSubmit(BaseEventData eventData) { }

	public override void OnUpdateSelected(BaseEventData eventData) { }

	private int PageDownCharacterPosition(int originalPos, bool goToLastChar) { }

	private int PageUpCharacterPosition(int originalPos, bool goToFirstChar) { }

	public void ProcessEvent(Event e) { }

	public override void Rebuild(CanvasUpdate update) { }

	public void ReleaseSelection() { }

	protected void SelectAll() { }

	protected void SendOnEndEdit() { }

	protected void SendOnEndTextSelection() { }

	protected void SendOnFocus() { }

	protected void SendOnFocusLost() { }

	protected void SendOnSubmit() { }

	protected void SendOnTextSelection() { }

	private void SendOnValueChanged() { }

	private void SendOnValueChangedAndUpdateLabel() { }

	protected void SendTouchScreenKeyboardStatusChanged() { }

	public void set_asteriskChar(char value) { }

	public void set_caretBlinkRate(float value) { }

	public void set_caretColor(Color value) { }

	public void set_caretPosition(int value) { }

	protected void set_caretPositionInternal(int value) { }

	protected void set_caretSelectPositionInternal(int value) { }

	public void set_caretWidth(int value) { }

	public void set_characterLimit(int value) { }

	public void set_characterValidation(CharacterValidation value) { }

	private static void set_clipboard(string value) { }

	public void set_contentType(ContentType value) { }

	public void set_customCaretColor(bool value) { }

	public void set_fontAsset(TMP_FontAsset value) { }

	public void set_inputType(InputType value) { }

	public void set_inputValidator(TMP_InputValidator value) { }

	public void set_isRichTextEditingAllowed(bool value) { }

	public void set_keyboardType(TouchScreenKeyboardType value) { }

	public void set_lineLimit(int value) { }

	public void set_lineType(LineType value) { }

	public void set_onDeselect(SelectionEvent value) { }

	public void set_onEndEdit(SubmitEvent value) { }

	public void set_onEndTextSelection(TextSelectionEvent value) { }

	public void set_onFocusSelectAll(bool value) { }

	public void set_onSelect(SelectionEvent value) { }

	public void set_onSubmit(SubmitEvent value) { }

	public void set_onTextSelection(TextSelectionEvent value) { }

	public void set_onTouchScreenKeyboardStatusChanged(TouchScreenKeyboardEvent value) { }

	public void set_onValidateInput(OnValidateInput value) { }

	public void set_onValueChanged(OnChangeEvent value) { }

	public void set_placeholder(Graphic value) { }

	public void set_pointSize(float value) { }

	public void set_readOnly(bool value) { }

	public void set_resetOnDeActivation(bool value) { }

	public void set_restoreOriginalTextOnEscape(bool value) { }

	public void set_richText(bool value) { }

	public void set_scrollSensitivity(float value) { }

	public void set_selectionAnchorPosition(int value) { }

	public void set_selectionColor(Color value) { }

	public void set_selectionFocusPosition(int value) { }

	public void set_selectionStringAnchorPosition(int value) { }

	public void set_selectionStringFocusPosition(int value) { }

	public void set_shouldHideMobileInput(bool value) { }

	public void set_shouldHideSoftKeyboard(bool value) { }

	public void set_stringPosition(int value) { }

	protected void set_stringPositionInternal(int value) { }

	protected void set_stringSelectPositionInternal(int value) { }

	public void set_text(string value) { }

	public void set_textComponent(TMP_Text value) { }

	public void set_textViewport(RectTransform value) { }

	public void set_verticalScrollbar(Scrollbar value) { }

	private void SetCaretActive() { }

	private void SetCaretVisible() { }

	public void SetGlobalFontAsset(TMP_FontAsset fontAsset) { }

	public void SetGlobalPointSize(float pointSize) { }

	private void SetText(string value, bool sendCallback = true) { }

	private void SetTextComponentRichTextMode() { }

	private void SetTextComponentWrapMode() { }

	public void SetTextWithoutNotify(string input) { }

	private void SetToCustom() { }

	private void SetToCustom(CharacterValidation characterValidation) { }

	private void SetToCustomIfContentTypeIsNot(ContentType[] allowedContentTypes) { }

	private override Transform UnityEngine.UI.ICanvasElement.get_transform() { }

	private void UpdateGeometry() { }

	protected void UpdateLabel() { }

	private void UpdateMaskRegions() { }

	private void UpdateScrollbar() { }

	private void UpdateStringPositionFromKeyboard() { }

	private void UpdateTouchKeyboardFromEditChanges() { }

	protected char Validate(string text, int pos, char ch) { }

}

