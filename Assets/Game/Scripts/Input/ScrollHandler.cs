namespace Game.Input
{
	using System.Linq;
	using Camera;
	using UnityEngine;
	using UnityEngine.EventSystems;
	using Zenject;
	
	public class ScrollHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
	{
		[Inject] ITouchHandler _touchHandler;
		[Inject] ICameraController _cameraController;
		
		Vector2 _lastTouchPosition;
		bool _canScroll;
		
		public void OnPointerDown(PointerEventData eventData)
		{
			_lastTouchPosition = eventData.position;
			_touchHandler.OnScreenDown(eventData.position);
		}

		public void OnPointerUp(PointerEventData eventData) => _touchHandler.OnPointerUp( eventData.position );
		
		public void SetScroll(bool canScroll) => _canScroll = canScroll;

		void LateUpdate()
		{
			if (!_canScroll)
				return;
			
			Vector2 touchPos = GetTouchOrMousePos(0);
			Vector2 delta = touchPos - _lastTouchPosition;
					
			_cameraController.Scroll( delta );
			_lastTouchPosition = touchPos;
		}
		
		static Vector2 GetTouchOrMousePos( int pointerId )
		{
			// Return mouse position
			if (Input.touchCount <= 0)
				return Input.mousePosition;
			
			// Return touch position
			Touch touch = Input.touches.FirstOrDefault(t => t.fingerId == pointerId);

			return touch.fingerId >= 0 ? touch.position : default;
		}
	}
}