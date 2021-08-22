using DG.Tweening;
using Game.Environment;
using Game.Character.View;
using UnityEngine;

namespace Game.Character
{
	public class Enemy : Character
	{
		[SerializeField] private int _pointsValue = default;
		[SerializeField] private float _moveDuration = default;
		[SerializeField] private float _scaleDuration = default;

		private Tween _tween;

		public int PointsValue { get => _pointsValue; }

		protected override void OnAwake()
		{
			_tween = transform.DOMove(FindObjectOfType<Lake>().Position, _moveDuration)
				.SetEase(Ease.Linear);
		}

		public void Stop()
		{
			_tween?.Kill();

			Devalue();
		}

		public void ApplyDamage()
		{
			Die();
		}

		private void Devalue()
		{
			_pointsValue = 0;
		}

		private void Die()
		{
			Stop();

			_tween = transform.DOScale(Vector3.zero, _scaleDuration)
				.OnComplete(() => Destroy(gameObject));
		}

		private void OnDestroy()
		{
			Stop();
		}

		private void Reset()
		{
			_view = GetComponentInChildren<CharacterView>();
		}
	}
}