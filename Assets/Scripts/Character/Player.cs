using DG.Tweening;
using Handler;
using UnityEngine;

namespace Game.Character
{
	public class Player : Character
	{
		[SerializeField] private float _rotationDuration;
		[SerializeField] private float _launchPower;
		[SerializeField] private float _launchDuration;

		private VictoryPointsHandler _victoryPointsHandler;
		private Tween _rotateTween;
		private Tween _lanuchTween;
		private Vector3 _startPosition;

		public bool IsLaunched => _rigidbody.velocity.magnitude > 0;

		protected override void OnAwake()
		{
			_startPosition = transform.position;

			_rotateTween = transform.DORotate(new Vector3(0, 360, 0), _rotationDuration, RotateMode.FastBeyond360)
						.SetEase(Ease.Linear)
						.SetLoops(-1)
						.Pause();
		}

		private void Start()
		{
			_victoryPointsHandler = FindObjectOfType<VictoryPointsHandler>();
		}

		public void Launch()
		{
			_rotateTween.Pause();

			_lanuchTween = _rigidbody.DOMove(transform.forward * _launchPower, _launchDuration)
				.OnComplete(() => ResetToStartPosition());
		}

		public void Rotate()
		{
			_rotateTween.Play();
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
	}
}