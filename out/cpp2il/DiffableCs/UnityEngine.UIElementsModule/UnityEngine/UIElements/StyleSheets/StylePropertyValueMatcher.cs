namespace UnityEngine.UIElements.StyleSheets;

internal class StylePropertyValueMatcher : BaseStyleMatcher
{
	private List<StylePropertyValue> m_Values; //Field offset: 0x20

	private StylePropertyValue current
	{
		private get { } //Length: 132
	}

	public virtual bool isCurrentComma
	{
		 get { } //Length: 172
	}

	public virtual bool isCurrentVariable
	{
		 get { } //Length: 8
	}

	public virtual int valueCount
	{
		 get { } //Length: 72
	}

	public StylePropertyValueMatcher() { }

	private StylePropertyValue get_current() { }

	public virtual bool get_isCurrentComma() { }

	public virtual bool get_isCurrentVariable() { }

	public virtual int get_valueCount() { }

	public MatchResult Match(Expression exp, List<StylePropertyValue> values) { }

	protected virtual bool MatchAngle() { }

	protected virtual bool MatchColor() { }

	protected virtual bool MatchCustomIdent() { }

	protected virtual bool MatchInteger() { }

	protected virtual bool MatchKeyword(string keyword) { }

	protected virtual bool MatchLength() { }

	protected virtual bool MatchNumber() { }

	protected virtual bool MatchPercentage() { }

	protected virtual bool MatchResource() { }

	protected virtual bool MatchTime() { }

	protected virtual bool MatchUrl() { }

}

