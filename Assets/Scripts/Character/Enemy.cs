using DG.Tweening;
using Game.Environment;
using Game.Character.View;
using UnityEngine;

namespace Game.Character
{
	public class Enemy : Character
	{
		[SerializeField] private int _pointsValue = default;
		[SerializeField] private int _moveDuration = default;

		private Tween tween;

		public int PointsValue { get => _pointsValue; }

		protected override void OnAwake()
		{
			tween = transform.DOMove(FindObjectOfType<Lake>().Position, _moveDuration)
				.SetEase(Ease.Linear);
		}

		public void Stop()
		{
			tween?.Kill();

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
			Destroy(gameObject);
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