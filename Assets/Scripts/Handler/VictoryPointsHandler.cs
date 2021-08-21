using UnityEngine;

namespace Handler
{
	public class VictoryPointsHandler : MonoBehaviour
	{
		private int _points;

		private void Awake()
		{
			_points = 10;
		}

		public void Subtract(int value)
		{
			_points -= value;
			Debug.Log($"Points is {_points}");
		}

		public void Add(int value)
		{
			_points += value;
			Debug.Log($"Points is {_points}");
		}
	}
}