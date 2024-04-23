using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
[CreateAssetMenu(fileName = "Notifs_SO", menuName = "ScriptableObject/Notifs_SO/NotificacionesNotis", order = 4)]
public class Notifs_SO : ScriptableObject
{
    public GlobalValues_SO _score;
    public string title;
    public string text ;
    public int fireTimeInHours=0;
    public string SmallIcon= "icon_0";
    public string LargeIcon= "icon_1";

    private void Awake()
    {
        if (_score != null)
        {
            text = text + _score.scoreGlobal;
        }
    }
}
