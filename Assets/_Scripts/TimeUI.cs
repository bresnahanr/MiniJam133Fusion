using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/** 
 * TimeUI
 * 
 * A Unity class that updates the Time and Date elements on the UI canvas.
 * Displayed time and day displayed correlates to the TimeController class tick system.
 * 
 * Example Usage:
 * 1. Attach this script to a GameObject such as the canvas in your Unity scene.
 * 2. Drag the "Time" TextMeshPro object from the hierarchy and drop it in the inspector.
 * 3. Do the same for the "Date" TextMeshPro object.
**/

public class TimeUI : MonoBehaviour
{
    public TMP_Text timeText;
    public TMP_Text dateText;

	// Update the text before subscriber events take place
	private void Start()
	{
		UpdateTime();
		UpdateDay();
	}

	private void OnEnable()
	{
		TimeController.OnMinuteChanged += UpdateTime;
		TimeController.OnDayChanged += UpdateDay;
	}

	private void OnDisable()
	{
		TimeController.OnMinuteChanged -= UpdateTime;
		TimeController.OnDayChanged -= UpdateDay;
	}

	private void UpdateTime()
	{
		// Displays in scene as "00:00"
		timeText.text = $"{TimeController.Hour:00}:{TimeController.Minute:00}";
	}

	private void UpdateDay()
	{
		// Displays in UI as "Day: 0"
		dateText.text = $"Day: {TimeController.Day}";
	}
}
