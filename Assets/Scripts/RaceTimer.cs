using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class RaceTimer : MonoBehaviour
{

	public HitCheckpoints HitCheckpoints;

	// Update is called once per frame
	private void Update ()
	{
		GetComponent<Text>().text = HitCheckpoints.RoundTime.Elapsed.Add(TimeSpan.FromSeconds(5 * HitCheckpoints.WrongCheckpoints)).ToString().Substring(3, 7);
	}
}
