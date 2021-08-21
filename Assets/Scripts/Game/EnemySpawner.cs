using Game.Character;
using Handler;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
	public class EnemySpawner : MonoBehaviour
	{
		[SerializeField] private int _secondStageLevel = default;
		[SerializeField] private int _thirdStageLevel = default;

		[SerializeField] private List<Enemy> _firstStageEnemies = default;
		[SerializeField] private List<Enemy> _secondStageEnemies = default;
		[SerializeField] private List<Enemy> _thirdStageEnemies = default;

		[SerializeField] private float spawnDelay = default;
		[SerializeField] private float reduceSpawnDelayValue = default;

		[SerializeField] private List<Transform> _roadSpawnPositions = default;
		[SerializeField] private List<Transform> _treeSpawnPositions = default;
		[SerializeField] private List<Transform> _offroadSpawnPositions = default;

		private PlayerProgressHandler _playerProgress;
		private WaitForSeconds _wait;

		private int GetRandomIndex(int max) => Random.Range(0, max);

		private void Start()
		{
			_playerProgress = FindObjectOfType<PlayerProgressHandler>();
			_playerProgress.OnLevelChanges += OnLevelChanged;

			_wait = new WaitForSeconds(spawnDelay);
		}

		public void StartSpawn()
		{
			_playerProgress.IsRunnig = true;
			StartCoroutine(SpawnRoutime());
		}

		private IEnumerator SpawnRoutime()
		{
			while (_playerProgress.IsRunnig)
			{
				yield return _wait;
				Spawn();
			}
		}

		private void OnLevelChanged(int value)
		{
			if (value <= 1)
				return;

			ReduceSpawnDelay();
		}

		private void ReduceSpawnDelay()
		{
			spawnDelay -= reduceSpawnDelayValue;
			if (spawnDelay <= 0)
				return;

			_wait = new WaitForSeconds(spawnDelay);
		}

		private void Spawn()
		{
			var enemies = GetEnemies();
			var enemy = enemies[GetRandomIndex(enemies.Count)];
			var spawnPosition = GetRandomSpawnPosition(enemy);

			Instantiate(enemy, spawnPosition, Quaternion.identity, transform).gameObject
				.SetActive(true);
		}

		private List<Enemy> GetEnemies()
		{
			if (_playerProgress.Level >= _thirdStageLevel)
				return _thirdStageEnemies;
			if (_playerProgress.Level >= _secondStageLevel)
				return _secondStageEnemies;

			return _firstStageEnemies;
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

			return spawnPositions[GetRandomIndex(spawnPositions.Count)].position;
		}
	}
}