using UnityEngine;

namespace Game.Сharacter.View
{
	public class СharacterView : MonoBehaviour
	{
		[SerializeField] private Sprite _sprite;
		[SerializeField] private SpriteRenderer _view;

		private void Awake()
		{
			_view.sprite = _sprite;
		}
	}
}