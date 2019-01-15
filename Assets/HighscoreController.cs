using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreController : MonoBehaviour
{
	private List<Score> TrackTimes;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateHighscore()
	{
		Text text = transform.parent.GetComponent<Text>();
		text.text = "Highscore: ";
		if (TrackTimes.Count > 1)
		{
			List<Score> sortedList = TrackTimes.OrderBy(x => x.Time).ToList();
			text.text += "1. " + sortedList[0].Name.Substring(0, 3) + "		" + sortedList[0].Time;
			if (TrackTimes.Count >= 2)
			{
				text.text += "2. " + sortedList[1].Name.Substring(0, 3) + "		" + sortedList[1].Time;
			}
			if (TrackTimes.Count >= 3)
			{
				text.text += "3. " + sortedList[2].Name.Substring(0, 3) + "		" + sortedList[2].Time;
			}
		}
	}

	public void AddScore(string name, TimeSpan time)
	{
		TrackTimes.Add(new Score(name, time));
		UpdateHighscore();
	}
}

public class Score
{
	public string Name { get; set; }
	public TimeSpan Time { get; set; }

	public Score(string name, TimeSpan time)
	{
		Name = name;
		Time = time;
	}
}