using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;
using System.IO;
using System;

public class Arduino_script
{
    //singleton
    private static Arduino_script instance_ = null;

    public static Arduino_script Instance
    {
        get
        {
            if (instance_ == null)
                instance_ = new Arduino_script();

            return instance_;
        }
    }

    static private bool isConnected = false;
    static private SerialPort stream;
    static private int timeout = 100;

    public void ConnectToArduino()
    {
        Debug.Log("Connecting");
        OpenStream();
    }

    public string ReadFromArduino(int timeout)
    {
        if (isConnected == false)
        {
            Debug.Log("Arduino not connected");
            return null;
        }

        stream.ReadTimeout = timeout;
        try
        {
            return stream.ReadLine();
        }
        catch (TimeoutException)
        {
            return null;
        }
    }

    public void WriteToArduino(string message)
    {
        if (isConnected == false)
        {
            Debug.Log("Arduino not connected");
            return;
        }

        Debug.Log("Writing: " + message);
        stream.WriteLine(message);
        stream.BaseStream.Flush();
    }

    public void OpenStream()
    {
        if (isConnected == true)
        {
            Debug.Log("Arduino already connected");
            return;
        }

        string com = "COM4";

        stream = new SerialPort(com, 9600);
        stream.ReadTimeout = timeout;

        try
        {
            stream.Open();
        }
        catch(IOException e)
        {
            Debug.Log(e.Message);
        }

        Debug.Log("Stream opened");
        isConnected = true;
    }

    public void CloseStream()
    {
        if (isConnected == false)
        {
            Debug.Log("Arduino not connected");
            return;
        }

        Debug.Log("Close");
        WriteToArduino("CLOSE");
        isConnected = false;
        //stream.Close();
    }
}

/*
 * SerialPort stream
 * 
 *   void WriteToArduino(string message)
    {

        string comName = "COM";
        int comNum = 2;
        bool flag = true;

        Debug.Log("Ok");

        while(flag)
        {
            try
            {
                comName = comName.Insert(3, comNum.ToString());
                stream = new SerialPort(comName, 9600);
                stream.ReadTimeout = 50;
                Debug.Log(comName);
                stream.Open();
                stream.WriteLine(message);
                stream.BaseStream.Flush();
                stream.Close();
                flag = false;
                Debug.Log("We are cool");
            }
            catch(IOException e)
            {
                Debug.Log("ERR: no port open or write error");
                comNum++;
                if (comNum > 10)
                {
                    Debug.Log("ERR: no such COM port");
                    return;
                }
                comName = comName.Substring(0, comName.Length - 1);
            }
        }
    }
 */
