using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aliments : MonoBehaviour {

    public enum AlimType
    {
        Fruit,
        Legumes
    }

    public enum TeamType
    {
        Red,
        Blue
    }

    public AlimType type;
    public TeamType teamtype;
    public int amountScored;
}
