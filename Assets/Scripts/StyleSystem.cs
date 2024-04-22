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

    private void Start()
    {
       
    }
    private void OnEnable()
    {
        ChangeColor(2);
    }
    public void ChangeColor(int id)
    {
        Debug.Log(id);
        if (textos != null)
        {
            for (int i = 0; i < textos.Length; i++)
            {
                textos[i].color = PaletasColores[id].colors[0];
            }
        }
        if (botones != null)
        {
            for (int i = 0; i < botones.Length; i++)
            {
                botones[i].image.color = PaletasColores[id].colors[0];
            }
        }
        if (paneles != null)
        {
            for (int i = 0; i < paneles.Length; i++)
            {
                paneles[i].GetComponent<Image>().color = PaletasColores[id].colors[0];
            }
        }
    }
}
