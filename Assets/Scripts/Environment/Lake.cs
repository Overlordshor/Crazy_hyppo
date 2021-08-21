using Game.Character;
using Handler;
using UnityEngine;

namespace Game.Environment
{
	public class Lake : MonoBehaviour
	{
		private VictoryPointsHandler _victoryPointsHandler;
		public Vector3 Position => transform.position;

		private void Start()
		{
			_victoryPointsHandler = FindObjectOfType<VictoryPointsHandler>();
		}

		private void OnTriggerEnter(Collider other)
		{
			if (!other.CompareTag("Enemy"))
				return;

			var enemy = other.GetComponent<Enemy>();
			enemy.Stop();
			_victoryPointsHandler.Subtract(enemy.PointsValue);
		}
	}
}