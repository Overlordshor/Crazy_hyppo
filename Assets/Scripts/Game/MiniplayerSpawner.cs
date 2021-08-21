using Game.Character;
using Handler;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
	public class MiniplayerSpawner : MonoBehaviour
	{
		[SerializeField] private Miniplayer _miniplayer = default;
		[SerializeField] private Vector3 spawnPositionOffset = default;

		private PlayerProgressHandler _victoryPointsHandler;
		private Bounds _spawnBounds;

		private List<Miniplayer> _miniplayers = new List<Miniplayer>();

		public bool MiniplayersAreOver => _miniplayers.Count == 0;

		private void Awake()
		{
			InitSpawnBounds();
		}

		private void Start()
		{
			_victoryPointsHandler = FindObjectOfType<PlayerProgressHandler>();
			_victoryPointsHandler.OnLevelChanges += OnLevelChanged;
		}

		public void Despawn()
		{
			var miniplayer = _miniplayers.FirstOrDefault();
			if (miniplayer == null)
				return;

			Destroy(miniplayer.gameObject);
			_miniplayers.RemoveAt(0);
		}

		public void Spawn()
		{
			var miniPlayer = Instantiate(_miniplayer, GetRandomPosition(), Quaternion.identity, transform);
			miniPlayer.gameObject.SetActive(true);
			miniPlayer.Excite();

			_miniplayers.Add(miniPlayer);
		}

		private void InitSpawnBounds()
		{
			var lakeCollider = GetComponent<Collider>();
			_spawnBounds = lakeCollider.bounds;
			_spawnBounds.min += spawnPositionOffset;
			_spawnBounds.max -= spawnPositionOffset;
		}

		private void OnLevelChanged(int value)
		{
			if (value <= 1)
				return;

			Spawn();
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