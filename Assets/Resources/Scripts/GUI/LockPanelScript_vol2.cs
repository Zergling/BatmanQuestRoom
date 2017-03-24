using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO.Ports;
using System.IO;

public class LockPanelScript_vol2 : MonoBehaviour
{
    public Sprite[] Sprites;
    public Image[] Images;
    public Image[] Selectors;

    public GameObject grantedCanvas;
    public GameObject deniedCanvas;

    public Sprite defaultImage;

    private string codeString;
    private bool isTrue;
    int index;

    int[] code;

    public delegate void PasswordEnter();
    public static event PasswordEnter OnPasswordEnterEvent;

    void OnEnable()
    {
        SetDefaultState();
        Start();
    }

    void SetDefaultState()
    {
        for (int i = 0; i < Images.Length; i++)
        {
            Images[i].overrideSprite = defaultImage;
            Images[i].color = Color.black;
        }
            
    }

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
        }
	}


    public void Confirm()
    {
        string thisCode = "";
        for (int i = 0; i < 4; i++)
        {
            thisCode += code[i].ToString();
        }

        gameObject.SetActive(false);

        if (isTrue == true)
        {
            Debug.Log("TRUE TERMINAL");
            // make a signal
            Debug.Log(thisCode + "  " + codeString);
            if (thisCode.ToLower().Equals(codeString.ToLower()))
            {
                Debug.Log("SIGNAL TO USB PORT");
                Arduino_script.Instance.WriteToArduino("OPEN");
                grantedCanvas.SetActive(true);
            }
        }
        else
        {
            // else - nothing to do here;
            Debug.Log("NO SIGNAL");
            deniedCanvas.SetActive(true);
        }

        if (OnPasswordEnterEvent != null)
            OnPasswordEnterEvent();
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
        Images[index].overrideSprite = Sprites[code[index]];
        
    }



    void Dec(int index)
    {
        code[index]--;
        if (code[index] < 0)
        {
            code[index] = 4;
        }
        Images[index].color = Color.white;
        Images[index].overrideSprite = Sprites[code[index]];
    }



    public void SetCodeString(string tCodeString)
    {
        codeString = tCodeString;
    }

    public void SetTrue(bool tIsTrue)
    {
        isTrue = tIsTrue;
    }


}
