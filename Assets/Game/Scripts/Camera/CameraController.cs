namespace Game.Camera
{
	using UnityEngine;

	public interface ICameraController
	{
		void Scroll( Vector3 direction );
	}
	
	public class CameraController : MonoBehaviour, ICameraController
	{
		[SerializeField] float _moveSpeed = 10f;
		
		[SerializeField] Transform _cameraTarget;
		[SerializeField] BoxCollider2D _borders;
		
		Camera _camera;

		void Start()
		{
			_camera = Camera.main;
		}

		public void Scroll(Vector3 delta)
		{
			var moveStep = delta.x * _moveSpeed * Time.deltaTime;
			
			Vector3 newPosition = _cameraTarget.position - new Vector3(moveStep, 0, 0);
			Vector3 clampedPosition = ClampToBoundary(newPosition);
					
			_cameraTarget.position = clampedPosition;
		}
		
		Vector3 ClampToBoundary(Vector3 targetPosition)
		{
			Bounds bounds = _borders.bounds;
			
			float cameraHeight = _camera.orthographicSize * 2;
			float cameraWidth = cameraHeight * _camera.aspect;
			
			float clampedX = Mathf.Clamp(targetPosition.x, bounds.min.x + cameraWidth / 2, bounds.max.x - cameraWidth / 2);
			float clampedY = Mathf.Clamp(targetPosition.y, bounds.min.y + cameraHeight / 2, bounds.max.y - cameraHeight / 2);

			return new Vector3(clampedX, clampedY, targetPosition.z);
		}
	}

}