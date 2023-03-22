using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue 
{
    public string name;
    [TextArea(3, 10)]
    public string[] sentences;
    //public stringS[] sentences;


}
public class stringS
{
    public string sentence;
    public string waitingForReply;
}
