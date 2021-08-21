using Game;
using Lean.Gui;
using UnityEngine;

namespace UI
{
	public class RulesScreen : View
	{
		[SerializeField] private LeanButton _startGameButton = default;

		protected override void OnAwake()
		{
			var enemySpawner = FindObjectOfType<EnemySpawner>();
			_startGameButton.OnClick.AddListener(() =>
			{
				enemySpawner.StartSpawn();
				Close();
			});
		}
	}
}