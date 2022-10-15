﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Image Effects Ultra/Vignette", order = 1)]
public class VignetteEffect : BaseEffect
{
    [SerializeField]
    private float strength = 0.5f;

    [SerializeField]
    private float size = 0.75f;

    [SerializeField]
    private float falloff = 0.25f;

    // Find the Vignette shader source.
    public override void OnCreate()
    {
        baseMaterial = new Material(Resources.Load<Shader>("Shaders/Vignette"));
        baseMaterial.SetFloat("_Strength", strength);
        baseMaterial.SetFloat("_Size", size);
        baseMaterial.SetFloat("_Falloff", falloff);
    }

    public override void Render(RenderTexture src, RenderTexture dst)
    {
        Graphics.Blit(src, dst, baseMaterial);
    }
}
