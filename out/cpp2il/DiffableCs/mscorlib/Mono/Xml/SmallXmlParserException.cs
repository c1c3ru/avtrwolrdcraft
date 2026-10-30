namespace Mono.Xml;

internal class SmallXmlParserException : SystemException
{
	private int line; //Field offset: 0x8C
	private int column; //Field offset: 0x90

	public SmallXmlParserException(string msg, int line, int column) { }

}

