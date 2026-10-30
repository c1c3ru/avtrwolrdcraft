namespace Mono.Security.Cryptography;

public class ARC4Managed : RC4, ICryptoTransform, IDisposable
{
	private Byte[] key; //Field offset: 0x48
	private Byte[] state; //Field offset: 0x50
	private byte x; //Field offset: 0x58
	private byte y; //Field offset: 0x59
	private bool m_disposed; //Field offset: 0x5A

	public override bool CanTransformMultipleBlocks
	{
		 get { } //Length: 8
	}

	public override int InputBlockSize
	{
		 get { } //Length: 8
	}

	public virtual Byte[] Key
	{
		 get { } //Length: 148
		 set { } //Length: 252
	}

	public override int OutputBlockSize
	{
		 get { } //Length: 8
	}

	public ARC4Managed() { }

	private void CheckInput(Byte[] inputBuffer, int inputOffset, int inputCount) { }

	public virtual ICryptoTransform CreateDecryptor(Byte[] rgbKey, Byte[] rgvIV) { }

	public virtual ICryptoTransform CreateEncryptor(Byte[] rgbKey, Byte[] rgvIV) { }

	protected virtual void Dispose(bool disposing) { }

	protected virtual void Finalize() { }

	public virtual void GenerateIV() { }

	public virtual void GenerateKey() { }

	public override bool get_CanTransformMultipleBlocks() { }

	public override int get_InputBlockSize() { }

	public virtual Byte[] get_Key() { }

	public override int get_OutputBlockSize() { }

	private int InternalTransformBlock(Byte[] inputBuffer, int inputOffset, int inputCount, Byte[] outputBuffer, int outputOffset) { }

	private void KeySetup(Byte[] key) { }

	public virtual void set_Key(Byte[] value) { }

	public override int TransformBlock(Byte[] inputBuffer, int inputOffset, int inputCount, Byte[] outputBuffer, int outputOffset) { }

	public override Byte[] TransformFinalBlock(Byte[] inputBuffer, int inputOffset, int inputCount) { }

}

