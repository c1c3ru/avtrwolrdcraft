namespace UnityEngine;

public class TextEditor
{
	private enum CharacterType
	{
		LetterLike = 0,
		Symbol = 1,
		Symbol2 = 2,
		WhiteSpace = 3,
	}

	internal enum DblClickSnapping
	{
		WORDS = 0,
		PARAGRAPHS = 1,
	}

	private enum Direction
	{
		Forward = 0,
		Backward = 1,
	}

	private enum TextEditOp
	{
		MoveLeft = 0,
		MoveRight = 1,
		MoveUp = 2,
		MoveDown = 3,
		MoveLineStart = 4,
		MoveLineEnd = 5,
		MoveTextStart = 6,
		MoveTextEnd = 7,
		MovePageUp = 8,
		MovePageDown = 9,
		MoveGraphicalLineStart = 10,
		MoveGraphicalLineEnd = 11,
		MoveWordLeft = 12,
		MoveWordRight = 13,
		MoveParagraphForward = 14,
		MoveParagraphBackward = 15,
		MoveToStartOfNextWord = 16,
		MoveToEndOfPreviousWord = 17,
		SelectLeft = 18,
		SelectRight = 19,
		SelectUp = 20,
		SelectDown = 21,
		SelectTextStart = 22,
		SelectTextEnd = 23,
		SelectPageUp = 24,
		SelectPageDown = 25,
		ExpandSelectGraphicalLineStart = 26,
		ExpandSelectGraphicalLineEnd = 27,
		SelectGraphicalLineStart = 28,
		SelectGraphicalLineEnd = 29,
		SelectWordLeft = 30,
		SelectWordRight = 31,
		SelectToEndOfPreviousWord = 32,
		SelectToStartOfNextWord = 33,
		SelectParagraphBackward = 34,
		SelectParagraphForward = 35,
		Delete = 36,
		Backspace = 37,
		DeleteWordBack = 38,
		DeleteWordForward = 39,
		DeleteLineBack = 40,
		Cut = 41,
		Copy = 42,
		Paste = 43,
		SelectAll = 44,
		SelectNone = 45,
		ScrollStart = 46,
		ScrollEnd = 47,
		ScrollPageUp = 48,
		ScrollPageDown = 49,
	}

	private static Dictionary<Event, TextEditOp> s_Keyactions; //Field offset: 0x0
	public TouchScreenKeyboard keyboardOnScreen; //Field offset: 0x10
	public int controlID; //Field offset: 0x18
	public GUIStyle style; //Field offset: 0x20
	public bool multiline; //Field offset: 0x28
	public bool hasHorizontalCursorPos; //Field offset: 0x29
	public bool isPasswordField; //Field offset: 0x2A
	internal bool m_HasFocus; //Field offset: 0x2B
	public Vector2 scrollOffset; //Field offset: 0x2C
	private GUIContent m_Content; //Field offset: 0x38
	private Rect m_Position; //Field offset: 0x40
	private int m_CursorIndex; //Field offset: 0x50
	private int m_SelectIndex; //Field offset: 0x54
	private bool m_RevealCursor; //Field offset: 0x58
	public Vector2 graphicalCursorPos; //Field offset: 0x5C
	public Vector2 graphicalSelectCursorPos; //Field offset: 0x64
	private bool m_MouseDragSelectsWholeWords; //Field offset: 0x6C
	private int m_DblClickInitPos; //Field offset: 0x70
	private DblClickSnapping m_DblClickSnap; //Field offset: 0x74
	private bool m_bJustSelected; //Field offset: 0x75
	private int m_iAltCursorPos; //Field offset: 0x78
	private string oldText; //Field offset: 0x80
	private int oldPos; //Field offset: 0x88
	private int oldSelectPos; //Field offset: 0x8C

	public int cursorIndex
	{
		 get { } //Length: 8
		 set { } //Length: 88
	}

	public bool hasSelection
	{
		 get { } //Length: 16
	}

	internal override Rect localPosition
	{
		internal get { } //Length: 12
	}

	public Rect position
	{
		 get { } //Length: 12
		 set { } //Length: 192
	}

	public int selectIndex
	{
		 get { } //Length: 8
		 set { } //Length: 80
	}

	public string text
	{
		 get { } //Length: 28
		 set { } //Length: 128
	}

	[RequiredByNativeCode]
	public TextEditor() { }

