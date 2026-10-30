//Type is in global namespace

public class LeanSmooth
{

	public LeanSmooth() { }

	public static float bounceOut(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed = -1, float deltaTime = -1, float friction = 2, float accelRate = 0,5, float hitDamping = 0,9) { }

	public static Vector3 bounceOut(Vector3 current, Vector3 target, ref Vector3 currentVelocity, float smoothTime, float maxSpeed = -1, float deltaTime = -1, float friction = 2, float accelRate = 0,5, float hitDamping = 0,9) { }

	public static Color bounceOut(Color current, Color target, ref Color currentVelocity, float smoothTime, float maxSpeed = -1, float deltaTime = -1, float friction = 2, float accelRate = 0,5, float hitDamping = 0,9) { }

	public static float damp(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed = -1, float deltaTime = -1) { }

	public static Vector3 damp(Vector3 current, Vector3 target, ref Vector3 currentVelocity, float smoothTime, float maxSpeed = -1, float deltaTime = -1) { }

	public static Color damp(Color current, Color target, ref Color currentVelocity, float smoothTime, float maxSpeed = -1, float deltaTime = -1) { }

	public static float linear(float current, float target, float moveSpeed, float deltaTime = -1) { }

	public static Vector3 linear(Vector3 current, Vector3 target, float moveSpeed, float deltaTime = -1) { }

	public static Color linear(Color current, Color target, float moveSpeed) { }

	public static float spring(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed = -1, float deltaTime = -1, float friction = 2, float accelRate = 0,5) { }

	public static Vector3 spring(Vector3 current, Vector3 target, ref Vector3 currentVelocity, float smoothTime, float maxSpeed = -1, float deltaTime = -1, float friction = 2, float accelRate = 0,5) { }

	public static Color spring(Color current, Color target, ref Color currentVelocity, float smoothTime, float maxSpeed = -1, float deltaTime = -1, float friction = 2, float accelRate = 0,5) { }

}

