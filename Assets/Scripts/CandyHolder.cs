using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

public class CandyHolder : MonoBehaviour {
    const int DefaultCandyAmount = 30;
    const int RecoverSeconds = 10;

    public int candy {
        get;
        internal set;
    } = DefaultCandyAmount;
    int counter;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (candy < DefaultCandyAmount && counter <= 0) {
            StartCoroutine(RecoverCandy());
        }
    }

    private IEnumerator RecoverCandy() {
        counter = RecoverSeconds; 
        while (counter > 0) {
            yield return new WaitForSeconds(1.0f);
            counter--;
        }
        candy++;
    }

    public void ConsumeCandy() {
        if (candy > 0) candy--;
    }

    public void AddCandy(int amount) {
        candy += amount;
    }

    void OnGUI() {
        GUI.color = Color.black;
        string label = "Candy: " + candy;
        if (counter > 0) label = label + " (" + counter + "s)";
        GUI.Label(new Rect(0, 0, 100, 30), label);
    }
}
