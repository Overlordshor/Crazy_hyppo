using DG.Tweening;
using Handler;
using UnityEngine;

namespace Game.Character
{
	[RequireComponent(typeof(RebornHandler))]
	public class Player : Character
	{
		[SerializeField] private float _rotationDuration = default;
		[SerializeField] private float _launchPower = default;
		[SerializeField] private float _launchDuration = default;
		[SerializeField] private float _timeToReborn = default;

		private PlayerProgressHandler _victoryPointsHandler;
		private RebornHandler _rebornHandler;

		private Tween _rotateTween;
		private Tween _lanuchTween;
		private Tween _rebornTween;
		private Vector3 _startPosition;

		public bool IsLaunched => _rigidbody.velocity.magnitude > 0 && gameObject.activeSelf;

		protected override void OnAwake()
		{
			_rebornHandler = GetComponent<RebornHandler>();

			_startPosition = transform.position;

			_rotateTween = transform.DORotate(new Vector3(0, 360, 0), _rotationDuration, RotateMode.FastBeyond360)
						.SetEase(Ease.Linear)
						.SetLoops(-1)
						.Pause();
		}

		private void Start()
		{
			_victoryPointsHandler = FindObjectOfType<PlayerProgressHandler>();
		}

		public void Launch()
		{
			_rotateTween.Pause();

			_lanuchTween = _rigidbody.DOMove(transform.forward * _launchPower, _launchDuration)
				.OnComplete(() => MissHit());
		}

		public void Rotate()
		{
			_rotateTween.Play();
		}

		private void MissHit()
		{
			gameObject.SetActive(false);

			_rebornTween = DOVirtual.DelayedCall(_timeToReborn, () =>
			{
				_rebornHandler.RebornPlayer();

				ResetToStartPosition();
			});
		}

		private void ResetToStartPosition()
		{
			_rigidbody.position = _startPosition;
			_rigidbody.velocity = Vector3.zero;
			_rigidbody.angularVelocity = Vector3.zero;
		}

		private void OnCollisionEnter(Collision collision)
		{
			if (!collision.gameObject.CompareTag("Enemy"))
				return;

			var enemy = collision.gameObject.GetComponent<Enemy>();

			_victoryPointsHandler.Add(enemy.PointsValue);
			enemy.ApplyDamage();
			Debug.Log("HIT");

			_lanuchTween.Pause();
			ResetToStartPosition();
		}

		private void OnDestroy()
		{
			_rotateTween?.Kill();
			_lanuchTween?.Kill();
			_rebornTween?.Kill();
		}
	}
}