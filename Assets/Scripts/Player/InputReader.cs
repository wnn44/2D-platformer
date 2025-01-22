using UnityEngine;

public class InputReader : MonoBehaviour
{
    private bool _activateVampirism;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
            _activateVampirism = true;
    }

    public bool GetIsVampirism() => GetBoolAsTrigger(ref _activateVampirism);

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;
        return localValue;
    }
}
