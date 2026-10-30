namespace Spine;

public class AnimationStateData
{
	internal struct AnimationPair
	{
		public readonly Animation a1; //Field offset: 0x0
		public readonly Animation a2; //Field offset: 0x8

		public AnimationPair(Animation a1, Animation a2) { }

		public virtual string ToString() { }

	}

	internal class AnimationPairComparer : IEqualityComparer<AnimationPair>
	{
		public static readonly AnimationPairComparer Instance; //Field offset: 0x0

		private static AnimationPairComparer() { }

		public AnimationPairComparer() { }

		private override bool System.Collections.Generic.IEqualityComparer<Spine.AnimationStateData.AnimationPair>.Equals(AnimationPair x, AnimationPair y) { }

		private override int System.Collections.Generic.IEqualityComparer<Spine.AnimationStateData.AnimationPair>.GetHashCode(AnimationPair obj) { }

	}

	internal SkeletonData skeletonData; //Field offset: 0x10
	private readonly Dictionary<AnimationPair, Single> animationToMixTime; //Field offset: 0x18
	internal float defaultMix; //Field offset: 0x20

	public float DefaultMix
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public SkeletonData SkeletonData
	{
		 get { } //Length: 8
	}

	public AnimationStateData(SkeletonData skeletonData) { }

	public float get_DefaultMix() { }

	public SkeletonData get_SkeletonData() { }

	public float GetMix(Animation from, Animation to) { }

	public void set_DefaultMix(float value) { }

	public void SetMix(string fromName, string toName, float duration) { }

	public void SetMix(Animation from, Animation to, float duration) { }

}

