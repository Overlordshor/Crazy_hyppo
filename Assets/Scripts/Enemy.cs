using DG.Tweening;
using UnityEngine;

namespace Game
{
	public class Enemy : MonoBehaviour
	{
		private Tween tween;

		private void Awake()
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
	}
}