using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName="Novo Modelo", menuName="Novo Modelo")]
public class EntityScriptable : ScriptableObject {

    public int ID;
    public string realName;
    
    [TextArea(6, 10)]
    public string description;

    [TextArea(1, 2)]
    public string quickDescription;

    public GameObject model;

}
