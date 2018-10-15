﻿using System;
using System.Collections;
using System.Net;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Runtime.InteropServices;

public class testmid : MonoBehaviour {

	private static readonly string sAlias = "TeaTimerAudio";
	private string sFile=@"D:\interplaytions\Assets\test.mid";
	[DllImport("winmm.dll")]

	private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);
	[DllImport("Winmm.dll")]
	private static extern long PlaySound(byte[] data, IntPtr hMod, UInt32 dwFlags);

	public void Play()
	{
		_Open(sFile);
		_Play();
	}
	public void Stop()
	{
		_Close();
	}

	private void _Open(string sFileName)
	{
		if (_Status() != "")
			_Close();

		string sCommand = "open \"" + sFileName + "\" alias " + sAlias;
		mciSendString(sCommand, null, 0, IntPtr.Zero);
	}

	private void _Close()
	{
		string sCommand = "close " + sAlias;
		mciSendString(sCommand, null, 0, IntPtr.Zero);
	}

	private void _Play()
	{
		string sCommand = "play " + sAlias;
		mciSendString(sCommand, null, 0, IntPtr.Zero);
	}

	private string _Status()
	{
		StringBuilder sBuffer = new StringBuilder(128);
		mciSendString("status " + sAlias + " mode", sBuffer, sBuffer.Capacity, IntPtr.Zero);
		return sBuffer.ToString();
	}
}
