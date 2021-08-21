using Lean.Gui;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
	public class DefeatSreen : View
	{
		[SerializeField] private LeanButton _restartButton = default;

		private void Awake()
		{
			_restartButton.OnClick.AddListener(() => Restart());
		}

		private void Restart()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}

		private void OnDestroy()
		{
			_restartButton.OnClick.RemoveAllListeners();
		}
	}
}