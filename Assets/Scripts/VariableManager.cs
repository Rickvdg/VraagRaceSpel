using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VariableManager
{
	public static string Username { get; set; }
	private static readonly List<Score> Level1Score = new List<Score>();
	private static readonly List<Score> Level2Score = new List<Score>();

	public static List<Score> GetLevelHighscore(int level)
	{
		switch (level)
		{
			case 1:
				return Level1Score;
			case 2:
				return Level2Score;
			default:
				return null;
		}
	}

	public static List<Score> AddLevelHighscore(int level, string name, TimeSpan time)
	{
		switch (level)
		{
			case 1:
				Level1Score.Add(new Score(level, name, time));
				Debug.Log("Level 1 being added with " + Level1Score[Level1Score.Count - 1].Time + " -> " + Level1Score[Level1Score.Count - 1].Username);
				return Level1Score;
			case 2:
				Level2Score.Add(new Score(level, name, time));
				return Level2Score;
			default:
				return null;
		}
	}
}

public class Score
{
	public int Level { get; set; }
	public string Username { get; set; }
	public TimeSpan Time { get; set; }
	
	public Score(int level, string name, TimeSpan time)
	{
		Level = level;
		Username = name;
		Time = time;
	}
}
