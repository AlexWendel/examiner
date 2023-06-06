using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectorEntity : MonoBehaviour
{

    public string name;
    public string description;
    public GameObject model;
    public EntityScriptable entityData;

    void Awake(){
        name = entityData.name;
        description = entityData.description;
        model = entityData.model;
    }

}
