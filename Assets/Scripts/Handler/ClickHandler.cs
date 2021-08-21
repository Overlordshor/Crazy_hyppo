using Game.Сharacter;
using UnityEngine;

namespace Handler
{
	public class ClickHandler : MonoBehaviour
	{
		[SerializeField] private Player _player;

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