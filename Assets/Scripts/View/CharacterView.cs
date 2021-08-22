using System;
using UnityEngine;

namespace Game.Character.View
{
	public class CharacterView : MonoBehaviour
	{
		[SerializeField] private Sprite _sprite = default;
		[SerializeField] private ParticleSystem _sleepVfx = default;

		private SpriteRenderer _view;

		private void Awake()
		{
			_view = GetComponentInChildren<SpriteRenderer>();

			if (_sprite != default)
				_view.sprite = _sprite;
		}

		public void PlaySleepVFX() => _sleepVfx.Play();

		public void StopSleepVFX() => _sleepVfx.Stop();
	}
}