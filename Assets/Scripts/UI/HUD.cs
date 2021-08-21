using Handler;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _points = default;
	[SerializeField] private TextMeshProUGUI _level = default;

	private VictoryPointsHandler _victoryPointsHandler;

	private void Start()
	{
		_victoryPointsHandler = FindObjectOfType<VictoryPointsHandler>();
		_victoryPointsHandler.OnChanges += OnPointChanged;
		_victoryPointsHandler.OnLevelChanges += OnLevelChanged;
	}

	private void OnPointChanged(int value)
	{
		_points.SetText(value.ToString());
	}

	private void OnLevelChanged(int value)
	{
		_level.SetText(value.ToString());
	}
}