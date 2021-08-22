using Lean.Gui;
using UnityEngine;

namespace UI
{
	public class MenuScreen : View
	{
		[SerializeField] private LeanButton _startButton = default;
		[SerializeField] private View _info = default;

		protected override void OnAwake()
		{
			_startButton.OnClick.AddListener(() => ShowInfo());
		}

		private void ShowInfo()
		{
			_info.Show();
			Close();
		}
	}
}