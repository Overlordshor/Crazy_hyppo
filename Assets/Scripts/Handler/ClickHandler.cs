using Game.Character;
using UnityEngine;

namespace Handler
{
	public class ClickHandler : MonoBehaviour
	{
		[SerializeField] private Player _player = default;

		private void Awake()
		{
			if (_player == default)
				Debug.LogError($"Missing link to player in component {ToString()}");
		}

		private void Update()
		{
			if (!_player.IsLaunched || _player.IsSecondJumpAvailable)
			{
				if (Input.GetMouseButtonDown(0))
					_player.RotateLeft();

				if (Input.GetMouseButtonDown(1))
					_player.RotateRigth();
			}

			if (!_player.IsRotated)
				return;

			if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
				_player.Launch();
		}
	}
}