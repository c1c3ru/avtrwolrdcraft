namespace Unity.Burst.Intrinsics;

[AttributeUsage(AttributeTargets::Method (64), Inherited = False)]
[Preserve]
internal sealed class BurstTargetCpuAttribute : Attribute
{
	public readonly BurstTargetCpu TargetCpu; //Field offset: 0x10

	public BurstTargetCpuAttribute(BurstTargetCpu TargetCpu) { }

}

