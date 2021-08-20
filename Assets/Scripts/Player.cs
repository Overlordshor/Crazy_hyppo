using DG.Tweening;
using UnityEngine;

namespace Game
{
	public class Player : MonoBehaviour
	{
		[SerializeField] private float _rotationDuration;
		[SerializeField] private float _launchPower;
		[SerializeField] private float _launchDuration;

		private Tween _rotateTween;
		private Tween _lanuchTween;
		private Vector3 _startPosition;

		private void Awake()
		{
			_startPosition = transform.position;

			_rotateTween = transform.DORotate(new Vector3(0, 360, 0), _rotationDuration, RotateMode.FastBeyond360)
						.SetEase(Ease.Linear)
						.SetLoops(-1)
						.Pause();
		}

		public void Launch()
		{
			_rotateTween.Pause();
			_lanuchTween = transform.DOMove(transform.forward * _launchPower, 1f)
				.OnComplete(() => ResetToStartPosition());
		}

		public void Rotate()
		{
			_rotateTween.Play();
		}

		private void ResetToStartPosition()
		{
			transform.position = _startPosition;
		}

		private void OnCollisionEnter(Collision collision)
		{
			if (!collision.gameObject.TryGetComponent<Enemy>(out var enemy))
				return;

			enemy.ApplyDamage();
			Debug.Log("HIT");

			_lanuchTween.Kill();
			ResetToStartPosition();
		}
	}
}