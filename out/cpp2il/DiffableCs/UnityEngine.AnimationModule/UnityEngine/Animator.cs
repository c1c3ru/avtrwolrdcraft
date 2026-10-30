namespace UnityEngine;

[NativeHeader("Modules/Animation/ScriptBindings/Animator.bindings.h")]
[NativeHeader("Modules/Animation/ScriptBindings/AnimatorControllerParameter.bindings.h")]
[NativeHeader("Modules/Animation/Animator.h")]
[UsedByNativeCode]
public class Animator : Behaviour
{

	public bool hasBoundPlayables
	{
		[NativeMethod("HasBoundPlayables")]
		 get { } //Length: 60
	}

	public int layerCount
	{
		 get { } //Length: 60
	}

	public Animator() { }

	[NativeMethod("HasBoundPlayables")]
	public bool get_hasBoundPlayables() { }

	public int get_layerCount() { }

	internal int GetAnimatorClipInfoCount(int layerIndex, bool current) { }

	[FreeFunction(Name = "AnimatorBindings::GetAnimatorClipInfoInternal", HasExplicitThis = True)]
	private void GetAnimatorClipInfoInternal(int layerIndex, bool isCurrent, object clips) { }

	private void GetAnimatorStateInfo(int layerIndex, StateInfoIndex stateInfoIndex, out AnimatorStateInfo info) { }

	public void GetCurrentAnimatorClipInfo(int layerIndex, List<AnimatorClipInfo> clips) { }

	public int GetCurrentAnimatorClipInfoCount(int layerIndex) { }

	public AnimatorStateInfo GetCurrentAnimatorStateInfo(int layerIndex) { }

	public string GetLayerName(int layerIndex) { }

	public float GetLayerWeight(int layerIndex) { }

	public void GetNextAnimatorClipInfo(int layerIndex, List<AnimatorClipInfo> clips) { }

	public int GetNextAnimatorClipInfoCount(int layerIndex) { }

	public AnimatorStateInfo GetNextAnimatorStateInfo(int layerIndex) { }

	public void ResetTrigger(string name) { }

	[FreeFunction(Name = "AnimatorBindings::ResetTriggerString", HasExplicitThis = True)]
	private void ResetTriggerString(string name) { }

	public void SetTrigger(string name) { }

	[FreeFunction(Name = "AnimatorBindings::SetTriggerString", HasExplicitThis = True)]
	private void SetTriggerString(string name) { }

}

