using Lean.Gui;
using UnityEngine;

namespace Handler
{
	public class VictoryPointsHandler : MonoBehaviour
	{
		private int _points;
		private int _totalPointsCollected;
		private LeanTooltipData tooltipData;

		private void Awake()
		{
			tooltipData = GetComponent<LeanTooltipData>();
			_points = 10;
			_totalPointsCollected = 0;
		}

		public void Subtract(int value)
		{
			_points -= value;
			Debug.Log($"Points is {_points}");

			if (_points >= 0)
				return;

			tooltipData.Text = "You lose";
			LeanTooltip.HoverData = tooltipData;
			LeanTooltip.HoverShow = true;
		}

		public void Add(int value)
		{
			_points += value;
			_totalPointsCollected += value;
			Debug.Log($"Points is {_points}");

			if (_totalPointsCollected % 10 != 0)
				return;

			tooltipData.Text = "Get an extra life";
			LeanTooltip.HoverData = null;
			LeanTooltip.HoverShow = false;
		}
	}
}