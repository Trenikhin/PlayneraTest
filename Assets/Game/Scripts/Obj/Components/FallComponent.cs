namespace Game.Obj
{
	using System;
	using UnityEngine;
	using Zenject;

	public class FallComponent : ITickable
	{
		[Inject] IObjFacade _facade;
		
		Func<bool> _fallCondition;
		
		const float _gravity = 9.81f;
		const float _gravityMultiplier = 1.5f;
		
		public void AddFallCondition(Func<bool> condition)
		{
			_fallCondition = condition;
		}
		
		public void Tick()
		{
			if (_fallCondition == null || !_fallCondition())
				return;
			
			var gravity = _gravity * (1 + _gravityMultiplier);
			_facade.Transform.position += Vector3.down * gravity * Time.deltaTime;
		}
	}
}