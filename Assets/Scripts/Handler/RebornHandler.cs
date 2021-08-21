using Game;
using Game.Character;
using Lean.Gui;
using System;
using UnityEngine;

namespace Handler
{
	public class RebornHandler : MonoBehaviour
	{
		[SerializeField] private string defeatText = default;

		private MiniplayerSpawner _miniplayerSpawner;
		private LeanTooltipData _tooltipData;
		private VictoryPointsHandler _victoryPointsHandler;

		private void Start()
		{
			_miniplayerSpawner = FindObjectOfType<MiniplayerSpawner>();
			_tooltipData = FindObjectOfType<LeanTooltipData>();
			_victoryPointsHandler = FindObjectOfType<VictoryPointsHandler>();
		}

		public void RebornPlayer()
		{
			if (_miniplayerSpawner.MiniplayersAreOver)
			{
				FinishGame();
				return;
			}

			_miniplayerSpawner.Despawn();
			gameObject.SetActive(true);
		}

		private void FinishGame()
		{
			_tooltipData.Text = $"{defeatText}. Earned: {_victoryPointsHandler.Points}";
			LeanTooltip.HoverData = _tooltipData;
			LeanTooltip.HoverShow = true;
		}
	}
}