using Handler;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _points = default;
	[SerializeField] private TextMeshProUGUI _level = default;

	private PlayerProgressHandler _victoryPointsHandler;

	private void Awake()
	{
		_victoryPointsHandler = FindObjectOfType<PlayerProgressHandler>();
		_victoryPointsHandler.OnChanges += OnPointChanged;
		_victoryPointsHandler.OnLevelChanges += OnLevelChanged;
	}

	private void OnPointChanged(int value)
	{
		if (value < 0)
			return;

		_points.SetText(value.ToString());
	}

	private void OnLevelChanged(int value)
	{
		_level.SetText(value.ToString());
	}

	private void OnDestroy()
	{
		_victoryPointsHandler.OnChanges -= OnPointChanged;
		_victoryPointsHandler.OnLevelChanges -= OnLevelChanged;
	}
}