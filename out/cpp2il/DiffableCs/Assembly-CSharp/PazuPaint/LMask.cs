namespace PazuPaint;

public class LMask
{
	public Byte[] alphas; //Field offset: 0x10
	public int width; //Field offset: 0x18
	public int height; //Field offset: 0x1C

	public LMask(int width, int height, byte valueInArray = 0) { }

	public LMask(Texture2D texture) { }

	public LMask(Texture2D texture, Rect rect) { }

	public void AddMask(LMask mask, int x, int y) { }

	public void Clear() { }

	public byte GetAlpha(int x, int y) { }

	public void GetAlphas(Byte[] arrayTofill) { }

	public Byte[] GetAlphas(int x, int y, int width, int height) { }

	public void GetAlphas(int x, int y, int width, int height, Byte[] arrayToFill) { }

	public void Invert() { }

	public void OverrideMask(byte value, int x, int y, int width, int height) { }

	public void OverrideMask(LMask mask, int x, int y) { }

}

