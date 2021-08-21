using DG.Tweening;
using Game.Environment;
using Game.Character.View;
using UnityEngine;
using System;

namespace Game.Character
{
	public class Enemy : Character
	{
		[SerializeField] private int _pointsValue = default;

		private Tween tween;

		public int PointsValue { get => _pointsValue; }

		protected override void OnAwake()
		{
			tween = transform.DOMove(FindObjectOfType<Lake>().Position, 10f)
				.SetEase(Ease.Linear);
		}

		public void Stop()
		{
			tween?.Kill();
		}

		public void ApplyDamage()
		{
			Die();
		}

		private void Die()
		{
			Debug.Log("Enemy is dead");
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