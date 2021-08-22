using DG.Tweening;
using UnityEngine;

namespace Game.Character.View
{
	public class CharacterView : MonoBehaviour
	{
		[SerializeField] private SpriteRenderer _emoji;

		[SerializeField] private Sprite _sprite = default;
		[SerializeField] private Sprite _spriteAngry = default;
		[SerializeField] private float _shakeScaleDuration = default;

		private SpriteRenderer _view;

		private Tween _tween;

		private void Awake()
		{
			_view = GetComponentInChildren<SpriteRenderer>();

			if (_sprite != default)
				_view.sprite = _sprite;
		}

		public void PlayAngry()
		{
			_emoji.gameObject.SetActive(true);
			_emoji.sprite = _spriteAngry;

			_tween?.Kill();
			_tween = _emoji.gameObject.transform.DOShakeScale(_shakeScaleDuration, 1, 1)
				.SetLoops(-1);
		}

		public void StopEmoji()
		{
			_tween?.Kill();
			_emoji.gameObject.SetActive(false);
		}

		private void OnDestroy()
		{
			_tween?.Kill();
		}
	}
}