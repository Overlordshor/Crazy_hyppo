using Lean.Gui;
using UnityEngine;

namespace UI
{
	public class InfoGameScreen : View
	{
		[SerializeField] private LeanButton _startButton = default;
		[SerializeField] private View _menu = default;

		protected override void OnAwake()
		{
			_startButton.OnClick.AddListener(() => StartGame());
		}

		private void StartGame()
		{
			_menu.Show();
			Close();
		}
	}
}