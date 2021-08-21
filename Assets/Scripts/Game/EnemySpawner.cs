using DG.Tweening;
using Game.Character;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
	public class EnemySpawner : MonoBehaviour
	{
		[SerializeField] private List<Enemy> _enemies = default;
		[SerializeField] private float spawnDelay = default;

		[SerializeField] private List<Transform> _roadSpawnPositions = default;
		[SerializeField] private List<Transform> _treeSpawnPositions = default;
		[SerializeField] private List<Transform> _offroadSpawnPositions = default;

		private int GetRandomIndex(int max) => Random.Range(0, max);

		private void Awake()
		{
			DOVirtual.DelayedCall(spawnDelay, () => Spawn())
				.SetLoops(-1);
		}

		private void Spawn()
		{
			var enemy = _enemies[GetRandomIndex(_enemies.Count)];
			var spawnPosition = GetRandomSpawnPosition(enemy);

			Instantiate(enemy, spawnPosition, Quaternion.identity, transform).gameObject
				.SetActive(true);
		}

		private Vector3 GetRandomSpawnPosition(Enemy enemy)
		{
			var spawnPositions = new List<Transform>();

			if (enemy is Elephant || enemy is Giraffe)
				spawnPositions = _roadSpawnPositions;

			if (enemy is Monkey)
				spawnPositions = _treeSpawnPositions;

			if (enemy is Parrot || enemy is Snake)
				spawnPositions = _offroadSpawnPositions;

			if (!spawnPositions.Any())
			{
				Debug.LogError("Spawn Positions is null");
				return Vector3.zero;
			}

			return spawnPositions[GetRandomIndex(_offroadSpawnPositions.Count)].position;
		}
	}
}