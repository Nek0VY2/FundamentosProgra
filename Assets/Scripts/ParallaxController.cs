using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField]
    List<ParallaxLayers> parallaxLayersList = new List<ParallaxLayers>(); //lista de layers
    public ParallaxCamera parallaxCamera;

    void Start()
    {
        if (parallaxCamera == null)
            parallaxCamera = Camera.main.GetComponent<ParallaxCamera>();

        if(parallaxCamera != null)
        {
            parallaxCamera.onCameraTranslateX += MoveX;
            parallaxCamera.onCameraTranslateY += MoveY;
        }

        GetLayers();
    }

    private void MoveX(float delta)
    {
        foreach (ParallaxLayers layer in parallaxLayersList) //foreach para no alterar los datos, si no activar algo.
        {
            if(layer != null)
            {
                layer.MoveX(delta);
            }
        }
    }

    private void MoveY(float delta)
    {
        foreach (ParallaxLayers layer in parallaxLayersList) //foreach para no alterar los datos, si no activar algo.
        {
            if (layer != null)
            {
                layer.MoveY(delta);
            }
        }
    }

    private void GetLayers()
    {
        parallaxLayersList.Clear();
        for(int i = 0; i< transform.childCount; i++)
        {
            ParallaxLayers layer = transform.GetChild(i).GetComponent<ParallaxLayers>();
            if (layer != null)
                parallaxLayersList.Add(layer);
        }
    }
}
