using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/**
 * TimeController
 * 
 * A Unity class that provides a time ticking system.
 * 
 * This class allows you to create a ticking system with a specified interval between ticks.
 * Implements the Observer design pattern to enable subscriber classes to trigger at certain time events.
 * 
 * Example Usage:
 * 1. Attach this script to a GameObject in your Unity scene.
 * 2. Set the desired tick interval using the "minuteToRealTime" variable.
 * 3. Implement your desired trigger function by subscribing in another class using "OnIntervalChanged += TriggerFunction"
 * 4. Be sure to unsubscribe in the same class using "OnIntervalChanged -= TriggerFunction"
**/

public class TimeController : MonoBehaviour
{
    public static Action OnMinuteChanged;
    public static Action OnHourChanged;
    public static Action OnDayChanged;

    public static int Minute { get; private set; }
    public static int Hour { get; private set; }
    public static int Day { get; private set; }

    [SerializeField]
    [Tooltip("Speed at which one in game minute passes in seconds.  The lower the number the faster time passes")]
    private float minuteToRealTime = 0.5f;
    private float timer;


    // Start is called before the first frame update
    void Start()
    {
        Minute = 0;
        Hour = 0;
        Day = 0;
        timer = minuteToRealTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        // One minute has passed
        if( timer <= 0)
		{
            Minute++;

            // One hour has passed
            if( Minute >= 60 )
			{
                Hour++;
                Minute = 0;

                // One day has passed
                if( Hour >= 24 )
				{
                    Day++;
                    Hour = 0;

                    OnDayChanged?.Invoke();
				}

                OnHourChanged?.Invoke();
			}

            OnMinuteChanged?.Invoke();

            //Timer reset
            timer = minuteToRealTime;
		}
    }
}
