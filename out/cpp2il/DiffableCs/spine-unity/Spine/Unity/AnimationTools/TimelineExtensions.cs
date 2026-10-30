namespace Spine.Unity.AnimationTools;

[Extension]
public static class TimelineExtensions
{

	[Extension]
	public static Vector2 Evaluate(TranslateTimeline timeline, float time, SkeletonData skeletonData = null) { }

	public static Vector2 Evaluate(TranslateXTimeline xTimeline, TranslateYTimeline yTimeline, float time, SkeletonData skeletonData = null) { }

	[Extension]
	public static float Evaluate(RotateTimeline timeline, float time, SkeletonData skeletonData = null) { }

	[Extension]
	public static float EvaluateRotateMix(TransformConstraintTimeline timeline, float time) { }

	[Extension]
	public static Vector2 EvaluateTranslateXYMix(TransformConstraintTimeline timeline, float time) { }

	[Extension]
	public static T FindTimelineForBone(Animation a, int boneIndex) { }

	[Extension]
	public static TransformConstraintTimeline FindTransformConstraintTimeline(Animation a, int transformConstraintIndex) { }

	[Extension]
	public static TranslateTimeline FindTranslateTimelineForBone(Animation a, int boneIndex) { }

}

