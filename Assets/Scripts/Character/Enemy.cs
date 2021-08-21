using DG.Tweening;
using Game.Environment;
using Game.Сharacter.View;
using UnityEngine;

namespace Game.Сharacter
{
	public class Enemy : Сharacter
	{
		private Tween tween;

		protected override void OnAwake()
		{
			tween = transform.DOMove(FindObjectOfType<Lake>().Position, 10f)
				.SetEase(Ease.Linear);
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
			tween?.Kill();
		}

		private void Reset()
		{
			_view = GetComponentInChildren<СharacterView>();
		}
	}
}