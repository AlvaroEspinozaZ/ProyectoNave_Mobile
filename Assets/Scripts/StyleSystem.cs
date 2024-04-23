using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StyleSystem : MonoBehaviour
{
    [SerializeField] Text[] textos;
    [SerializeField] Button[] botones;
    [SerializeField] GameObject[] paneles;
    [SerializeField] Colors_SO[] PaletasColores;
    [SerializeField] GlobalValues_SO idC;

    private void Start()
    {
       
    }
    private void OnEnable()
    {
        ChangeColor(idC.scoreGlobal);
    }
    public void ChangeColor(int id)
    {
        Debug.Log(id);
        idC.scoreGlobal = id;
        if (textos != null)
        {
            for (int i = 0; i < textos.Length; i++)
            {
                textos[i].color = PaletasColores[idC.scoreGlobal].colors[0];
            }
        }
        if (botones != null)
        {
            for (int i = 0; i < botones.Length; i++)
            {
                botones[i].image.color = PaletasColores[idC.scoreGlobal].colors[0];
            }
        }
        if (paneles != null)
        {
            for (int i = 0; i < paneles.Length; i++)
            {
                paneles[i].GetComponent<Image>().color = PaletasColores[idC.scoreGlobal].colors[0];
            }
        }
    }
}
