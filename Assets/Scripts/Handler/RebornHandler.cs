using Game;
using Lean.Gui;
using UnityEngine;

namespace Handler
{
	public class RebornHandler : MonoBehaviour
	{
		[SerializeField] private int _miniplayersStartCount = default;
		[SerializeField] private string defeatText = default;

		private MiniplayerSpawner _miniplayerSpawner;
		private LeanTooltipData _tooltipData;
		private PlayerProgressHandler _playerProgress;

		private void Start()
		{
			_miniplayerSpawner = FindObjectOfType<MiniplayerSpawner>();
			_tooltipData = FindObjectOfType<LeanTooltipData>();
			_playerProgress = FindObjectOfType<PlayerProgressHandler>();

			for (int i = 0; i < _miniplayersStartCount; i++)
				_miniplayerSpawner.Spawn();
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
			_tooltipData.Text = $"{defeatText}. Earned: {_playerProgress.Points}";
			LeanTooltip.HoverData = _tooltipData;
			LeanTooltip.HoverShow = true;

			_playerProgress.IsRunnig = false;
		}
	}
}