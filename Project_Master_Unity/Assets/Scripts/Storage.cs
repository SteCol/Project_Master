using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    [Header("World Stuff")]
    public Worlds activeWorld;
    public Worlds checkWorld;


    

}

public enum Worlds
{
    Human,
    Wolf
}