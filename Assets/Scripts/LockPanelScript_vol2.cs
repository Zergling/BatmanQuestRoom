using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO.Ports;
using System.IO;

public class LockPanelScript_vol2 : MonoBehaviour
{
    [SerializeField]
    private Sprite[] Sprites;

    [SerializeField]
    private Image[] Images;

    [SerializeField]
    private Image[] Selectors;

    public Canvas grantedCanvas;
    public Canvas deniedCanvas;
 

    private string codeString;
    private bool isTrue;
    int index;

    int[] code;

    SerialPort stream;
    GameObject player;

    public static string LOCK_CANVAS_TAG = "_LockCanvas";

    // Use this for initialization
    void Start ()
    {
        code = new int[4];
        for (int i = 0; i < 4; i++)
        {
            code[i] = -1;
        }
        index = 0;
        SetActiveSelector(index);
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            DecIndex();
            SetActiveSelector(index);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            IncIndex();
            SetActiveSelector(index);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Inc(index);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Dec(index);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Confirm();
            player.SendMessage("EnableMoving");
        }
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

    void IncIndex()
    {
        index++;
        if (index >= 4)
        {
            index = 0;
        }
    }

    void DecIndex()
    {
        index--;
        if (index < 0)
        {
            index = 3;
        }
    }

    void SetActiveSelector(int index)
    {
        for (int i = 0; i < Selectors.Length; i++)
        {
            if (i == index)
            {
                Selectors[i].color = new Color32(255, 255, 255, 100);
            }
            else
            {
                Selectors[i].color = Color.clear;
            }
        }
    }

    void Inc(int index)
    {
        code[index]++;
        if (code[index] > 4)
        {
            code[index] = 0;
        }
        Images[index].color = Color.white;
        Images[index].sprite = Sprites[code[index]];
        
    }

    void Dec(int index)
    {
        code[index]--;
        if (code[index] < 0)
        {
            code[index] = 4;
        }
        Images[index].color = Color.white;
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
