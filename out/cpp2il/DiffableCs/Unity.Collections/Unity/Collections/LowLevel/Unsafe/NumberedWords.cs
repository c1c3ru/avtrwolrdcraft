namespace Unity.Collections.LowLevel.Unsafe;

[Obsolete("This storage will no longer be used. (RemovedAfter 2021-06-01)")]
public struct NumberedWords
{
	private const int kPositiveNumericSuffixShift = 0; //Field offset: 0x0
	private const int kPositiveNumericSuffixBits = 29; //Field offset: 0x0
	private const int kMaxPositiveNumericSuffix = 536870911; //Field offset: 0x0
	private const int kPositiveNumericSuffixMask = 536870911; //Field offset: 0x0
	private const int kLeadingZeroesShift = 29; //Field offset: 0x0
	private const int kLeadingZeroesBits = 3; //Field offset: 0x0
	private const int kMaxLeadingZeroes = 7; //Field offset: 0x0
	private const int kLeadingZeroesMask = 7; //Field offset: 0x0
	private int Index; //Field offset: 0x0
	private int Suffix; //Field offset: 0x4

	private bool HasPositiveNumericSuffix
	{
		private get { } //Length: 16
	}

	private int LeadingZeroes
	{
		private get { } //Length: 12
		private set { } //Length: 16
	}

	private int PositiveNumericSuffix
	{
		private get { } //Length: 12
		private set { } //Length: 16
	}

	private bool get_HasPositiveNumericSuffix() { }

	private int get_LeadingZeroes() { }

	private int get_PositiveNumericSuffix() { }

	private bool IsDigit(byte b) { }

	[NotBurstCompatible]
	private string NewString(char c, int count) { }

	private void set_LeadingZeroes(int value) { }

	private void set_PositiveNumericSuffix(int value) { }

	[NotBurstCompatible]
	public void SetString(ref T value) { }

	[NotBurstCompatible]
	public void SetString(string value) { }

	[NotBurstCompatible]
	public int ToFixedString(ref T result) { }

	[NotBurstCompatible]
	public virtual string ToString() { }

}

