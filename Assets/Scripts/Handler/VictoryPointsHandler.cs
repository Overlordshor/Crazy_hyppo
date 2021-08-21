using Lean.Gui;
using UnityEngine;

namespace Handler
{
	public class VictoryPointsHandler : MonoBehaviour
	{
		[SerializeField] private string defeatText = default;

		private int _points;
		private int _totalPointsCollected;
		private LeanTooltipData _tooltipData;

		public int Points => _points;

		public delegate void PointHandler(int value);

		public event PointHandler OnTotalChanges;

		private void Awake()
		{
			_tooltipData = GetComponent<LeanTooltipData>();
			_points = 10;
			_totalPointsCollected = 0;
		}

		public void Subtract(int value)
		{
			if (value == 0)
				return;

			_points -= value;

			Debug.Log($"Points is {_points}");

			if (_points >= 0)
				return;

			_tooltipData.Text = $"{defeatText}. Total points earned: {_totalPointsCollected}";
			LeanTooltip.HoverData = _tooltipData;
			LeanTooltip.HoverShow = true;
		}

		public void Add(int value)
		{
			if (value == 0)
				return;

			_points += value;
			_totalPointsCollected += value;

			Debug.Log($"Points is {_points}");

			if (_totalPointsCollected % 10 != 0)
				return;

			OnTotalChanges.Invoke(_totalPointsCollected);
		}
	}
}