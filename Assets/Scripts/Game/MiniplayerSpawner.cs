using Game.Character;
using Handler;
using UnityEngine;

namespace Game
{
	public class MiniplayerSpawner : MonoBehaviour
	{
		[SerializeField] private Miniplayer _miniplayer;
		[SerializeField] private Vector3 spawnPositionOffset = default;

		private VictoryPointsHandler _victoryPointsHandler;
		private Bounds _spawnBounds;

		private void Awake()
		{
			InitSpawnBounds();
		}

		private void Start()
		{
			_victoryPointsHandler = FindObjectOfType<VictoryPointsHandler>();
			_victoryPointsHandler.OnTotalChanges += OnTotalCollectedPointsChanged;
		}

		private void InitSpawnBounds()
		{
			var lakeCollider = GetComponent<Collider>();
			_spawnBounds = lakeCollider.bounds;
			_spawnBounds.min += spawnPositionOffset;
			_spawnBounds.max -= spawnPositionOffset;
		}

		private void OnTotalCollectedPointsChanged(int value)
		{
			Spawn();
		}

		private void Spawn()
		{
			var spawnPosition = GetRandomPosition();
			Instantiate(_miniplayer, spawnPosition, Quaternion.identity, transform).gameObject
				.SetActive(true);
		}

		private Vector3 GetRandomPosition()
		{
			var min = _spawnBounds.min;
			var max = _spawnBounds.max;
			return new Vector3(Random.Range(min.x, max.x), transform.position.y, Random.Range(min.z, max.z));
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.blue;
			Gizmos.DrawWireCube(_spawnBounds.center, _spawnBounds.size);
		}
	}
}