using Game.Character;
using UnityEngine;

namespace Handler
{
	public class ClickHandler : MonoBehaviour
	{
		[SerializeField] private Player _player;

		private void Awake()
		{
			if (_player == null)
				Debug.LogError($"Missing link to player in component {ToString()}");
		}

		private void OnMouseDown()
		{
			if (!_player.IsLaunched)
				_player.Rotate();
		}

		private void OnMouseUp()
		{
			if (!_player.IsLaunched)
				_player.Launch();
		}
	}
}