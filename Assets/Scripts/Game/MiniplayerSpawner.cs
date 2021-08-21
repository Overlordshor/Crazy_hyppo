using Game.Character;
using Handler;
using UnityEngine;

namespace Game
{
	public class MiniplayerSpawner : MonoBehaviour
	{
		[SerializeField] private Miniplayer _miniplayer;

		private VictoryPointsHandler _victoryPointsHandler;

		private void Start()
		{
			_victoryPointsHandler = FindObjectOfType<VictoryPointsHandler>();
			_victoryPointsHandler.OnTotalChanges += OnTotalCollectedPointsChanged;
		}

		private void OnTotalCollectedPointsChanged(int value)
		{
			Spawn();
		}

		private void Spawn()
		{
			Instantiate(_miniplayer, transform).gameObject
				.SetActive(true);
		}
	}
}