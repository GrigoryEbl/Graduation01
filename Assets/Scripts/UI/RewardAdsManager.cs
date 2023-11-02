using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
using UnityEngine.UI;

public class RewardAdsManager : MonoBehaviour
{
    public YandexGame sdk;

    public void AdButton()
    {
        sdk._RewardedShow(1);
    }
}
