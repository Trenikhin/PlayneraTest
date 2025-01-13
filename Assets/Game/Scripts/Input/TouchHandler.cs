namespace Game.Input
{
	using Obj;
	using Scripts;
	using UnityEngine;
	using Zenject;

	public interface ITouchHandler
	{
		void OnScreenDown( Vector2 screenPos );
		void OnPointerUp( Vector2 screenPos );
		
		void OnStartGrab( IObjFacade obj );
		void OnGrab(Vector2 position );
		void OnFinishGrab( IObjFacade obj );
	}
	
	public class TouchHandler : IInitializable, ITouchHandler
	{
		[Inject] ScrollHandler _scrollHandler;
		
		DragComponent _dragComponent;
		Camera _camera;

		public void Initialize()
		{
			_camera = Camera.main;
		} 
		
		public void OnScreenDown(Vector2 screenPos)
		{
			// Check if obj selected
			var ray = _camera.ScreenPointToRay(screenPos);
			var hit = Physics2D.Raycast(ray.origin, ray.direction);

			if (hit.collider == null || !hit.collider.TryGetComponent<IObjFacade>(out _))
			{
				_scrollHandler.SetScroll( true );	
			}
		}
		
		public void OnPointerUp(Vector2 screenPos)
		{
			_scrollHandler.SetScroll( false );	
		}

		public void OnStartGrab(IObjFacade obj)
		{
			if (!obj.TryGet(out DragComponent component))
				return;
			
			_dragComponent = component;
				
			_dragComponent.BeginDrag();
		}

		public void OnGrab(Vector2 position)
		{
			_dragComponent.Drag(position);
		}

		public void OnFinishGrab(IObjFacade obj)
		{
			_dragComponent.FinishGrab();
			
			_dragComponent = null;
		}
	}
}