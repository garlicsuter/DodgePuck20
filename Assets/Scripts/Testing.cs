using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public int score = 7;
    public int hiscore = 10;
    private int temp = 70;
    public float location;
    public float loc2 = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Hello, World!");
        score += 2;
        Debug.Log(score + hiscore + temp);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("D was pressed");
        }
    }
}
