using UnityEngine;

namespace Game.Character.View
{
	public class CharacterView : MonoBehaviour
	{
		[SerializeField] private Sprite _sprite;
		private SpriteRenderer _view;

		private void Awake()
		{
			_view = GetComponentInChildren<SpriteRenderer>();

			if (_sprite != null)
				_view.sprite = _sprite;
		}
	}
}