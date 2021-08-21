using System;
using UnityEngine;

namespace UI
{
	public class View : MonoBehaviour
	{
		[SerializeField] private bool isStart = default;

		private void Awake()
		{
			gameObject.SetActive(isStart);
			OnAwake();
		}

		protected virtual void OnAwake()
		{
		}

		public void Show() => gameObject.SetActive(true);

		protected void Close() => gameObject.SetActive(false);
	}
}