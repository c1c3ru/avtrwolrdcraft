//Type is in global namespace

public class ObjectAnimProperty
{
	public string objectName; //Field offset: 0x10
	[HideInInspector]
	public GameObject objGameObject; //Field offset: 0x18
	[HideInInspector]
	public ObjectType objectType; //Field offset: 0x20
	public float animationStartIndex; //Field offset: 0x24
	public float animTime; //Field offset: 0x28
	public float startDelayTime; //Field offset: 0x2C
	public AnimType animType; //Field offset: 0x30
	public AnimTweenType animTweenType; //Field offset: 0x34
	public bool animByCameraMovement; //Field offset: 0x38
	[Header("Sound")]
	public string soundName; //Field offset: 0x40
	public float soundDelayTime; //Field offset: 0x48
	public float volume; //Field offset: 0x4C
	[HideInInspector]
	public Vector2 position; //Field offset: 0x50
	[HideInInspector]
	public bool isAnimPlayed; //Field offset: 0x58

	public ObjectAnimProperty() { }

	public void OpacityAnims() { }

	public void OpacityForceReset(float index) { }

	public override void PlayAnimation() { }

	public void ScaleUpAnims() { }

	public void SetNewObject(GameObject objGameObject, ObjectType objectType, float startDelayTime, float animTime, AnimTweenType animTweenType) { }

}

