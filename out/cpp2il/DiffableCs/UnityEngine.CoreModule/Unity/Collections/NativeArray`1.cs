namespace Unity.Collections;

[DebuggerDisplay("Length = {m_Length}")]
[DebuggerTypeProxy(typeof(NativeArrayDebugView`1))]
[DefaultMember("Item")]
[NativeContainer]
[NativeContainerSupportsDeallocateOnJobCompletion]
[NativeContainerSupportsDeferredConvertListToArray]
[NativeContainerSupportsMinMaxWriteRestriction]
public struct NativeArray : IDisposable, IEnumerable<T>, IEnumerable, IEquatable<NativeArray`1<T>>
{
	[ExcludeFromDocs]
	internal struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
	{
		private NativeArray<T> m_Array; //Field offset: 0x0
		private int m_Index; //Field offset: 0x0
		private T value; //Field offset: 0x0

		public override T Current
		{
			 get { } //Length: 32
		}

		private override object System.Collections.IEnumerator.Current
		{
			private get { } //Length: 132
		}

		public Enumerator(ref NativeArray<T>& array) { }

		public override void Dispose() { }

		public override T get_Current() { }

		public override bool MoveNext() { }

		public override void Reset() { }

		private override object System.Collections.IEnumerator.get_Current() { }

	}

	[DebuggerDisplay("Length = {Length}")]
	[DebuggerTypeProxy(typeof(NativeArrayReadOnlyDebugView`1))]
	[DefaultMember("Item")]
	[NativeContainer]
	[NativeContainerIsReadOnly]
	internal struct ReadOnly : IEnumerable<T>, IEnumerable
	{
		[ExcludeFromDocs]
		internal struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
		{
			private ReadOnly<T> m_Array; //Field offset: 0x0
			private int m_Index; //Field offset: 0x0
			private T value; //Field offset: 0x0

			public override T Current
			{
				 get { } //Length: 32
			}

			private override object System.Collections.IEnumerator.Current
			{
				private get { } //Length: 132
			}

			public Enumerator(in ReadOnly<T> array) { }

			public override void Dispose() { }

			public override T get_Current() { }

			public override bool MoveNext() { }

			public override void Reset() { }

			private override object System.Collections.IEnumerator.get_Current() { }

		}

		[NativeDisableUnsafePtrRestriction]
		internal Void* m_Buffer; //Field offset: 0x0
		internal int m_Length; //Field offset: 0x0

		public T Item
		{
			 get { } //Length: 120
		}

		public int Length
		{
			 get { } //Length: 8
		}

		internal ReadOnly(Void* buffer, int length) { }

		public T get_Item(int index) { }

		public int get_Length() { }

		public Enumerator<T> GetEnumerator() { }

		private override IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator() { }

		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	}

	[NativeDisableUnsafePtrRestriction]
	internal Void* m_Buffer; //Field offset: 0x0
	internal int m_Length; //Field offset: 0x0
	internal Allocator m_AllocatorLabel; //Field offset: 0x0

	public bool IsCreated
	{
		 get { } //Length: 16
	}

	public T Item
	{
		 get { } //Length: 120
		[WriteAccessRequired]
		 set { } //Length: 120
	}

	public int Length
	{
		 get { } //Length: 8
	}

	public NativeArray`1(int length, Allocator allocator, NativeArrayOptions options = 1) { }

	public NativeArray`1(T[] array, Allocator allocator) { }

	public NativeArray`1(NativeArray<T> array, Allocator allocator) { }

	private static void Allocate(int length, Allocator allocator, out NativeArray<T>& array) { }

	public ReadOnly<T> AsReadOnly() { }

	public static void Copy(T[] src, NativeArray<T> dst) { }

	public static void Copy(NativeArray<T> src, T[] dst, int length) { }

	public static void Copy(NativeArray<T> src, int srcIndex, NativeArray<T> dst, int dstIndex, int length) { }

	public static void Copy(NativeArray<T> src, NativeArray<T> dst) { }

	[WriteAccessRequired]
	public void CopyFrom(T[] array) { }

	[WriteAccessRequired]
	public void CopyFrom(NativeArray<T> array) { }

	private static void CopySafe(NativeArray<T> src, int srcIndex, NativeArray<T> dst, int dstIndex, int length) { }

	private static void CopySafe(T[] src, int srcIndex, NativeArray<T> dst, int dstIndex, int length) { }

	private static void CopySafe(NativeArray<T> src, int srcIndex, T[] dst, int dstIndex, int length) { }

	public void CopyTo(NativeArray<T> array) { }

	public JobHandle Dispose(JobHandle inputDeps) { }

	[WriteAccessRequired]
	public override void Dispose() { }

	public override bool Equals(NativeArray<T> other) { }

	public virtual bool Equals(object obj) { }

	public bool get_IsCreated() { }

	public T get_Item(int index) { }

	public int get_Length() { }

	public Enumerator<T> GetEnumerator() { }

	public virtual int GetHashCode() { }

	public NativeArray<T> GetSubArray(int start, int length) { }

	[WriteAccessRequired]
	public void set_Item(int index, T value) { }

	private override IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator() { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	public T[] ToArray() { }

}

