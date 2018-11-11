using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class countdownTimer : MonoBehaviour {

	public float timeLeft = 3.0f;
	public Text countdownText;
	
	void Update()
	{
		timeLeft -= Time.deltaTime;
		countdownText.text = Mathf.Ceil(timeLeft).ToString();
		if (timeLeft < 0.0f)
		{
			gameObject.GetComponent<HitCheckpoints>().RoundTime.Start();
			countdownText.gameObject.SetActive(false);
		}
	}
}
