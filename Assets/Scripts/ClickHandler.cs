using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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