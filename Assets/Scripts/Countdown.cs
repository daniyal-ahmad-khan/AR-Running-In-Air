using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public int countdown;
    public Text Display;

    void Start(){
        StartCoroutine(cstart());
    }
    // Update is called once per frame
        IEnumerator cstart(){
            while(countdown > 0){
                Display.text = countdown.ToString();
                yield return new WaitForSeconds(2.5f);
                countdown--;
            }      
        Display.text = "GO !!!";
        yield return new WaitForSeconds(1f);
        PlayerManager.isGameStarted = true;
        
    }

}
