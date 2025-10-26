using UnityEngine;

public class LayerBase
{
    public static int LayerMaskToLayer(LayerMask layerMask)
    {
        return (int)Mathf.Log(layerMask.value, 2);
    }
}