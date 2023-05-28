using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBarUI : MonoBehaviour
{
	public GameObject spawnLocation;

	[SerializeField]
	private int hireCost = 1000;

	[SerializeField]
	[Tooltip("How often, in seconds, the player can hire another worker")]
	private float hireRate = 1f;

	private float nextHire = 0f;

	public void HireButtonPressed(Worker prefab)
	{
		if(Time.time < nextHire)
		{
			return;
		}

		//Check funds
		if (GameState.Money.Subtract(hireCost))
		{
			var workerMovement = Instantiate(prefab, spawnLocation.transform);
			workerMovement.Init();

			nextHire = Time.time + hireRate;
		}
	}
}
