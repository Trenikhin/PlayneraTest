namespace Game.Obj
{
	using DG.Tweening;
	using UnityEngine;

	public interface IObjView
	{
		void Move( Vector3 pos );
		void SetGrabbed( bool isGrabbed );
	}
	
	public class AppleView : MonoBehaviour, IObjView
	{
		[SerializeField] Transform _viewParent;
		
		[SerializeField] float _grabbedMultiplier;
		
		Sequence _grabTween;
		
		void OnDisable() => _grabTween?.Kill();
		
		public void Move(Vector3 pos)
		{
			_viewParent.position = pos;
		}

		public void SetGrabbed(bool isGrabbed)
		{
			_grabTween?.Kill();
			_grabTween = DOTween.Sequence();

			var scale = isGrabbed ? Vector3.one * (1 + _grabbedMultiplier) : Vector3.one;
			var grabHeight = isGrabbed ? .16f : .09f;
			
			_grabTween.Append(transform.DOScale(scale, 0.1f));
			_grabTween.Join(transform.DOLocalMoveY( grabHeight, 0.15f ).SetEase( Ease.OutQuad ));
		}
	}
}