using DG.Tweening;
using UnityEngine;

namespace Game.Character
{
	public class Miniplayer : Character
	{
		[SerializeField] private float _shakeValue = default;
		[SerializeField] private float _shakeDuration = default;
		[SerializeField] private float _rotationDuration = default;

		public void Excite()
		{
			transform.DOShakePosition(_shakeDuration, _shakeValue, 0)
				.SetLoops(-1);
		}

		public void Rotate()
		{
			transform.DORotate(new Vector3(0, 360, 0), _rotationDuration, RotateMode.FastBeyond360)
					   .SetEase(Ease.Linear)
					   .SetLoops(-1);
		}
	}
}