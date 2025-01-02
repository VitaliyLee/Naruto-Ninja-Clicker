using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumController : MonoBehaviour
{
    [SerializeField] private UpgradeSystem upgradeSystem;
    [SerializeField] private List<AudioSource> audioSources;
    [SerializeField] private List<GameObject> volumeImages;

    public void VolumeOnOff()
    {
        upgradeSystem.bySounds[0].mute = !upgradeSystem.bySounds[0].mute;
        upgradeSystem.bySounds[1].mute = !upgradeSystem.bySounds[1].mute;

        for (int i = 0; i < audioSources.Count; i++)
            audioSources[i].mute = !audioSources[i].mute;

        foreach (GameObject volumeImage in volumeImages)
            volumeImage.SetActive(!volumeImage.activeSelf);
    }
}
