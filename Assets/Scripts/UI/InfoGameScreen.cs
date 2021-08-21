using Lean.Gui;
using UnityEngine;

namespace UI
{
	public class InfoGameScreen : View
	{
		[SerializeField] private LeanButton _startButton = default;
		[SerializeField] private View _rules = default;
		[SerializeField] private View _hud = default;

		protected override void OnAwake()
		{
			_startButton.OnClick.AddListener(() => ShowRules());
		}

		private void ShowRules()
		{
			_rules.Show();
			_hud.Show();
			Close();
		}
	}
}