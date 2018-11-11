using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class RaceTimer : MonoBehaviour
{

	public HitCheckpoints HitCheckpoints;
	public TimeSpan ElapsedTime;

	private void Start()
	{
		ElapsedTime = HitCheckpoints.RoundTime.Elapsed;
	}

	// Update is called once per frame
	private void Update ()
	{
		ElapsedTime = HitCheckpoints.RoundTime.Elapsed;
		ElapsedTime = HitCheckpoints.RoundTime.Elapsed.Add(TimeSpan.FromSeconds(5 * HitCheckpoints.WrongCheckpoints));
		GetComponent<Text>().text = ElapsedTime.ToString();
	}
}
