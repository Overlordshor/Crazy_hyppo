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
		[SerializeField] private int _maxLanuchCount = default;

		private PlayerProgressHandler _playerProgress;
		private RebornHandler _rebornHandler;

		private Tween _rotateRightTween;
		private Tween _rotateLeftTween;
		private Tween _lanuchTween;
		private Tween _rebornTween;
		private Vector3 _startPosition;

		private int _lanuchCount = 0;

		public bool IsLaunched => _lanuchTween.IsActive() && gameObject.activeSelf;
		public bool IsSecondJumpAvailable => _lanuchCount < _maxLanuchCount;

		public bool IsRotated => _rotateRightTween.IsActive() || _rotateLeftTween.IsActive();

		protected override void OnAwake()
		{
			_rebornHandler = GetComponent<RebornHandler>();

			_startPosition = _rigidbody.position;

			_view.PlayAngry();
		}

		private void Start()
		{
			_playerProgress = FindObjectOfType<PlayerProgressHandler>();
		}

		public void Launch()
		{
			if (!_playerProgress.IsRunnig)
				return;

			TryKillTweens();

			_lanuchCount++;
			_lanuchTween = _rigidbody
				.DOMove(transform.forward * _launchPower, _launchDuration)
				.SetRelative()
				.OnComplete(() => MissHit());
		}

		public void RotateRigth() => Rotate(Direction.Right);

		public void RotateLeft() => Rotate(Direction.Left);

		private void Rotate(Direction direction)
		{
			if (!_playerProgress.IsRunnig)
				return;

			TryKillTweens();

			_view.StopEmoji();

			_rotateLeftTween = _rigidbody.DORotate(new Vector3(0, (float)direction, 0), _rotationDuration, RotateMode.FastBeyond360)
					.SetEase(Ease.Linear)
					.SetRelative()
					.SetLoops(-1);
		}

		private void MissHit()
		{
			gameObject.SetActive(false);

			TryKillTweens();

			_rebornTween = DOVirtual.DelayedCall(_timeToReborn, () =>
			{
				_rebornHandler.RebornPlayer();

				ResetToStartPosition();
			});
		}

		private void ResetToStartPosition()
		{
			_lanuchCount = 0;
			_rigidbody.position = _startPosition;
			_rigidbody.velocity = Vector3.zero;
			_rigidbody.angularVelocity = Vector3.zero;

			if (_playerProgress.IsRunnig)
				_view.PlayAngry();
		}

		private void OnCollisionEnter(Collision collision)
		{
			if (!collision.gameObject.CompareTag("Enemy"))
				return;

			var enemy = collision.gameObject.GetComponent<Enemy>();

			_playerProgress.Add(enemy.PointsValue);
			enemy.ApplyDamage();
			_view.PlayKick();

			TryKillTweens();
			ResetToStartPosition();
		}

		private void OnDestroy()
		{
			TryKillTweens();
		}

		private void TryKillTweens()
		{
			_rotateRightTween?.Kill();
			_rotateLeftTween?.Kill();
			_lanuchTween?.Kill();
			_rebornTween?.Kill();
		}

		private enum Direction
		{
			None,
			Left = -360,
			Right = 360
		}
	}
}