namespace Game.Obj
{
	using Input;
	using UnityEngine;
	using UnityEngine.EventSystems;
	using Zenject;

	public class ObjTouchHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
	{
		[Inject] ITouchHandler _touchHandler;
		[Inject] IObjFacade _objFacade;
		
		public void OnBeginDrag(PointerEventData eventData) => _touchHandler.OnStartGrab( _objFacade );
		public void OnDrag(PointerEventData eventData) => _touchHandler.OnGrab( eventData.position );
		public void OnEndDrag(PointerEventData eventData) => _touchHandler.OnFinishGrab( _objFacade );
	}
}