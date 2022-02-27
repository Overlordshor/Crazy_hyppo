using Game;
using Lean.Gui;
using UnityEngine;

namespace UI
{
	public class InfoScreen : View
	{
		[SerializeField] private LeanButton _startButton = default;
		[SerializeField] private View _hud = default;

		protected override void OnAwake()
		{
			var enemySpawner = FindObjectOfType<EnemySpawner>();
			_startButton.OnClick.AddListener(() =>
			{
				_hud.Show();
				enemySpawner.StartSpawn();
				Close();
			});
		}
	}
}