namespace Mono.Math.Prime.Generator;

public abstract class PrimeGeneratorBase
{

	public override ConfidenceFactor Confidence
	{
		 get { } //Length: 8
	}

	public override PrimalityTest PrimalityTest
	{
		 get { } //Length: 108
	}

	public override int TrialDivisionBounds
	{
		 get { } //Length: 8
	}

	protected PrimeGeneratorBase() { }

	public abstract BigInteger GenerateNewPrime(int bits) { }

	public override ConfidenceFactor get_Confidence() { }

	public override PrimalityTest get_PrimalityTest() { }

	public override int get_TrialDivisionBounds() { }

}

