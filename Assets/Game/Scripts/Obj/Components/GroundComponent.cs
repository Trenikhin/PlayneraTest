namespace Game.Obj
{
	using UnityEngine;

	public class GroundComponent : MonoBehaviour
	{
		[SerializeField] LayerMask _groundLayer;
		[SerializeField] float _checkRadius = 0.1f;
		[SerializeField] Transform _groundCheck;
		
		public bool IsGround()
		{
			return Physics2D.OverlapCircle(_groundCheck.position, 0.1f, _groundLayer);
		}
	}
}