namespace Spine;

internal class EventQueue
{
	private struct EventQueueEntry
	{
		public EventType type; //Field offset: 0x0
		public TrackEntry entry; //Field offset: 0x8
		public Event e; //Field offset: 0x10

		public EventQueueEntry(EventType eventType, TrackEntry trackEntry, Event e = null) { }

	}

	private enum EventType
	{
		Start = 0,
		Interrupt = 1,
		End = 2,
		Dispose = 3,
		Complete = 4,
		Event = 5,
	}

	private readonly List<EventQueueEntry> eventQueueEntries; //Field offset: 0x10
	internal bool drainDisabled; //Field offset: 0x18
	private readonly AnimationState state; //Field offset: 0x20
	private readonly Pool<TrackEntry> trackEntryPool; //Field offset: 0x28
	[CompilerGenerated]
	private Action AnimationsChanged; //Field offset: 0x30

	internal event Action AnimationsChanged
	{
		[CompilerGenerated]
		internal add { } //Length: 156
		[CompilerGenerated]
		internal remove { } //Length: 156
	}

	internal EventQueue(AnimationState state, Action HandleAnimationsChanged, Pool<TrackEntry> trackEntryPool) { }

	[CompilerGenerated]
	internal void add_AnimationsChanged(Action value) { }

	internal void Clear() { }

	internal void Complete(TrackEntry entry) { }

	internal void Dispose(TrackEntry entry) { }

	internal void Drain() { }

	internal void End(TrackEntry entry) { }

	internal void Event(TrackEntry entry, Event e) { }

	internal void Interrupt(TrackEntry entry) { }

	[CompilerGenerated]
	internal void remove_AnimationsChanged(Action value) { }

	internal void Start(TrackEntry entry) { }

}

