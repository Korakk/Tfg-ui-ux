using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LangSwap : MonoBehaviour
{

    public GameObject eng, esp, cat;
    public Transform flagIcons;
    private string flag;
    public string lang;

    // Start is called before the first frame update
    void Start()
    {
       this.flag = GameObject.FindWithTag("Lang").name;
        setLangCheck();
        Debug.Log(lang);
    }
        
    public void setLangCheck()
    {
        if(flag == "English Icon")
        {
            lang="ENG";
        } else if(flag == "Spanish Icon")
        {
            lang="ESP";
        } else if(flag == "Catalan Icon")
        {
            lang="CAT";
        }
    }
}
