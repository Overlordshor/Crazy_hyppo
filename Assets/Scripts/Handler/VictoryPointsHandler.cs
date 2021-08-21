using Lean.Gui;
using UnityEngine;

namespace Handler
{
	public class VictoryPointsHandler : MonoBehaviour
	{
		[SerializeField] private string defeatText = default;
		[SerializeField] private int startingPoints = default;
		[SerializeField] private int pointsToLevelUp = default;

		private int _points;
		private int _totalPointsCollected;
		private LeanTooltipData _tooltipData;
		private int _level;

		public int Points => _points;

		public delegate void PointHandler(int value);

		public event PointHandler OnChanges;

		public event PointHandler OnLevelChanges;

		private void Awake()
		{
			_tooltipData = GetComponent<LeanTooltipData>();
			_points = startingPoints;
			_level = 1;
			_totalPointsCollected = 0;
		}

		private void Start()
		{
			OnChanges.Invoke(_points);
			OnLevelChanges.Invoke(_level);
		}

		public void Subtract(int value)
		{
			if (value == 0)
				return;

			_points -= value;
			OnChanges.Invoke(_points);

			Debug.Log($"Points is {_points}");

			if (_points >= 0)
				return;

			_tooltipData.Text = $"{defeatText}. Your Level: {_level}";
			LeanTooltip.HoverData = _tooltipData;
			LeanTooltip.HoverShow = true;
		}

		public void Add(int value)
		{
			if (value == 0)
				return;

			_points += value;
			_totalPointsCollected += value;
			OnChanges.Invoke(_points);

			Debug.Log($"Points is {_points}");

			if (_totalPointsCollected % pointsToLevelUp != 0)
				return;

			_level++;
			OnLevelChanges.Invoke(_level);
		}
	}
}