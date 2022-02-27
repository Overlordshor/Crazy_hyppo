using System;
using Zenject;

namespace CrazyHippo.Infrastucture
{
	public class MetaGameInstaller : MonoInstaller, IInstaller
	{
		public override void InstallBindings()
		{
			BindLocalizationApplication();
		}

		private void BindLocalizationApplication()
		{
			throw new NotImplementedException();
		}
	}
}