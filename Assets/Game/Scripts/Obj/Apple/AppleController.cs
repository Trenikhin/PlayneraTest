namespace Game.Obj
{
	using Scripts;
	using Zenject;

	public class AppleController : IInitializable
	{
		[Inject] GroundComponent _groundComponent;
		[Inject] DragComponent _dragComponent;
		[Inject] FallComponent _fallComponent;
		
		public void Initialize()
		{
			_fallComponent.AddFallCondition( CanFall );
		}

		bool CanFall()
		{
			return !_dragComponent.IsGrabbed.Value &&
			       !_groundComponent.IsGround();
		}
	}
}