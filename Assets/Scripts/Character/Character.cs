using Game.Character.View;
using UnityEngine;

namespace Game.Character
{
	public class Character : MonoBehaviour
	{
		protected CharacterView _view = default;
		protected Rigidbody _rigidbody;

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody>();
			_view = GetComponent<CharacterView>();
			OnAwake();
		}

		protected virtual void OnAwake()
		{
		}
	}
}