using Lean.Gui;
using UnityEngine;

namespace UI
{
	public class View : MonoBehaviour
	{
		[SerializeField] private bool isStart = default;

		protected LeanWindow _leanWindow;

		private void Awake()
		{
			TryGetComponent<LeanWindow>(out _leanWindow);

			if (_leanWindow == null)
				gameObject.SetActive(isStart);
			else
				LeanWindowSetActive(isStart);

			OnAwake();
		}

		private void LeanWindowSetActive(bool isStart)
		{
			if (isStart)
				_leanWindow.TurnOn();
			else
				_leanWindow.TurnOff();
		}

		protected virtual void OnAwake()
		{
		}

		public void Show()
		{
			if (_leanWindow == null)
				gameObject.SetActive(true);
			else
				_leanWindow.TurnOn();
		}

		protected void Close()
		{
			if (_leanWindow == null)
				gameObject.SetActive(false);
			else
				_leanWindow.TurnOff();
		}
	}
}