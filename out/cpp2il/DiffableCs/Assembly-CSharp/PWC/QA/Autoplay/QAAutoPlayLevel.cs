namespace PWC.QA.Autoplay;

public class QAAutoPlayLevel
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<Application> <>9__10_1; //Field offset: 0x8
		public static Func<ContactsThumb, Boolean> <>9__13_1; //Field offset: 0x10
		public static Predicate<LevelAvatarRestAreaBase> <>9__17_0; //Field offset: 0x18
		public static Predicate<ILevelConsumer> <>9__18_0; //Field offset: 0x20
		public static Func<HashSet`1<ILevelConsumer>, IEnumerable`1<ILevelConsumer>> <>9__23_0; //Field offset: 0x28
		public static Predicate<MonoBehaviour> <>9__24_0; //Field offset: 0x30
		public static Func<ILevelConsumer, Boolean> <>9__24_2; //Field offset: 0x38
		public static Predicate<LevelItem> <>9__32_0; //Field offset: 0x40
		public static Predicate<MonoBehaviour> <>9__33_0; //Field offset: 0x48
		public static Func<MonoBehaviour, LevelCharacter> <>9__33_1; //Field offset: 0x50
		public static Predicate<LevelItem> <>9__33_2; //Field offset: 0x58
		public static Func<LevelItem, Boolean> <>9__33_3; //Field offset: 0x60
		public static Func<MonoBehaviour, LevelItem> <>9__37_1; //Field offset: 0x68
		public static Func<MonoBehaviour, LevelDropArea> <>9__38_1; //Field offset: 0x70
		public static Predicate<MonoBehaviour> <>9__48_0; //Field offset: 0x78
		public static Predicate<MonoBehaviour> <>9__49_0; //Field offset: 0x80
		public static Func<MonoBehaviour, GameObject> <>9__49_1; //Field offset: 0x88
		public static Func<LevelContextualAnimationItem, Boolean> <>9__50_0; //Field offset: 0x90

		private static <>c() { }

		public <>c() { }

		internal bool <ClickOnAllVisibleNonUIObjects>b__49_0(MonoBehaviour candidate) { }

		internal GameObject <ClickOnAllVisibleNonUIObjects>b__49_1(MonoBehaviour x) { }

		internal bool <ClickOnRandomClickableNonUIObject>b__48_0(MonoBehaviour x) { }

		internal bool <ClickPhoneContactsButton>b__10_1(Application x) { }

		internal bool <DragCharacterToClosestRestArea>b__17_0(LevelAvatarRestAreaBase x) { }

		internal bool <DragRandomCharacterFromPhone>b__13_1(ContactsThumb x) { }

		internal bool <DragVisibleLevelItemsToRandomConsumers>b__24_0(MonoBehaviour x) { }

		internal bool <DragVisibleLevelItemsToRandomConsumers>b__24_2(ILevelConsumer x) { }

		internal IEnumerable<ILevelConsumer> <DragVisibleLevelItemsToRandomDragActionConsumers>b__23_0(HashSet<ILevelConsumer> x) { }

		internal bool <DragVisibleLevelItemsToRandomDropConsumers>b__18_0(ILevelConsumer consumer) { }

		internal bool <GetAvailableCAAnimationUIItems>b__50_0(LevelContextualAnimationItem x) { }

		internal LevelDropArea <GetVisibleDropAreas>b__38_1(MonoBehaviour x) { }

		internal LevelItem <GetVisibleLevelItems>b__37_1(MonoBehaviour x) { }

		internal bool <PutItemsInCharactersHandsAndPlayCAAnimations>b__33_0(MonoBehaviour x) { }

		internal LevelCharacter <PutItemsInCharactersHandsAndPlayCAAnimations>b__33_1(MonoBehaviour x) { }

		internal bool <PutItemsInCharactersHandsAndPlayCAAnimations>b__33_2(LevelItem x) { }

		internal bool <PutItemsInCharactersHandsAndPlayCAAnimations>b__33_3(LevelItem x) { }

		internal bool <PutRandomItemWithCAInCharacterHand>b__32_0(LevelItem x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__31
	{
		public static readonly <>c__31<T> <>9; //Field offset: 0x0
		public static Func<T, Boolean> <>9__31_0; //Field offset: 0x0

		private static <>c__31`1() { }

		public <>c__31`1() { }

		internal bool <GetClosestVisibleAndAvailableObjects>b__31_0(T x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass10_0
	{
		public Application[] applicationsButtons; //Field offset: 0x10

		public <>c__DisplayClass10_0() { }

		internal void <ClickPhoneContactsButton>b__0(Application[] x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass12_0
	{
		public ContactsThumb[] contactsButtons; //Field offset: 0x10
		public int characterId; //Field offset: 0x18

		public <>c__DisplayClass12_0() { }

		internal void <ClickOnRandomCharacterContactButton>b__0(ContactsThumb[] x) { }

		internal bool <ClickOnRandomCharacterContactButton>b__1(LevelCharacter x) { }

		internal bool <ClickOnRandomCharacterContactButton>b__2(LevelCharacter x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass13_0
	{
		public ContactsThumb[] contactsButtons; //Field offset: 0x10
		public int characterId; //Field offset: 0x18

		public <>c__DisplayClass13_0() { }

		internal void <DragRandomCharacterFromPhone>b__0(ContactsThumb[] x) { }

		internal bool <DragRandomCharacterFromPhone>b__2(LevelCharacter x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass23_0
	{
		public Dictionary<MonoBehaviour, HashSet`1<ILevelConsumer>> usedConsumersForLevelItems; //Field offset: 0x10
		public HashSet<ILevelConsumer> allUsedConsumers; //Field offset: 0x18
		public Func<ILevelConsumer, Boolean> <>9__3; //Field offset: 0x20

		public <>c__DisplayClass23_0() { }

		internal bool <DragVisibleLevelItemsToRandomDragActionConsumers>b__1(MonoBehaviour x) { }

		internal bool <DragVisibleLevelItemsToRandomDragActionConsumers>b__3(ILevelConsumer x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass23_1
	{
		public ILevelDragActionItemHandler dragItemHadnler; //Field offset: 0x10
		public HashSet<ILevelConsumer> usedConsumers; //Field offset: 0x18

		public <>c__DisplayClass23_1() { }

		internal bool <DragVisibleLevelItemsToRandomDragActionConsumers>b__2(ILevelConsumer x) { }

		internal bool <DragVisibleLevelItemsToRandomDragActionConsumers>b__4(ILevelConsumer x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass26_0
	{
		public Predicate<MonoBehaviour> condition; //Field offset: 0x10
		public LevelItem levelItem; //Field offset: 0x18

		public <>c__DisplayClass26_0() { }

		internal bool <DragLevelItemToRandomConsumer>b__0(MonoBehaviour x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass27_0
	{
		public Predicate<ILevelConsumer> condition; //Field offset: 0x10

		public <>c__DisplayClass27_0() { }

		internal bool <GetVisibleConsumers>b__0(MonoBehaviour x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass28_0
	{
		public LevelCharacter character; //Field offset: 0x10

		public <>c__DisplayClass28_0() { }

		internal bool <DragCharacterToClosestDropArea>b__0(LevelDropArea x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass31_0
	{
		public Predicate<T> condition; //Field offset: 0x0

		public <>c__DisplayClass31_0`1() { }

		internal bool <GetClosestVisibleAndAvailableObjects>b__1(T x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass37_0
	{
		public Predicate<LevelItem> condition; //Field offset: 0x10

		public <>c__DisplayClass37_0() { }

		internal bool <GetVisibleLevelItems>b__0(MonoBehaviour x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass38_0
	{
		public Predicate<LevelDropArea> condition; //Field offset: 0x10

		public <>c__DisplayClass38_0() { }

		internal bool <GetVisibleDropAreas>b__0(MonoBehaviour x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass47_0
	{
		public LevelItem levelItem; //Field offset: 0x10
		public bool isEndDrop; //Field offset: 0x18

		public <>c__DisplayClass47_0() { }

		internal bool <DragLevelItemTo>b__2() { }

		internal void <DragLevelItemTo>g__OnEndDrop|0(LevelAvatarRestAreaBase area) { }

		internal void <DragLevelItemTo>g__OnEndLand|1(LevelDropArea dropArea) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public LevelCharacter character; //Field offset: 0x10
		public QAAutoPlayLevel <>4__this; //Field offset: 0x18

		public <>c__DisplayClass5_0() { }

		internal void <RunGeneralCoroutine>b__0(LevelCharacter x) { }

		internal void <RunGeneralCoroutine>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass51_0
	{
		public Bounds cameraBounds; //Field offset: 0x0
		public Vector2 position; //Field offset: 0x0

		public <>c__DisplayClass51_0`1() { }

		internal bool <GetItemsInCameraBoundsAndSortedByDistance>b__0(T item) { }

		internal float <GetItemsInCameraBoundsAndSortedByDistance>b__1(T item) { }

	}

	[CompilerGenerated]
	private sealed class <Click>d__52 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public MonoBehaviour monoBehaviour; //Field offset: 0x20

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
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
		public <Click>d__52(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <Click>d__53 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public GameObject gameObject; //Field offset: 0x20

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
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
		public <Click>d__53(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <ClickOnAllVisibleNonUIObjects>d__49 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public QAAutoPlayLevel <>4__this; //Field offset: 0x20
		private GameObject[] <>7__wrap1; //Field offset: 0x28
		private int <>7__wrap2; //Field offset: 0x30

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
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
		public <ClickOnAllVisibleNonUIObjects>d__49(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <ClickOnLevelChanger>d__20 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public QAAutoPlayLevel <>4__this; //Field offset: 0x20

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
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
		public <ClickOnLevelChanger>d__20(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <ClickOnRandomCAAnimationUIItem>d__16 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public QAAutoPlayLevel <>4__this; //Field offset: 0x20
		private LevelContextualAnimationMenu <menu>5__2; //Field offset: 0x28
		private float <safeTimer>5__3; //Field offset: 0x30
		private LevelContextualAnimationItem[] <animationItems>5__4; //Field offset: 0x38
		private float <timeToWait>5__5; //Field offset: 0x40

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
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
		public <ClickOnRandomCAAnimationUIItem>d__16(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <ClickOnRandomCharacterContactButton>d__12 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public QAAutoPlayLevel <>4__this; //Field offset: 0x20
		private <>c__DisplayClass12_0 <>8__1; //Field offset: 0x28
		public Action<LevelCharacter> onFinish; //Field offset: 0x30
		private ContactsThumb <button>5__2; //Field offset: 0x38

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
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
		public <ClickOnRandomCharacterContactButton>d__12(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <ClickOnRandomClickableNonUIObject>d__48 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public QAAutoPlayLevel <>4__this; //Field offset: 0x20

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
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
		public <ClickOnRandomClickableNonUIObject>d__48(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <ClickPhoneButton>d__9 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public QAAutoPlayLevel <>4__this; //Field offset: 0x20

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
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
		public <ClickPhoneButton>d__9(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <ClickPhoneContactsButton>d__10 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		private <>c__DisplayClass10_0 <>8__1; //Field offset: 0x20
		public QAAutoPlayLevel <>4__this; //Field offset: 0x28

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
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
		public <ClickPhoneContactsButton>d__10(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <DragAllSavedLevelItemsToTheirSavedPositions>d__40 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public QAAutoPlayLevel <>4__this; //Field offset: 0x20

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
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
		public <DragAllSavedLevelItemsToTheirSavedPositions>d__40(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <DragAllVisibleLevelItemsToVisibleDropAreas>d__42 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public QAAutoPlayLevel <>4__this; //Field offset: 0x20
		private LevelItem[] <levelItems>5__2; //Field offset: 0x28
		private LevelDropArea[] <dropAreas>5__3; //Field offset: 0x30
		private int <i>5__4; //Field offset: 0x38

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
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
		public <DragAllVisibleLevelItemsToVisibleDropAreas>d__42(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <DragCharacterToClosestDropArea>d__28 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelCharacter character; //Field offset: 0x20
		public QAAutoPlayLevel <>4__this; //Field offset: 0x28

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
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
		public <DragCharacterToClosestDropArea>d__28(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <DragCharacterToClosestRestArea>d__17 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelCharacter character; //Field offset: 0x20
		public QAAutoPlayLevel <>4__this; //Field offset: 0x28

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
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
		public <DragCharacterToClosestRestArea>d__17(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <DragCharacterToSitArea>d__44 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelCharacter character; //Field offset: 0x20
		public LevelSitArea sitArea; //Field offset: 0x28
		public QAAutoPlayLevel <>4__this; //Field offset: 0x30

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
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
		public <DragCharacterToSitArea>d__44(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <DragCharacterToSleepArea>d__46 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelSleepArea sleepArea; //Field offset: 0x20
		public QAAutoPlayLevel <>4__this; //Field offset: 0x28
		public LevelCharacter character; //Field offset: 0x30

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
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
		public <DragCharacterToSleepArea>d__46(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <DragLevelItemTo>d__47 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelItem levelItem; //Field offset: 0x20
		public QAAutoPlayLevel <>4__this; //Field offset: 0x28
		public Vector2 position; //Field offset: 0x30
		public float durationInTarget; //Field offset: 0x38
		private <>c__DisplayClass47_0 <>8__1; //Field offset: 0x40

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
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
		public <DragLevelItemTo>d__47(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <DragLevelItemToDropArea>d__45 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelDropArea dropArea; //Field offset: 0x20
		public QAAutoPlayLevel <>4__this; //Field offset: 0x28
		public LevelCharacter character; //Field offset: 0x30

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
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
		public <DragLevelItemToDropArea>d__45(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <DragLevelItemToRandomConsumer>d__26 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Predicate<MonoBehaviour> condition; //Field offset: 0x20
		public LevelItem levelItem; //Field offset: 0x28
		public QAAutoPlayLevel <>4__this; //Field offset: 0x30

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
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
		public <DragLevelItemToRandomConsumer>d__26(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <DragRandomCharacterFromPhone>d__13 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public QAAutoPlayLevel <>4__this; //Field offset: 0x20
		private <>c__DisplayClass13_0 <>8__1; //Field offset: 0x28
		public Action<LevelCharacter> onFinish; //Field offset: 0x30
		private ContactsThumb <button>5__2; //Field offset: 0x38

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
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
		public <DragRandomCharacterFromPhone>d__13(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <DragTo>d__54 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public MonoBehaviour monoBehaviour; //Field offset: 0x20
		public Vector2 destination; //Field offset: 0x28
		public float durationInTarget; //Field offset: 0x30

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
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
		public <DragTo>d__54(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <DragVisibleLevelItemsToRandomConsumers>d__24 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public QAAutoPlayLevel <>4__this; //Field offset: 0x20
		public Predicate<ILevelConsumer> consumerCondition; //Field offset: 0x28
		public int maxLevelItems; //Field offset: 0x30
		private List<LevelItem> <levelItems>5__2; //Field offset: 0x38
		private List<ILevelConsumer> <consumers>5__3; //Field offset: 0x40
		private int <counter>5__4; //Field offset: 0x48
		private Dictionary<ILevelConsumer, Int32> <usedConsumersCounters>5__5; //Field offset: 0x50
		private ILevelConsumer <consumer>5__6; //Field offset: 0x58
		private int <i>5__7; //Field offset: 0x60

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
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
		public <DragVisibleLevelItemsToRandomConsumers>d__24(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <DragVisibleLevelItemsToRandomDragActionConsumers_Multiple>d__22 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public QAAutoPlayLevel <>4__this; //Field offset: 0x20
		public int maxLevelItems; //Field offset: 0x28
		public int count; //Field offset: 0x2C
		private Dictionary<MonoBehaviour, HashSet`1<ILevelConsumer>> <usedConsumersForItems>5__2; //Field offset: 0x30
		private int <i>5__3; //Field offset: 0x38
		private Dictionary<MonoBehaviour, HashSet`1<ILevelConsumer>> <before>5__4; //Field offset: 0x40

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
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
		public <DragVisibleLevelItemsToRandomDragActionConsumers_Multiple>d__22(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <DragVisibleLevelItemsToRandomDragActionConsumers>d__23 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Dictionary<MonoBehaviour, HashSet`1<ILevelConsumer>> usedConsumersForLevelItems; //Field offset: 0x20
		public QAAutoPlayLevel <>4__this; //Field offset: 0x28
		private <>c__DisplayClass23_0 <>8__1; //Field offset: 0x30
		public int maxLevelItems; //Field offset: 0x38
		private List<LevelItem> <levelItems>5__2; //Field offset: 0x40
		private int <counter>5__3; //Field offset: 0x48
		private Dictionary<LevelItem, ILevelConsumer> <itemsOnConsumerTries>5__4; //Field offset: 0x50

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
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
		public <DragVisibleLevelItemsToRandomDragActionConsumers>d__23(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <DragVisibleLevelItemsToRandomDropConsumers>d__18 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public QAAutoPlayLevel <>4__this; //Field offset: 0x20
		public int maxLevelItems; //Field offset: 0x28

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
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
		public <DragVisibleLevelItemsToRandomDropConsumers>d__18(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <DropVisibleLevelItemsFromTopToBottom>d__41 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public QAAutoPlayLevel <>4__this; //Field offset: 0x20
		public int maxItems; //Field offset: 0x28
		private Bounds <cameraBounds>5__2; //Field offset: 0x2C
		private int <m>5__3; //Field offset: 0x44

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
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
		public <DropVisibleLevelItemsFromTopToBottom>d__41(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <EnsurePhoneContactsPageOpen>d__11 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public QAAutoPlayLevel <>4__this; //Field offset: 0x20
		private ContactsContent <contactsContent>5__2; //Field offset: 0x28

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
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
		public <EnsurePhoneContactsPageOpen>d__11(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <FocusOnClickOn>d__21 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public GameObject gameObject; //Field offset: 0x20
		public QAAutoPlayLevel <>4__this; //Field offset: 0x28

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
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
		public <FocusOnClickOn>d__21(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <MoveCamera>d__30 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public float amount; //Field offset: 0x20
		public Action onLoopAction; //Field offset: 0x28

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
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
		public <MoveCamera>d__30(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <MoveCameraToTheRight>d__29 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
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
		public <MoveCameraToTheRight>d__29(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <PutItemInCharacterHand>d__35 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelCharacter character; //Field offset: 0x20
		public LevelItem levelItem; //Field offset: 0x28
		public QAAutoPlayLevel <>4__this; //Field offset: 0x30

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
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
		public <PutItemInCharacterHand>d__35(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <PutItemsInCharactersHandsAndPlayCAAnimations>d__33 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public QAAutoPlayLevel <>4__this; //Field offset: 0x20
		private List<LevelCharacter> <characters>5__2; //Field offset: 0x28
		private List<LevelItem> <items>5__3; //Field offset: 0x30

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
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
		public <PutItemsInCharactersHandsAndPlayCAAnimations>d__33(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <PutRandomItemInCharacterHand>d__34 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelCharacter character; //Field offset: 0x20
		public QAAutoPlayLevel <>4__this; //Field offset: 0x28
		public Predicate<LevelItem> condition; //Field offset: 0x30

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
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
		public <PutRandomItemInCharacterHand>d__34(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <PutRandomItemWithCAInCharacterHand>d__32 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelCharacter character; //Field offset: 0x20
		public QAAutoPlayLevel <>4__this; //Field offset: 0x28

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
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
		public <PutRandomItemWithCAInCharacterHand>d__32(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <RunGeneralCoroutine>d__5 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public QAAutoPlayLevel <>4__this; //Field offset: 0x20
		private <>c__DisplayClass5_0 <>8__1; //Field offset: 0x28
		private int <i>5__2; //Field offset: 0x30

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
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
		public <RunGeneralCoroutine>d__5(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <WaitFor>d__58 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Func<Boolean> condition; //Field offset: 0x20
		public string stackTrace; //Field offset: 0x28

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
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
		public <WaitFor>d__58(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	private readonly QAAutoPlayManager _manager; //Field offset: 0x10
	private int _runCounter; //Field offset: 0x18
	private int _cameraLoopCounter; //Field offset: 0x1C
	private readonly Dictionary<LevelItem, Vector2> _savedLevelItemsPositions; //Field offset: 0x20
	private readonly Dictionary<ILevelConsumer, MonoBehaviour> _consumersControllers; //Field offset: 0x28

	public QAAutoPlayLevel(QAAutoPlayManager manager) { }

	[CompilerGenerated]
	private bool <DragVisibleLevelItemsToRandomConsumers>b__24_1(ILevelConsumer x) { }

	[IteratorStateMachine(typeof(<Click>d__53))]
	private IEnumerator Click(GameObject gameObject) { }

	[IteratorStateMachine(typeof(<Click>d__52))]
	private IEnumerator Click(MonoBehaviour monoBehaviour) { }

	[IteratorStateMachine(typeof(<ClickOnAllVisibleNonUIObjects>d__49))]
	private IEnumerator ClickOnAllVisibleNonUIObjects() { }

	private void ClickOnBackButton() { }

	[IteratorStateMachine(typeof(<ClickOnLevelChanger>d__20))]
	private IEnumerator ClickOnLevelChanger() { }

	[IteratorStateMachine(typeof(<ClickOnRandomCAAnimationUIItem>d__16))]
	private IEnumerator ClickOnRandomCAAnimationUIItem() { }

	[IteratorStateMachine(typeof(<ClickOnRandomCharacterContactButton>d__12))]
	private IEnumerator ClickOnRandomCharacterContactButton(Action<LevelCharacter> onFinish) { }

	[IteratorStateMachine(typeof(<ClickOnRandomClickableNonUIObject>d__48))]
	private IEnumerator ClickOnRandomClickableNonUIObject() { }

	[IteratorStateMachine(typeof(<ClickPhoneButton>d__9))]
	private IEnumerator ClickPhoneButton() { }

	[IteratorStateMachine(typeof(<ClickPhoneContactsButton>d__10))]
	private IEnumerator ClickPhoneContactsButton() { }

	[IteratorStateMachine(typeof(<DragAllSavedLevelItemsToTheirSavedPositions>d__40))]
	private IEnumerator DragAllSavedLevelItemsToTheirSavedPositions() { }

	[IteratorStateMachine(typeof(<DragAllVisibleLevelItemsToVisibleDropAreas>d__42))]
	private IEnumerator DragAllVisibleLevelItemsToVisibleDropAreas() { }

	[IteratorStateMachine(typeof(<DragCharacterToClosestDropArea>d__28))]
	private IEnumerator DragCharacterToClosestDropArea(LevelCharacter character) { }

	[IteratorStateMachine(typeof(<DragCharacterToClosestRestArea>d__17))]
	private IEnumerator DragCharacterToClosestRestArea(LevelCharacter character) { }

	[IteratorStateMachine(typeof(<DragCharacterToSitArea>d__44))]
	private IEnumerator DragCharacterToSitArea(LevelCharacter character, LevelSitArea sitArea) { }

	[IteratorStateMachine(typeof(<DragCharacterToSleepArea>d__46))]
	private IEnumerator DragCharacterToSleepArea(LevelCharacter character, LevelSleepArea sleepArea) { }

	[IteratorStateMachine(typeof(<DragLevelItemTo>d__47))]
	private IEnumerator DragLevelItemTo(LevelItem levelItem, Vector2 position, float durationInTarget = 0) { }

	[IteratorStateMachine(typeof(<DragLevelItemToDropArea>d__45))]
	private IEnumerator DragLevelItemToDropArea(LevelCharacter character, LevelDropArea dropArea) { }

	[IteratorStateMachine(typeof(<DragLevelItemToRandomConsumer>d__26))]
	private IEnumerator DragLevelItemToRandomConsumer(LevelItem levelItem, Predicate<MonoBehaviour> condition = null) { }

	[IteratorStateMachine(typeof(<DragRandomCharacterFromPhone>d__13))]
	private IEnumerator DragRandomCharacterFromPhone(Action<LevelCharacter> onFinish) { }

	[IteratorStateMachine(typeof(<DragTo>d__54))]
	private IEnumerator DragTo(MonoBehaviour monoBehaviour, Vector2 destination, float durationInTarget = 0) { }

	[IteratorStateMachine(typeof(<DragVisibleLevelItemsToRandomConsumers>d__24))]
	private IEnumerator DragVisibleLevelItemsToRandomConsumers(int maxLevelItems = 5, Predicate<ILevelConsumer> consumerCondition = null) { }

	[IteratorStateMachine(typeof(<DragVisibleLevelItemsToRandomDragActionConsumers>d__23))]
	private IEnumerator DragVisibleLevelItemsToRandomDragActionConsumers(int maxLevelItems = 5, Dictionary<MonoBehaviour, HashSet`1<ILevelConsumer>> usedConsumersForLevelItems = null) { }

	[IteratorStateMachine(typeof(<DragVisibleLevelItemsToRandomDragActionConsumers_Multiple>d__22))]
	private IEnumerator DragVisibleLevelItemsToRandomDragActionConsumers_Multiple(int count = 5, int maxLevelItems = 5) { }

	[IteratorStateMachine(typeof(<DragVisibleLevelItemsToRandomDropConsumers>d__18))]
	private IEnumerator DragVisibleLevelItemsToRandomDropConsumers(int maxLevelItems = 5) { }

	[IteratorStateMachine(typeof(<DropVisibleLevelItemsFromTopToBottom>d__41))]
	private IEnumerator DropVisibleLevelItemsFromTopToBottom(int maxItems = 2147483647) { }

	private void EnsureClearScreen() { }

	[IteratorStateMachine(typeof(<EnsurePhoneContactsPageOpen>d__11))]
	private IEnumerator EnsurePhoneContactsPageOpen() { }

	private T FindObject() { }

	private T[] FindObjects() { }

	[IteratorStateMachine(typeof(<FocusOnClickOn>d__21))]
	private IEnumerator FocusOnClickOn(GameObject gameObject) { }

	private LevelContextualAnimationItem[] GetAvailableCAAnimationUIItems() { }

	private T GetClosestVisibleAndAvailableObjects(Vector2 position, Predicate<T> condition = null) { }

	private T[] GetItemsInCameraBoundsAndSortedByDistance(IList<T> collection, Vector2 position) { }

	private T GetRandomItem(IList<T> colleciton) { }

	private LevelItem GetRandomVisibleLevelItem(Predicate<LevelItem> condition = null) { }

	private ILevelConsumer[] GetVisibleConsumers(Predicate<ILevelConsumer> condition = null) { }

	private LevelDropArea[] GetVisibleDropAreas(Predicate<LevelDropArea> condition = null) { }

	private LevelItem[] GetVisibleLevelItems(Predicate<LevelItem> condition = null) { }

	private MonoBehaviour[] GetVisibleObjects(Predicate<MonoBehaviour> condition = null) { }

	private bool IsObjectActive() { }

	private bool IsObjectAndImmediateChildrenActive() { }

	private void MapConsumersToControllers() { }

	[IteratorStateMachine(typeof(<MoveCamera>d__30))]
	private IEnumerator MoveCamera(float amount, Action onLoopAction = null) { }

	[IteratorStateMachine(typeof(<MoveCameraToTheRight>d__29))]
	private IEnumerator MoveCameraToTheRight() { }

	[IteratorStateMachine(typeof(<PutItemInCharacterHand>d__35))]
	private IEnumerator PutItemInCharacterHand(LevelCharacter character, LevelItem levelItem) { }

	[IteratorStateMachine(typeof(<PutItemsInCharactersHandsAndPlayCAAnimations>d__33))]
	private IEnumerator PutItemsInCharactersHandsAndPlayCAAnimations() { }

	[IteratorStateMachine(typeof(<PutRandomItemInCharacterHand>d__34))]
	private IEnumerator PutRandomItemInCharacterHand(LevelCharacter character, Predicate<LevelItem> condition = null) { }

	[IteratorStateMachine(typeof(<PutRandomItemWithCAInCharacterHand>d__32))]
	private IEnumerator PutRandomItemWithCAInCharacterHand(LevelCharacter character) { }

	public void RunGeneral() { }

	[IteratorStateMachine(typeof(<RunGeneralCoroutine>d__5))]
	private IEnumerator RunGeneralCoroutine() { }

	private void SaveCurrentVisibleItemsPositions() { }

	private static bool ShouldConsiderObject(GameObject gameObject) { }

	private static bool ShouldConsiderObject(MonoBehaviour monoBehaviour) { }

	[IteratorStateMachine(typeof(<WaitFor>d__58))]
	public static IEnumerator WaitFor(Func<Boolean> condition, string stackTrace) { }

}

