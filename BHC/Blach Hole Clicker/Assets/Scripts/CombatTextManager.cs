using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CombatTextManager : MonoBehaviour {

    private static CombatTextManager instance;
    public GameObject clickEffectText;
    public RectTransform canvasTransform;
    public float speed;
    public float fadeTime;
    public Vector3 direction;
     
    public static CombatTextManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<CombatTextManager>();
            }
            return instance;
        }
    }

    public IEnumerator createText(Vector3 position, Quaternion rotation, string text, Color color, bool crit)
    {
        // move text above reference to be better visible
        position.Set(position.x, position.y + 2, position.z);
        
       GameObject sct = (GameObject) Instantiate(clickEffectText,position, rotation);
        sct.transform.SetParent(canvasTransform);

        sct.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        
        sct.GetComponent<CombatText>().Initialize(speed, direction, fadeTime, crit);
        sct.GetComponent<Text>().text = text;
        sct.GetComponent<Text>().color = color;
        yield return null;

    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
