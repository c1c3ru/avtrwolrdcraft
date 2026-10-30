namespace Game.Level.ContextualAnimation;

public class LevelCABraceletHipHopDanceClothingSpineSkinHandler : LevelCABraceletsRemovalOnlySpineSkinHandler
{
	private ParticleSystem _particlesPrefabHipHop; //Field offset: 0xA0
	private ParticleSystem _particlesPrefabBoys; //Field offset: 0xA8
	private ParticleSystem _particlesPrefabGirls; //Field offset: 0xB0
	private SkeletonAnimation _characterSkeletonAnimation; //Field offset: 0xB8
	private LevelCharacterInteractionHandler _characterInteractionHandler; //Field offset: 0xC0
	private BoneFollower _leftBoneFollower; //Field offset: 0xC8
	private BoneFollower _rightBoneFollower; //Field offset: 0xD0
	private string _startedAnimationWithParticles; //Field offset: 0xD8
	private readonly string HIP_HOP_ANIMATION_PREFIX; //Field offset: 0xE0
	private readonly string KPOP_ANIMATION_PREFIX_GIRLS; //Field offset: 0xE8
	private readonly string KPOP_ANIMATION_PREFIX_BOYS; //Field offset: 0xF0

	public LevelCABraceletHipHopDanceClothingSpineSkinHandler() { }

	private void AddParticles(string animationName) { }

	protected virtual void Awake() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	private void OnAnimationEnd(TrackEntry trackEntry) { }

	private void OnAnimationStart(TrackEntry trackEntry) { }

	protected virtual void OnDestroy() { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	private void RemoveParticles() { }

}

