using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LockPanelScript : MonoBehaviour
{
    #region Unity scene setting
    [SerializeField]
    private Text[] TextFields;
    #endregion

    private string codeString;
    private bool isTrue;

    int[] code;

    public static string LOCK_CANVAS_TAG = "_LockCanvas";

    // Use this for initialization
    void Start ()
    {
        code = new int[4];
        for (int i = 0; i < 4; i++)
        {
            code[i] = 0;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void Inc(int index)
    {
        code[index]++;
        if (code[index] > 9)
        {
            code[index] = 0;
        }
        TextFields[index].text = code[index].ToString();
    }

    public void Dec(int index)
    {
        code[index]--;
        if (code[index] < 0)
        {
            code[index] = 9;
        }
        TextFields[index].text = code[index].ToString();
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
        for (int i = 0; i < TextFields.Length; i++)
        {
            thisCode += TextFields[i].text;
        }

        GameObject.Destroy(gameObject);

        if (isTrue == true)
        {
            Debug.Log("TRUE TERMINAL");
            // make a signal
            if (thisCode.ToLower().Equals(codeString.ToLower()))
            {
                Debug.Log("SIGNAL TO USB PORT");
                return;
            }
        }

        // else - nothing to do here;
        Debug.Log("NO SIGNAL");
    }
}
