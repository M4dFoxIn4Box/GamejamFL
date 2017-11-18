using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aliments : MonoBehaviour {

    public enum AlimType
    {
        Fruit,
        Legumes
    }

    public AlimType type;
    public int amountScored;
}
