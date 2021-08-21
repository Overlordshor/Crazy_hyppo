using UnityEngine;

namespace Game.Character.View
{
	public class CharacterView : MonoBehaviour
	{
		[SerializeField] private Sprite _sprite;
		[SerializeField] private SpriteRenderer _view;

		private void Awake()
		{
			if (_sprite != null)
				_view.sprite = _sprite;
		}
	}
}