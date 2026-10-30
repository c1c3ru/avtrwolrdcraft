namespace Unity.Collections;

[BurstCompatible(RequiredUnityDefine = "UNITY_2020_2_OR_NEWER", GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(Unity.Collections.NativeSortExtension+DefaultComparer`1<System.Int32>)})]
public struct SortJob
{
	[BurstCompile]
	private struct SegmentSort : IJobParallelFor
	{
		[NativeDisableUnsafePtrRestriction]
		public T* Data; //Field offset: 0x0
		public U Comp; //Field offset: 0x0
		public int Length; //Field offset: 0x0
		public int SegmentWidth; //Field offset: 0x0

		public override void Execute(int index) { }

	}

	[BurstCompile]
	private struct SegmentSortMerge : IJob
	{
		[NativeDisableUnsafePtrRestriction]
		public T* Data; //Field offset: 0x0
		public U Comp; //Field offset: 0x0
		public int Length; //Field offset: 0x0
		public int SegmentWidth; //Field offset: 0x0

		public override void Execute() { }

	}

	public T* Data; //Field offset: 0x0
	public U Comp; //Field offset: 0x0
	public int Length; //Field offset: 0x0

	[NotBurstCompatible]
	public JobHandle Schedule(JobHandle inputDeps = null) { }

}

