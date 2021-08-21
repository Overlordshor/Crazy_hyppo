using Game.Сharacter;
using UnityEngine;

namespace Handler
{
	public class ClickHandler : MonoBehaviour
	{
		[SerializeField] private Player _player;

		private void OnMouseDown()
		{
			_player.Rotate();
		}

		private void OnMouseUp()
		{
			_player.Launch();
		}
	}
}