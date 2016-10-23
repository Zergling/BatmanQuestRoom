using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO.Ports;
using System.IO;

public class LockPanelScript : MonoBehaviour
{
    #region Unity scene setting
    [SerializeField]
    private Sprite[] Sprites;
    #endregion

    #region Unity scene setting
    [SerializeField]
    private Image[] Images;
    #endregion

    public Canvas grantedCanvas;
    public Canvas deniedCanvas;

    private string codeString;
    private bool isTrue;

    int[] code;

    SerialPort stream;

    public static string LOCK_CANVAS_TAG = "_LockCanvas";

    // Use this for initialization
    void Start ()
    {
        code = new int[4];
        for (int i = 0; i < 4; i++)
        {
            code[i] = -1;
        }

        stream = new SerialPort("COM3", 9600);
        stream.ReadTimeout = 50;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void WriteToArduino(string message)
    {
        try
        {
            stream.Open();
            stream.WriteLine(message);
            stream.BaseStream.Flush();
            stream.Close();
        }
        catch(IOException e)
        {
            Debug.Log("ERR");
        }
    }

    public void Inc(int index)
    {
        code[index]++;
        if (code[index] > 4)
        {
            code[index] = 0;
        }
        Images[index].sprite = Sprites[code[index]];
    }

    public void Dec(int index)
    {
        code[index]--;
        if (code[index] < 0)
        {
            code[index] = 4;
        }
        Images[index].sprite = Sprites[code[index]];
    }

    public void SetCodeString(string tCodeString)
    {
        codeString = tCodeString;
    }

    public void SetTrue(bool tIsTrue)
    {
        isTrue = tIsTrue;
    }

    public void Confirm()
    {
        string thisCode = "";
        for (int i = 0; i < 4; i++)
        {
            thisCode += code[i].ToString();
        }

        GameObject.Destroy(gameObject);

        if (isTrue == true)
        {
            Debug.Log("TRUE TERMINAL");
            // make a signal
            Debug.Log(thisCode + "  " + codeString);
            if (thisCode.ToLower().Equals(codeString.ToLower()))
            {
                Debug.Log("SIGNAL TO USB PORT");
                WriteToArduino("RIGHT");
                Instantiate(grantedCanvas);
                return;
            }
        }

        // else - nothing to do here;
        Debug.Log("NO SIGNAL");
        WriteToArduino("WRONG");
        Instantiate(deniedCanvas);
    }
}
