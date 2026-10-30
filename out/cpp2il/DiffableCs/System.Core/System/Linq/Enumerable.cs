namespace System.Linq;

[Extension]
public static class Enumerable
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_0
	{
		public Func<TSource, Boolean> predicate1; //Field offset: 0x0
		public Func<TSource, Boolean> predicate2; //Field offset: 0x0

		public <>c__DisplayClass6_0`1() { }

		internal bool <CombinePredicates>b__0(TSource x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass7_0
	{
		public Func<TMiddle, TResult> selector2; //Field offset: 0x0
		public Func<TSource, TMiddle> selector1; //Field offset: 0x0

		public <>c__DisplayClass7_0`3() { }

		internal TResult <CombineSelectors>b__0(TSource x) { }

	}

	[CompilerGenerated]
	private sealed class <CastIterator>d__99 : IEnumerable<TResult>, IEnumerable, IEnumerator<TResult>, IDisposable, IEnumerator
	{
		private int <>1__state; //Field offset: 0x0
		private TResult <>2__current; //Field offset: 0x0
		private int <>l__initialThreadId; //Field offset: 0x0
		private IEnumerable source; //Field offset: 0x0
		public IEnumerable <>3__source; //Field offset: 0x0
		private IEnumerator <>7__wrap1; //Field offset: 0x0

		private override TResult System.Collections.Generic.IEnumerator<TResult>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 12
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 48
		}

		[DebuggerHidden]
		public <CastIterator>d__99`1(int <>1__state) { }

		private void <>m__Finally1() { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<TResult> System.Collections.Generic.IEnumerable<TResult>.GetEnumerator() { }

		[DebuggerHidden]
		private override TResult System.Collections.Generic.IEnumerator<TResult>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <ConcatIterator>d__59 : IEnumerable<TSource>, IEnumerable, IEnumerator<TSource>, IDisposable, IEnumerator
	{
		private int <>1__state; //Field offset: 0x0
		private TSource <>2__current; //Field offset: 0x0
		private int <>l__initialThreadId; //Field offset: 0x0
		private IEnumerable<TSource> first; //Field offset: 0x0
		public IEnumerable<TSource> <>3__first; //Field offset: 0x0
		private IEnumerable<TSource> second; //Field offset: 0x0
		public IEnumerable<TSource> <>3__second; //Field offset: 0x0
		private IEnumerator<TSource> <>7__wrap1; //Field offset: 0x0

		private override TSource System.Collections.Generic.IEnumerator<TSource>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 40
		}

		[DebuggerHidden]
		public <ConcatIterator>d__59`1(int <>1__state) { }

		private void <>m__Finally1() { }

		private void <>m__Finally2() { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<TSource> System.Collections.Generic.IEnumerable<TSource>.GetEnumerator() { }

		[DebuggerHidden]
		private override TSource System.Collections.Generic.IEnumerator<TSource>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <DefaultIfEmptyIterator>d__95 : IEnumerable<TSource>, IEnumerable, IEnumerator<TSource>, IDisposable, IEnumerator
	{
		private int <>1__state; //Field offset: 0x0
		private TSource <>2__current; //Field offset: 0x0
		private int <>l__initialThreadId; //Field offset: 0x0
		private IEnumerable<TSource> source; //Field offset: 0x0
		public IEnumerable<TSource> <>3__source; //Field offset: 0x0
		private TSource defaultValue; //Field offset: 0x0
		public TSource <>3__defaultValue; //Field offset: 0x0
		private IEnumerator<TSource> <e>5__2; //Field offset: 0x0

		private override TSource System.Collections.Generic.IEnumerator<TSource>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 40
		}

		[DebuggerHidden]
		public <DefaultIfEmptyIterator>d__95`1(int <>1__state) { }

		private void <>m__Finally1() { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<TSource> System.Collections.Generic.IEnumerable<TSource>.GetEnumerator() { }

		[DebuggerHidden]
		private override TSource System.Collections.Generic.IEnumerator<TSource>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <DistinctIterator>d__68 : IEnumerable<TSource>, IEnumerable, IEnumerator<TSource>, IDisposable, IEnumerator
	{
		private int <>1__state; //Field offset: 0x0
		private TSource <>2__current; //Field offset: 0x0
		private int <>l__initialThreadId; //Field offset: 0x0
		private IEqualityComparer<TSource> comparer; //Field offset: 0x0
		public IEqualityComparer<TSource> <>3__comparer; //Field offset: 0x0
		private IEnumerable<TSource> source; //Field offset: 0x0
		public IEnumerable<TSource> <>3__source; //Field offset: 0x0
		private Set<TSource> <set>5__2; //Field offset: 0x0
		private IEnumerator<TSource> <>7__wrap2; //Field offset: 0x0

		private override TSource System.Collections.Generic.IEnumerator<TSource>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <DistinctIterator>d__68`1(int <>1__state) { }

		private void <>m__Finally1() { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<TSource> System.Collections.Generic.IEnumerable<TSource>.GetEnumerator() { }

		[DebuggerHidden]
		private override TSource System.Collections.Generic.IEnumerator<TSource>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <OfTypeIterator>d__97 : IEnumerable<TResult>, IEnumerable, IEnumerator<TResult>, IDisposable, IEnumerator
	{
		private int <>1__state; //Field offset: 0x0
		private TResult <>2__current; //Field offset: 0x0
		private int <>l__initialThreadId; //Field offset: 0x0
		private IEnumerable source; //Field offset: 0x0
		public IEnumerable <>3__source; //Field offset: 0x0
		private IEnumerator <>7__wrap1; //Field offset: 0x0

		private override TResult System.Collections.Generic.IEnumerator<TResult>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <OfTypeIterator>d__97`1(int <>1__state) { }

		private void <>m__Finally1() { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<TResult> System.Collections.Generic.IEnumerable<TResult>.GetEnumerator() { }

		[DebuggerHidden]
		private override TResult System.Collections.Generic.IEnumerator<TResult>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <RangeIterator>d__115 : IEnumerable<Int32>, IEnumerable, IEnumerator<Int32>, IDisposable, IEnumerator
	{
		private int <>1__state; //Field offset: 0x10
		private int <>2__current; //Field offset: 0x14
		private int <>l__initialThreadId; //Field offset: 0x18
		private int start; //Field offset: 0x1C
		public int <>3__start; //Field offset: 0x20
		private int count; //Field offset: 0x24
		public int <>3__count; //Field offset: 0x28
		private int <i>5__2; //Field offset: 0x2C

		private override int System.Collections.Generic.IEnumerator<System.Int32>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 92
		}

		[DebuggerHidden]
		public <RangeIterator>d__115(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<Int32> System.Collections.Generic.IEnumerable<System.Int32>.GetEnumerator() { }

		[DebuggerHidden]
		private override int System.Collections.Generic.IEnumerator<System.Int32>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <ReverseIterator>d__79 : IEnumerable<TSource>, IEnumerable, IEnumerator<TSource>, IDisposable, IEnumerator
	{
		private int <>1__state; //Field offset: 0x0
		private TSource <>2__current; //Field offset: 0x0
		private int <>l__initialThreadId; //Field offset: 0x0
		private IEnumerable<TSource> source; //Field offset: 0x0
		public IEnumerable<TSource> <>3__source; //Field offset: 0x0
		private Buffer<TSource> <buffer>5__2; //Field offset: 0x0
		private int <i>5__3; //Field offset: 0x0

		private override TSource System.Collections.Generic.IEnumerator<TSource>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <ReverseIterator>d__79`1(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<TSource> System.Collections.Generic.IEnumerable<TSource>.GetEnumerator() { }

		[DebuggerHidden]
		private override TSource System.Collections.Generic.IEnumerator<TSource>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <SelectIterator>d__5 : IEnumerable<TResult>, IEnumerable, IEnumerator<TResult>, IDisposable, IEnumerator
	{
		private int <>1__state; //Field offset: 0x0
		private TResult <>2__current; //Field offset: 0x0
		private int <>l__initialThreadId; //Field offset: 0x0
		private IEnumerable<TSource> source; //Field offset: 0x0
		public IEnumerable<TSource> <>3__source; //Field offset: 0x0
		private Func<TSource, Int32, TResult> selector; //Field offset: 0x0
		public Func<TSource, Int32, TResult> <>3__selector; //Field offset: 0x0
		private int <index>5__2; //Field offset: 0x0
		private IEnumerator<TSource> <>7__wrap2; //Field offset: 0x0

		private override TResult System.Collections.Generic.IEnumerator<TResult>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <SelectIterator>d__5`2(int <>1__state) { }

		private void <>m__Finally1() { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<TResult> System.Collections.Generic.IEnumerable<TResult>.GetEnumerator() { }

		[DebuggerHidden]
		private override TResult System.Collections.Generic.IEnumerator<TResult>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <SelectManyIterator>d__17 : IEnumerable<TResult>, IEnumerable, IEnumerator<TResult>, IDisposable, IEnumerator
	{
		private int <>1__state; //Field offset: 0x0
		private TResult <>2__current; //Field offset: 0x0
		private int <>l__initialThreadId; //Field offset: 0x0
		private IEnumerable<TSource> source; //Field offset: 0x0
		public IEnumerable<TSource> <>3__source; //Field offset: 0x0
		private Func<TSource, IEnumerable`1<TResult>> selector; //Field offset: 0x0
		public Func<TSource, IEnumerable`1<TResult>> <>3__selector; //Field offset: 0x0
		private IEnumerator<TSource> <>7__wrap1; //Field offset: 0x0
		private IEnumerator<TResult> <>7__wrap2; //Field offset: 0x0

		private override TResult System.Collections.Generic.IEnumerator<TResult>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <SelectManyIterator>d__17`2(int <>1__state) { }

		private void <>m__Finally1() { }

		private void <>m__Finally2() { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<TResult> System.Collections.Generic.IEnumerable<TResult>.GetEnumerator() { }

		[DebuggerHidden]
		private override TResult System.Collections.Generic.IEnumerator<TResult>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <SkipIterator>d__31 : IEnumerable<TSource>, IEnumerable, IEnumerator<TSource>, IDisposable, IEnumerator
	{
		private int <>1__state; //Field offset: 0x0
		private TSource <>2__current; //Field offset: 0x0
		private int <>l__initialThreadId; //Field offset: 0x0
		private IEnumerable<TSource> source; //Field offset: 0x0
		public IEnumerable<TSource> <>3__source; //Field offset: 0x0
		private int count; //Field offset: 0x0
		public int <>3__count; //Field offset: 0x0
		private IEnumerator<TSource> <e>5__2; //Field offset: 0x0

		private override TSource System.Collections.Generic.IEnumerator<TSource>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 40
		}

		[DebuggerHidden]
		public <SkipIterator>d__31`1(int <>1__state) { }

		private void <>m__Finally1() { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<TSource> System.Collections.Generic.IEnumerable<TSource>.GetEnumerator() { }

		[DebuggerHidden]
		private override TSource System.Collections.Generic.IEnumerator<TSource>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <SkipLastIterator>d__216 : IEnumerable<TSource>, IEnumerable, IEnumerator<TSource>, IDisposable, IEnumerator
	{
		private int <>1__state; //Field offset: 0x0
		private TSource <>2__current; //Field offset: 0x0
		private int <>l__initialThreadId; //Field offset: 0x0
		private IEnumerable<TSource> source; //Field offset: 0x0
		public IEnumerable<TSource> <>3__source; //Field offset: 0x0
		private int count; //Field offset: 0x0
		public int <>3__count; //Field offset: 0x0
		private Queue<TSource> <queue>5__2; //Field offset: 0x0
		private IEnumerator<TSource> <e>5__3; //Field offset: 0x0

		private override TSource System.Collections.Generic.IEnumerator<TSource>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <SkipLastIterator>d__216`1(int <>1__state) { }

		private void <>m__Finally1() { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<TSource> System.Collections.Generic.IEnumerable<TSource>.GetEnumerator() { }

		[DebuggerHidden]
		private override TSource System.Collections.Generic.IEnumerator<TSource>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <TakeIterator>d__25 : IEnumerable<TSource>, IEnumerable, IEnumerator<TSource>, IDisposable, IEnumerator
	{
		private int <>1__state; //Field offset: 0x0
		private TSource <>2__current; //Field offset: 0x0
		private int <>l__initialThreadId; //Field offset: 0x0
		private int count; //Field offset: 0x0
		public int <>3__count; //Field offset: 0x0
		private IEnumerable<TSource> source; //Field offset: 0x0
		public IEnumerable<TSource> <>3__source; //Field offset: 0x0
		private IEnumerator<TSource> <>7__wrap1; //Field offset: 0x0

		private override TSource System.Collections.Generic.IEnumerator<TSource>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 40
		}

		[DebuggerHidden]
		public <TakeIterator>d__25`1(int <>1__state) { }

		private void <>m__Finally1() { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<TSource> System.Collections.Generic.IEnumerable<TSource>.GetEnumerator() { }

		[DebuggerHidden]
		private override TSource System.Collections.Generic.IEnumerator<TSource>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <UnionIterator>d__71 : IEnumerable<TSource>, IEnumerable, IEnumerator<TSource>, IDisposable, IEnumerator
	{
		private int <>1__state; //Field offset: 0x0
		private TSource <>2__current; //Field offset: 0x0
		private int <>l__initialThreadId; //Field offset: 0x0
		private IEqualityComparer<TSource> comparer; //Field offset: 0x0
		public IEqualityComparer<TSource> <>3__comparer; //Field offset: 0x0
		private IEnumerable<TSource> first; //Field offset: 0x0
		public IEnumerable<TSource> <>3__first; //Field offset: 0x0
		private IEnumerable<TSource> second; //Field offset: 0x0
		public IEnumerable<TSource> <>3__second; //Field offset: 0x0
		private Set<TSource> <set>5__2; //Field offset: 0x0
		private IEnumerator<TSource> <>7__wrap2; //Field offset: 0x0

		private override TSource System.Collections.Generic.IEnumerator<TSource>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 40
		}

		[DebuggerHidden]
		public <UnionIterator>d__71`1(int <>1__state) { }

		private void <>m__Finally1() { }

		private void <>m__Finally2() { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<TSource> System.Collections.Generic.IEnumerable<TSource>.GetEnumerator() { }

		[DebuggerHidden]
		private override TSource System.Collections.Generic.IEnumerator<TSource>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	private abstract class Iterator : IEnumerable<TSource>, IEnumerable, IEnumerator<TSource>, IDisposable, IEnumerator
	{
		private int threadId; //Field offset: 0x0
		internal int state; //Field offset: 0x0
		internal TSource current; //Field offset: 0x0

		public override TSource Current
		{
			 get { } //Length: 12
		}

		private override object System.Collections.IEnumerator.Current
		{
			private get { } //Length: 44
		}

		public Iterator`1() { }

		public abstract Iterator<TSource> Clone() { }

		public override void Dispose() { }

		public override TSource get_Current() { }

		public override IEnumerator<TSource> GetEnumerator() { }

		public abstract bool MoveNext() { }

		public abstract IEnumerable<TResult> Select(Func<TSource, TResult> selector) { }

		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		private override object System.Collections.IEnumerator.get_Current() { }

		private override void System.Collections.IEnumerator.Reset() { }

		public abstract IEnumerable<TSource> Where(Func<TSource, Boolean> predicate) { }

	}

	private class WhereArrayIterator : Iterator<TSource>
	{
		private TSource[] source; //Field offset: 0x0
		private Func<TSource, Boolean> predicate; //Field offset: 0x0
		private int index; //Field offset: 0x0

		public WhereArrayIterator`1(TSource[] source, Func<TSource, Boolean> predicate) { }

		public virtual Iterator<TSource> Clone() { }

		public virtual bool MoveNext() { }

		public virtual IEnumerable<TResult> Select(Func<TSource, TResult> selector) { }

		public virtual IEnumerable<TSource> Where(Func<TSource, Boolean> predicate) { }

	}

	private class WhereEnumerableIterator : Iterator<TSource>
	{
		private IEnumerable<TSource> source; //Field offset: 0x0
		private Func<TSource, Boolean> predicate; //Field offset: 0x0
		private IEnumerator<TSource> enumerator; //Field offset: 0x0

		public WhereEnumerableIterator`1(IEnumerable<TSource> source, Func<TSource, Boolean> predicate) { }

		public virtual Iterator<TSource> Clone() { }

		public virtual void Dispose() { }

		public virtual bool MoveNext() { }

		public virtual IEnumerable<TResult> Select(Func<TSource, TResult> selector) { }

		public virtual IEnumerable<TSource> Where(Func<TSource, Boolean> predicate) { }

	}

	private class WhereListIterator : Iterator<TSource>
	{
		private List<TSource> source; //Field offset: 0x0
		private Func<TSource, Boolean> predicate; //Field offset: 0x0
		private Enumerator<TSource> enumerator; //Field offset: 0x0

		public WhereListIterator`1(List<TSource> source, Func<TSource, Boolean> predicate) { }

		public virtual Iterator<TSource> Clone() { }

		public virtual bool MoveNext() { }

		public virtual IEnumerable<TResult> Select(Func<TSource, TResult> selector) { }

		public virtual IEnumerable<TSource> Where(Func<TSource, Boolean> predicate) { }

	}

	private class WhereSelectArrayIterator : Iterator<TResult>
	{
		private TSource[] source; //Field offset: 0x0
		private Func<TSource, Boolean> predicate; //Field offset: 0x0
		private Func<TSource, TResult> selector; //Field offset: 0x0
		private int index; //Field offset: 0x0

		public WhereSelectArrayIterator`2(TSource[] source, Func<TSource, Boolean> predicate, Func<TSource, TResult> selector) { }

		public virtual Iterator<TResult> Clone() { }

		public virtual bool MoveNext() { }

		public virtual IEnumerable<TResult2> Select(Func<TResult, TResult2> selector) { }

		public virtual IEnumerable<TResult> Where(Func<TResult, Boolean> predicate) { }

	}

	private class WhereSelectEnumerableIterator : Iterator<TResult>
	{
		private IEnumerable<TSource> source; //Field offset: 0x0
		private Func<TSource, Boolean> predicate; //Field offset: 0x0
		private Func<TSource, TResult> selector; //Field offset: 0x0
		private IEnumerator<TSource> enumerator; //Field offset: 0x0

		public WhereSelectEnumerableIterator`2(IEnumerable<TSource> source, Func<TSource, Boolean> predicate, Func<TSource, TResult> selector) { }

		public virtual Iterator<TResult> Clone() { }

		public virtual void Dispose() { }

		public virtual bool MoveNext() { }

		public virtual IEnumerable<TResult2> Select(Func<TResult, TResult2> selector) { }

		public virtual IEnumerable<TResult> Where(Func<TResult, Boolean> predicate) { }

	}

	private class WhereSelectListIterator : Iterator<TResult>
	{
		private List<TSource> source; //Field offset: 0x0
		private Func<TSource, Boolean> predicate; //Field offset: 0x0
		private Func<TSource, TResult> selector; //Field offset: 0x0
		private Enumerator<TSource> enumerator; //Field offset: 0x0

		public WhereSelectListIterator`2(List<TSource> source, Func<TSource, Boolean> predicate, Func<TSource, TResult> selector) { }

		public virtual Iterator<TResult> Clone() { }

		public virtual bool MoveNext() { }

		public virtual IEnumerable<TResult2> Select(Func<TResult, TResult2> selector) { }

		public virtual IEnumerable<TResult> Where(Func<TResult, Boolean> predicate) { }

	}


	[Extension]
	public static bool All(IEnumerable<TSource> source, Func<TSource, Boolean> predicate) { }

	[Extension]
	public static bool Any(IEnumerable<TSource> source, Func<TSource, Boolean> predicate) { }

	[Extension]
	public static bool Any(IEnumerable<TSource> source) { }

	[Extension]
	public static double Average(IEnumerable<Int32> source) { }

	[Extension]
	public static float Average(IEnumerable<Single> source) { }

	[Extension]
	public static IEnumerable<TResult> Cast(IEnumerable source) { }

	[IteratorStateMachine(typeof(<CastIterator>d__99`1))]
	private static IEnumerable<TResult> CastIterator(IEnumerable source) { }

	private static Func<TSource, Boolean> CombinePredicates(Func<TSource, Boolean> predicate1, Func<TSource, Boolean> predicate2) { }

	private static Func<TSource, TResult> CombineSelectors(Func<TSource, TMiddle> selector1, Func<TMiddle, TResult> selector2) { }

	[Extension]
	public static IEnumerable<TSource> Concat(IEnumerable<TSource> first, IEnumerable<TSource> second) { }

	[IteratorStateMachine(typeof(<ConcatIterator>d__59`1))]
	private static IEnumerable<TSource> ConcatIterator(IEnumerable<TSource> first, IEnumerable<TSource> second) { }

	[Extension]
	public static bool Contains(IEnumerable<TSource> source, TSource value) { }

	[Extension]
	public static bool Contains(IEnumerable<TSource> source, TSource value, IEqualityComparer<TSource> comparer) { }

	[Extension]
	public static int Count(IEnumerable<TSource> source) { }

	[Extension]
	public static int Count(IEnumerable<TSource> source, Func<TSource, Boolean> predicate) { }

	[Extension]
	public static IEnumerable<TSource> DefaultIfEmpty(IEnumerable<TSource> source, TSource defaultValue) { }

	[Extension]
	public static IEnumerable<TSource> DefaultIfEmpty(IEnumerable<TSource> source) { }

	[IteratorStateMachine(typeof(<DefaultIfEmptyIterator>d__95`1))]
	private static IEnumerable<TSource> DefaultIfEmptyIterator(IEnumerable<TSource> source, TSource defaultValue) { }

	[Extension]
	public static IEnumerable<TSource> Distinct(IEnumerable<TSource> source) { }

	[IteratorStateMachine(typeof(<DistinctIterator>d__68`1))]
	private static IEnumerable<TSource> DistinctIterator(IEnumerable<TSource> source, IEqualityComparer<TSource> comparer) { }

	[Extension]
	public static TSource ElementAt(IEnumerable<TSource> source, int index) { }

	public static IEnumerable<TResult> Empty() { }

	[Extension]
	public static TSource First(IEnumerable<TSource> source, Func<TSource, Boolean> predicate) { }

	[Extension]
	public static TSource First(IEnumerable<TSource> source) { }

	[Extension]
	public static TSource FirstOrDefault(IEnumerable<TSource> source) { }

	[Extension]
	public static TSource FirstOrDefault(IEnumerable<TSource> source, Func<TSource, Boolean> predicate) { }

	[Extension]
	public static IEnumerable<IGrouping`2<TKey, TSource>> GroupBy(IEnumerable<TSource> source, Func<TSource, TKey> keySelector) { }

	[Extension]
	public static TSource Last(IEnumerable<TSource> source) { }

	[Extension]
	public static TSource LastOrDefault(IEnumerable<TSource> source) { }

	[Extension]
	public static TSource LastOrDefault(IEnumerable<TSource> source, Func<TSource, Boolean> predicate) { }

	[Extension]
	public static int Max(IEnumerable<Int32> source) { }

	[Extension]
	public static int Min(IEnumerable<Int32> source) { }

	[Extension]
	public static IEnumerable<TResult> OfType(IEnumerable source) { }

	[IteratorStateMachine(typeof(<OfTypeIterator>d__97`1))]
	private static IEnumerable<TResult> OfTypeIterator(IEnumerable source) { }

	[Extension]
	public static IOrderedEnumerable<TSource> OrderBy(IEnumerable<TSource> source, Func<TSource, TKey> keySelector) { }

	[Extension]
	public static IOrderedEnumerable<TSource> OrderBy(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) { }

	[Extension]
	public static IOrderedEnumerable<TSource> OrderByDescending(IEnumerable<TSource> source, Func<TSource, TKey> keySelector) { }

	public static IEnumerable<Int32> Range(int start, int count) { }

	[IteratorStateMachine(typeof(<RangeIterator>d__115))]
	private static IEnumerable<Int32> RangeIterator(int start, int count) { }

	[Extension]
	public static IEnumerable<TSource> Reverse(IEnumerable<TSource> source) { }

	[IteratorStateMachine(typeof(<ReverseIterator>d__79`1))]
	private static IEnumerable<TSource> ReverseIterator(IEnumerable<TSource> source) { }

	[Extension]
	public static IEnumerable<TResult> Select(IEnumerable<TSource> source, Func<TSource, TResult> selector) { }

	[Extension]
	public static IEnumerable<TResult> Select(IEnumerable<TSource> source, Func<TSource, Int32, TResult> selector) { }

	[IteratorStateMachine(typeof(<SelectIterator>d__5`2))]
	private static IEnumerable<TResult> SelectIterator(IEnumerable<TSource> source, Func<TSource, Int32, TResult> selector) { }

	[Extension]
	public static IEnumerable<TResult> SelectMany(IEnumerable<TSource> source, Func<TSource, IEnumerable`1<TResult>> selector) { }

	[IteratorStateMachine(typeof(<SelectManyIterator>d__17`2))]
	private static IEnumerable<TResult> SelectManyIterator(IEnumerable<TSource> source, Func<TSource, IEnumerable`1<TResult>> selector) { }

	[Extension]
	public static bool SequenceEqual(IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer) { }

	[Extension]
	public static bool SequenceEqual(IEnumerable<TSource> first, IEnumerable<TSource> second) { }

	[Extension]
	public static TSource Single(IEnumerable<TSource> source, Func<TSource, Boolean> predicate) { }

	[Extension]
	public static TSource Single(IEnumerable<TSource> source) { }

	[Extension]
	public static TSource SingleOrDefault(IEnumerable<TSource> source) { }

	[Extension]
	public static TSource SingleOrDefault(IEnumerable<TSource> source, Func<TSource, Boolean> predicate) { }

	[Extension]
	public static IEnumerable<TSource> Skip(IEnumerable<TSource> source, int count) { }

	[IteratorStateMachine(typeof(<SkipIterator>d__31`1))]
	private static IEnumerable<TSource> SkipIterator(IEnumerable<TSource> source, int count) { }

	[Extension]
	public static IEnumerable<TSource> SkipLast(IEnumerable<TSource> source, int count) { }

	[IteratorStateMachine(typeof(<SkipLastIterator>d__216`1))]
	private static IEnumerable<TSource> SkipLastIterator(IEnumerable<TSource> source, int count) { }

	[Extension]
	public static int Sum(IEnumerable<TSource> source, Func<TSource, Int32> selector) { }

	[Extension]
	public static int Sum(IEnumerable<Int32> source) { }

	[Extension]
	public static IEnumerable<TSource> Take(IEnumerable<TSource> source, int count) { }

	[IteratorStateMachine(typeof(<TakeIterator>d__25`1))]
	private static IEnumerable<TSource> TakeIterator(IEnumerable<TSource> source, int count) { }

	[Extension]
	public static IOrderedEnumerable<TSource> ThenBy(IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector) { }

	[Extension]
	public static IOrderedEnumerable<TSource> ThenByDescending(IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector) { }

	[Extension]
	public static TSource[] ToArray(IEnumerable<TSource> source) { }

	[Extension]
	public static Dictionary<TKey, TElement> ToDictionary(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector) { }

	[Extension]
	public static Dictionary<TKey, TSource> ToDictionary(IEnumerable<TSource> source, Func<TSource, TKey> keySelector) { }

	[Extension]
	public static Dictionary<TKey, TElement> ToDictionary(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer) { }

	[Extension]
	public static HashSet<TSource> ToHashSet(IEnumerable<TSource> source, IEqualityComparer<TSource> comparer) { }

	[Extension]
	public static HashSet<TSource> ToHashSet(IEnumerable<TSource> source) { }

	[Extension]
	public static List<TSource> ToList(IEnumerable<TSource> source) { }

	[Extension]
	public static IEnumerable<TSource> Union(IEnumerable<TSource> first, IEnumerable<TSource> second) { }

	[IteratorStateMachine(typeof(<UnionIterator>d__71`1))]
	private static IEnumerable<TSource> UnionIterator(IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer) { }

	[Extension]
	public static IEnumerable<TSource> Where(IEnumerable<TSource> source, Func<TSource, Boolean> predicate) { }

}

