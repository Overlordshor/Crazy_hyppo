using Game.Character;
using Handler;
using UnityEngine;

namespace Game.Environment
{
	public class Lake : MonoBehaviour
	{
		private PlayerProgressHandler _victoryPointsHandler;
		public Vector3 Position => transform.position;

		private void Start()
		{
			_victoryPointsHandler = FindObjectOfType<PlayerProgressHandler>();
		}

		private void OnTriggerEnter(Collider other)
		{
			if (!other.CompareTag("Enemy"))
				return;

			var enemy = other.GetComponent<Enemy>();
			_victoryPointsHandler.Subtract(enemy.PointsValue);

			enemy.Stop();
		}
	}
}