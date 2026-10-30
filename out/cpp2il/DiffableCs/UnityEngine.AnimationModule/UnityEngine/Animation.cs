namespace UnityEngine;

[DefaultMember("Item")]
[NativeHeader("Modules/Animation/Animation.h")]
public sealed class Animation : Behaviour, IEnumerable
{
	private sealed class Enumerator : IEnumerator
	{
		private Animation m_Outer; //Field offset: 0x10
		private int m_CurrentIndex; //Field offset: 0x18

		public override object Current
		{
			 get { } //Length: 76
		}

		internal Enumerator(Animation outer) { }

		public override object get_Current() { }

		public override bool MoveNext() { }

		public override void Reset() { }

	}


	public Animation() { }

	public override IEnumerator GetEnumerator() { }

	[FreeFunction("AnimationBindings::GetStateAtIndex", HasExplicitThis = True, ThrowsException = True)]
	internal AnimationState GetStateAtIndex(int index) { }

	[NativeName("GetAnimationStateCount")]
	internal int GetStateCount() { }

	[ExcludeFromDocs]
	public bool Play() { }

	public bool Play(PlayMode mode) { }

	[ExcludeFromDocs]
	public bool Play(string animation) { }

	public bool Play(string animation, PlayMode mode) { }

	[NativeName("Play")]
	private bool PlayDefaultAnimation(PlayMode mode) { }

}