	public bool Backspace() { }

	private void ClampTextIndex(ref int index) { }

	private CharacterType ClassifyChar(int index) { }

	private void ClearCursorPos() { }

	public void Copy() { }

	public bool Cut() { }

	public void DblClickSnap(DblClickSnapping snapping) { }

	public bool Delete() { }

	public bool DeleteLineBack() { }

	public bool DeleteSelection() { }

	public bool DeleteWordBack() { }

	public bool DeleteWordForward() { }

	public void DetectFocusChange() { }

	public void DrawCursor(string newText) { }

	private void EnsureValidCodePointIndex(ref int index) { }

	public void ExpandSelectGraphicalLineEnd() { }

	public void ExpandSelectGraphicalLineStart() { }

	private int FindEndOfClassification(int p, Direction dir) { }

	private int FindEndOfPreviousWord(int p) { }

	private int FindNextSeperator(int startPos) { }

	private int FindPrevSeperator(int startPos) { }

	public int FindStartOfNextWord(int p) { }

	public int get_cursorIndex() { }

	public bool get_hasSelection() { }

	internal override Rect get_localPosition() { }

	public Rect get_position() { }

	public int get_selectIndex() { }

	public string get_text() { }

	private int GetGraphicalLineEnd(int p) { }

	private int GetGraphicalLineStart(int p) { }

	private void GrabGraphicalCursorPos() { }

	[VisibleToOtherModules]
	internal bool HandleKeyEvent(Event e, bool textIsReadOnly) { }

	public bool HandleKeyEvent(Event e) { }

	private int IndexOfEndOfLine(int startIndex) { }

	private void InitKeyActions() { }

	public void Insert(char c) { }

	private bool IsValidCodePointIndex(int index) { }

	private static void MapKey(string key, TextEditOp action) { }

	public void MouseDragSelectsWholeWords(bool on) { }

	public void MoveCursorToPosition(Vector2 cursorPosition) { }

	protected private void MoveCursorToPosition_Internal(Vector2 cursorPosition, bool shift) { }

	public void MoveDown() { }

	public void MoveGraphicalLineEnd() { }

	public void MoveGraphicalLineStart() { }

	public void MoveLeft() { }

	public void MoveLineEnd() { }

	public void MoveLineStart() { }

	public void MoveParagraphBackward() { }

	public void MoveParagraphForward() { }

	public void MoveRight() { }

	public void MoveTextEnd() { }

	public void MoveTextStart() { }

	public void MoveToEndOfPreviousWord() { }

	public void MoveToStartOfNextWord() { }

	public void MoveUp() { }

	public void MoveWordLeft() { }

	public void MoveWordRight() { }

	private int NextCodePointIndex(int index) { }

	internal override void OnCursorIndexChange() { }

	internal override void OnDetectFocusChange() { }

	public void OnFocus() { }

	public void OnLostFocus() { }

	internal override void OnSelectIndexChange() { }

	public bool Paste() { }

	private bool PerformOperation(TextEditOp operation, bool textIsReadOnly) { }

	private int PreviousCodePointIndex(int index) { }

	private static string ReplaceNewlinesWithSpaces(string value) { }

	public void ReplaceSelection(string replace) { }

	public void SaveBackup() { }

	public void SelectAll() { }

	public void SelectCurrentParagraph() { }

	public void SelectCurrentWord() { }

	public void SelectDown() { }

	public void SelectGraphicalLineEnd() { }

	public void SelectGraphicalLineStart() { }

	public void SelectLeft() { }

	public void SelectNone() { }

	public void SelectParagraphBackward() { }

	public void SelectParagraphForward() { }

	public void SelectRight() { }

	public void SelectTextEnd() { }

	public void SelectTextStart() { }

	public void SelectToEndOfPreviousWord() { }

	public void SelectToPosition(Vector2 cursorPosition) { }

	public void SelectToStartOfNextWord() { }

	public void SelectUp() { }

	public void SelectWordLeft() { }

	public void SelectWordRight() { }

	public void set_cursorIndex(int value) { }

	public void set_position(Rect value) { }

	public void set_selectIndex(int value) { }

	public void set_text(string value) { }

	[VisibleToOtherModules]
	internal void UpdateScrollOffset() { }

	public void UpdateScrollOffsetIfNeeded(Event evt) { }

}

