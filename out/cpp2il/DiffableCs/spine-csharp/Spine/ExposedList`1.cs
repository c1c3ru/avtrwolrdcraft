namespace Spine;

[DebuggerDisplay("Count={Count}")]
public class ExposedList : IEnumerable<T>, IEnumerable
{
	internal struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
	{
		private ExposedList<T> l; //Field offset: 0x0
		private int next; //Field offset: 0x0
		private int ver; //Field offset: 0x0
		private T current; //Field offset: 0x0

		public override T Current
		{
			 get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			private get { } //Length: 160
		}

		internal Enumerator(ExposedList<T> l) { }

		public override void Dispose() { }

		public override T get_Current() { }

		public override bool MoveNext() { }

		private override object System.Collections.IEnumerator.get_Current() { }

		private override void System.Collections.IEnumerator.Reset() { }

		private void VerifyState() { }

	}

	private const int DefaultCapacity = 4; //Field offset: 0x0
	private static readonly T[] EmptyArray; //Field offset: 0x0
	public T[] Items; //Field offset: 0x0
	public int Count; //Field offset: 0x0
	private int version; //Field offset: 0x0

	public int Capacity
	{
		 get { } //Length: 28
		 set { } //Length: 92
	}

	private static ExposedList`1() { }

	internal ExposedList`1(T[] data, int size) { }

	public ExposedList`1() { }

	public ExposedList`1(IEnumerable<T> collection) { }

	public ExposedList`1(int capacity) { }

	public void Add(T item) { }

	private void AddCollection(ICollection<T> collection) { }

	private void AddEnumerable(IEnumerable<T> enumerable) { }

	public void AddRange(ExposedList<T> list) { }

	public void AddRange(IEnumerable<T> collection) { }

	public int BinarySearch(T item) { }

	public int BinarySearch(T item, IComparer<T> comparer) { }

	public int BinarySearch(int index, int count, T item, IComparer<T> comparer) { }

	private void CheckCollection(IEnumerable<T> collection) { }

	private void CheckIndex(int index) { }

	private static void CheckMatch(Predicate<T> match) { }

	private void CheckRange(int index, int count) { }

	public void Clear(bool clearArray = true) { }

	public bool Contains(T item) { }

	public ExposedList<TOutput> ConvertAll(Converter<T, TOutput> converter) { }

	public void CopyTo(T[] array, int arrayIndex) { }

	public void CopyTo(int index, T[] array, int arrayIndex, int count) { }

	public void CopyTo(T[] array) { }

	public void EnsureCapacity(int min) { }

	public bool Exists(Predicate<T> match) { }

	public T Find(Predicate<T> match) { }

	public ExposedList<T> FindAll(Predicate<T> match) { }

	private ExposedList<T> FindAllList(Predicate<T> match) { }

	public int FindIndex(Predicate<T> match) { }

	public int FindIndex(int startIndex, Predicate<T> match) { }

	public int FindIndex(int startIndex, int count, Predicate<T> match) { }

	public T FindLast(Predicate<T> match) { }

	public int FindLastIndex(int startIndex, Predicate<T> match) { }

	public int FindLastIndex(Predicate<T> match) { }

	public int FindLastIndex(int startIndex, int count, Predicate<T> match) { }

	public void ForEach(Action<T> action) { }

	public int get_Capacity() { }

	public Enumerator<T> GetEnumerator() { }

	private int GetIndex(int startIndex, int count, Predicate<T> match) { }

	private int GetLastIndex(int startIndex, int count, Predicate<T> match) { }

	public ExposedList<T> GetRange(int index, int count) { }

	public void GrowIfNeeded(int addedCount) { }

	public int IndexOf(T item, int index) { }

	public int IndexOf(T item, int index, int count) { }

	public int IndexOf(T item) { }

	public void Insert(int index, T item) { }

	private void InsertCollection(int index, ICollection<T> collection) { }

	private void InsertEnumeration(int index, IEnumerable<T> enumerable) { }

	public void InsertRange(int index, IEnumerable<T> collection) { }

	public int LastIndexOf(T item) { }

	public int LastIndexOf(T item, int index) { }

	public int LastIndexOf(T item, int index, int count) { }

	public T Pop() { }

	public bool Remove(T item) { }

	public int RemoveAll(Predicate<T> match) { }

	public void RemoveAt(int index) { }

	public void RemoveRange(int index, int count) { }

	public ExposedList<T> Resize(int newSize) { }

	public void Reverse() { }

	public void Reverse(int index, int count) { }

	public void set_Capacity(int value) { }

	private void Shift(int start, int delta) { }

	public void Sort(Comparison<T> comparison) { }

	public void Sort(IComparer<T> comparer) { }

	public void Sort() { }

	public void Sort(int index, int count, IComparer<T> comparer) { }

	private override IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator() { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	public T[] ToArray() { }

	public void TrimExcess() { }

	public bool TrueForAll(Predicate<T> match) { }

}

