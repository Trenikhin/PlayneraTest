namespace Game.Scripts
{
	using System;
	using UniRx;
	using UnityEngine;
	using Zenject;
	
	public class DragComponent : IInitializable
	{
		public readonly ReactiveCommand<Vector3> OnMoved = new ();
		public IReadOnlyReactiveProperty<bool> IsGrabbed => _isGrabbed;
		
		ReactiveProperty<bool> _isGrabbed = new ();
		Vector3 _position;
		Camera _camera;
		
		public void Initialize()
		{
			_camera = Camera.main;
		}
		
		public void BeginDrag()
		{
			if (_isGrabbed.Value)
				throw new Exception( "Is already grabbed!" );
			
			_isGrabbed.Value = true;
		}

		public void Drag(Vector3 pos)
		{
			if (!_isGrabbed.Value)
				throw new Exception("Drag called before BeginDrag()");
			
			if (_position != ScreenToWorld(pos))
				OnMoved.Execute( _position );
			
			_position = ScreenToWorld(pos);
		}

		public void FinishGrab()
		{
			if (!_isGrabbed.Value)
				throw new Exception("FinishGrab called before BeginDrag()");
			
			_isGrabbed.Value = false;
		}
		
		Vector3 ScreenToWorld(Vector3 pos)
		{
			Vector3 worldPos = _camera.ScreenToWorldPoint(pos);
			
			return new Vector2(worldPos.x, worldPos.y);
		}
	}
}