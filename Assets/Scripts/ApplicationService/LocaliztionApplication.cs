using Assets.SimpleLocalization;
using UnityEngine;
using UnityEngine.UI;

namespace CrazyHippo.ApplicationService
{
	public class LocaliztionApplication : ILocaliztionApplication
	{
		public Text FormattedText;

		/// <summary>
		/// Called on app start.
		/// </summary>
		public void Awake()
		{
			LocalizationManager.Read();

			switch (Application.systemLanguage)
			{
				case SystemLanguage.German:
					LocalizationManager.Language = "German";
					break;

				case SystemLanguage.Russian:
					LocalizationManager.Language = "Russian";
					break;

				default:
					LocalizationManager.Language = "English";
					break;
			}
		}

		/// <summary>
		/// Change localization at runtime
		/// </summary>
		public void SetLocalization(string localization)
		{
			LocalizationManager.Language = localization;
		}
	}
}