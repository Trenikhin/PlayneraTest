namespace Game.Obj
{
	using UnityEngine;
	using Zenject;

	public interface IObjFacade
	{
		GameObject GameObject { get; }
		Transform Transform { get; }
		
		bool TryGet<T>(out T component)
			where T : class;
	}
	
	public class ObjFacade : MonoBehaviour, IObjFacade
	{
		[Inject] DiContainer _container;
		
		public GameObject GameObject => gameObject;
		public Transform Transform => transform;
		
		public bool TryGet<T>( out T component ) where T : class
		{
			component = _container.TryResolve<T>();
			
			return component != null;
		}
	}
}