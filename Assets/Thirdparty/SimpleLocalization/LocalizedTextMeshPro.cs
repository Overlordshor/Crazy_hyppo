﻿using TMPro;
using UnityEngine;

namespace Assets.SimpleLocalization
{
	/// <summary>
	/// Localize text component.
	/// </summary>
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class LocalizedTextMeshPro : MonoBehaviour
	{
		public string LocalizationKey;

		public void Start()
		{
			Localize();
			LocalizationManager.LocalizationChanged += Localize;
		}

		public void OnDestroy()
		{
			LocalizationManager.LocalizationChanged -= Localize;
		}

		private void Localize()
		{
			GetComponent<TextMeshProUGUI>().text = LocalizationManager.Localize(LocalizationKey);
		}
	}
}