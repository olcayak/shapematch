using Lofelt.NiceVibrations;


public class VibrationController : MonoSingleton<VibrationController>
{
    public void Vibrate(HapticPatterns.PresetType haptic)
    {
        if (DataHandler.instance.isVibrate == true)
        {
            HapticPatterns.PlayPreset(haptic);
        }
    }
}
