namespace Game.Obj
{
	using System;
	using Scripts;
	using UniRx;
	using UnityEngine;
	using Zenject;

	public class ApplePresenter : IInitializable, IDisposable
	{
		[Inject] IObjView _view;
		[Inject] DragComponent _dragComponent;
		
		CompositeDisposable _disposables = new ();
		
		public void Initialize()
		{
			_dragComponent.OnMoved
				.Subscribe( mousePos => _view.Move(mousePos) )
				.AddTo( _disposables );
			
			_dragComponent.IsGrabbed
				.Skip(1)
				.Subscribe( v => _view.SetGrabbed( v ) )
				.AddTo( _disposables );
		}

		public void Dispose() => _disposables?.Dispose();
	}
}