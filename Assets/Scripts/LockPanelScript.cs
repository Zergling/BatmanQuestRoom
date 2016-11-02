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
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void WriteToArduino(string message)
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
        Instantiate(deniedCanvas);
    }
}
