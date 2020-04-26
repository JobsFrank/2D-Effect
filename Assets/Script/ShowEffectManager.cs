using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEffectManager : MonoBehaviour {

    public Material[] materialArray;
    private Material selfMaterial;
    private float horizontalValue = 0;
    private string[] effectName = {"Blur", "BlurSharpen", "Circle", "Emboss", "Fade", "Flash", "Gray", "Mosaic",
                                   "OldPhoto", "Pencil", "RadialBlur", "RoundRect", "Saturation", "SectorWarp",
                                   "WaterColor", "WaterRipple","Wave"};
    private Dictionary<string, bool> effectDic = new Dictionary<string, bool>();
    // Use this for initialization
    void Start ()
    {
        MeshRenderer rend = GetComponent<MeshRenderer>();
        selfMaterial = rend.material;
        for(int i=0;i<effectName.Length;i++)
        {
            if (!effectDic.ContainsKey(effectName[i]))
                effectDic.Add(effectName[i],false);
        }
    }
	// Update is called once per frame
	void Update ()
    {
        for (int i = 0; i < effectName.Length; i++)
        {
            if (effectDic[effectName[i]] && materialArray[i].name != selfMaterial.name)
            {
                GetComponent<MeshRenderer>().material = materialArray[i];
                selfMaterial.name = materialArray[i].name;
            }
        }
    }
    void OnGUI()
    {
        for (int i = 0; i < effectName.Length; i++)
        {
            if (effectDic.ContainsKey(effectName[i]))
            {
                effectDic[effectName[i]] = GUI.Toggle(new Rect(10, i*20, 80, 20), effectDic[effectName[i]], effectName[i]);
                if (effectDic[effectName[i]])
                {
                    for (int j = 0; j < effectName.Length; j++)
                    {
                        if (effectName[i] != effectName[j])
                            effectDic[effectName[j]] = false;
                    }
                }
            }
        }
    }
}
