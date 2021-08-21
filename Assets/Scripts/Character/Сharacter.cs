using Game.Сharacter.View;
using UnityEngine;

namespace Game.Сharacter
{
	public class Сharacter : MonoBehaviour
	{
		[SerializeField] protected СharacterView _view = default;

		protected Rigidbody _rigidbody;

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody>();
			OnAwake();
		}

		protected virtual void OnAwake()
		{
		}
	}
}