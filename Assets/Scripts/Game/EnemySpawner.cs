using DG.Tweening;
using Game.Сharacter;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class EnemySpawner : MonoBehaviour
	{
		[SerializeField] private Enemy _enemy = default;
		[SerializeField] private float spawnDelay = default;
		[SerializeField] private List<Transform> spawnPositions = default;

		private void Awake()
		{
			DOVirtual.DelayedCall(spawnDelay, () => Spawn())
				.SetLoops(-1);
		}

		private void Spawn()
		{
			Instantiate(_enemy, GetRandomSpawnPosition(), Quaternion.identity, transform).gameObject
				.SetActive(true);
		}

		private Vector3 GetRandomSpawnPosition()
		{
			var randomIndex = Random.Range(0, spawnPositions.Count);
			return spawnPositions[randomIndex].position;
		}
	}
}