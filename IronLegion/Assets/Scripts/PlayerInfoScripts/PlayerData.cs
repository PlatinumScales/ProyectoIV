﻿using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
public class PlayerData {
	public string playerName;
	public int skinID;
	public int mission;
	public string date;
}
