namespace PWC.Json;

public class PJColor32
{
	public byte r; //Field offset: 0x10
	public byte g; //Field offset: 0x11
	public byte b; //Field offset: 0x12
	public byte a; //Field offset: 0x13

	public PJColor32(Color32 color32) { }

	public Color32 GetColor32() { }

}

