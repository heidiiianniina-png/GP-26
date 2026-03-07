using UnityEngine;

namespace AA0000
{
	public class BobberSinewave : MonoBehaviour
	{
		public AnimationCurve bobbingCurve; // Controls the bobbing motion

		public float amplitudeMultiplier = 0.3f; // Maximum height deviation
		public float speed = 2f;       // Speed of movement
		public float cycleDuration = 1f; // Duration of one full cycle (in seconds)
		public bool useZAxis = false;

		private float startY, startZ;
		private float timeOffset, timeOffsetZ;

		void Start()
		{
			startY = transform.position.y;
			startZ = transform.position.z;

			timeOffset = UnityEngine.Random.Range(0f, cycleDuration); // Prevents identical movement if multiple objects use this script
			timeOffsetZ = UnityEngine.Random.Range(0f, cycleDuration); // Prevents identical movement and same time bobbing in z axis
		}

		void Update()
		{
			float normalizedTime = NormalizeTime();
			float normalizedZTime = NormalizeZTime();

			// Evaluate the bobbing curve
			float curveValue = bobbingCurve.Evaluate(normalizedTime);
			float curveValueZ = bobbingCurve.Evaluate(normalizedZTime);

			// Apply curve-controlled bobbing
			float newY = startY + curveValue * amplitudeMultiplier;
			float newZ = startZ + curveValueZ * amplitudeMultiplier;

			if (useZAxis)
			{
				transform.position = new Vector3(transform.position.x, newY, newZ);
			}
			else
			{ 
				transform.position = new Vector3(transform.position.x, newY, transform.position.z);
			}
		}

		private float NormalizeTime()
		{
			// Normalize time with offset to ensure smooth looping
			return ((Time.time + timeOffset) % cycleDuration) / cycleDuration;
		}

		private float NormalizeZTime()
		{
			// Normalize time with offset to ensure smooth looping
			return ((Time.time + timeOffsetZ) % cycleDuration) / cycleDuration;
		}
	}
}
