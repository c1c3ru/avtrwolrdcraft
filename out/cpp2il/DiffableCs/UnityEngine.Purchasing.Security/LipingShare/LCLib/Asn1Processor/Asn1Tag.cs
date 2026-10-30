namespace LipingShare.LCLib.Asn1Processor;

internal class Asn1Tag
{
	public const byte TAG_MASK = 31; //Field offset: 0x0
	public const byte GENERAL_STRING = 27; //Field offset: 0x0
	public const byte VISIBLE_STRING = 26; //Field offset: 0x0
	public const byte GRAPHIC_STRING = 25; //Field offset: 0x0
	public const byte GENERALIZED_TIME = 24; //Field offset: 0x0
	public const byte UTC_TIME = 23; //Field offset: 0x0
	public const byte IA5_STRING = 22; //Field offset: 0x0
	public const byte VIDEOTEXT_STRING = 21; //Field offset: 0x0
	public const byte T61_STRING = 20; //Field offset: 0x0
	public const byte PRINTABLE_STRING = 19; //Field offset: 0x0
	public const byte NUMERIC_STRING = 18; //Field offset: 0x0
	public const byte SET = 17; //Field offset: 0x0
	public const byte SEQUENCE = 16; //Field offset: 0x0
	public const byte RELATIVE_OID = 13; //Field offset: 0x0
	public const byte UTF8_STRING = 12; //Field offset: 0x0
	public const byte ENUMERATED = 10; //Field offset: 0x0
	public const byte REAL = 9; //Field offset: 0x0
	public const byte EXTERNAL = 8; //Field offset: 0x0
	public const byte OBJECT_DESCRIPTOR = 7; //Field offset: 0x0
	public const byte OBJECT_IDENTIFIER = 6; //Field offset: 0x0
	public const byte TAG_NULL = 5; //Field offset: 0x0
	public const byte OCTET_STRING = 4; //Field offset: 0x0
	public const byte BIT_STRING = 3; //Field offset: 0x0
	public const byte INTEGER = 2; //Field offset: 0x0
	public const byte BOOLEAN = 1; //Field offset: 0x0
	public const byte TAG_END_OF_CONTENTS = 0; //Field offset: 0x0
	public const byte UNIVERSAL_STRING = 28; //Field offset: 0x0
	public const byte BMPSTRING = 30; //Field offset: 0x0

	public Asn1Tag() { }

}

