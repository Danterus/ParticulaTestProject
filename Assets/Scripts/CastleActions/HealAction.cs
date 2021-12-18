using UnityEngine;

[CreateAssetMenu(fileName = "Heal Action",menuName = "Create Castle Action/Heal action")]
public class HealAction : CastleAction
{
    public override void TriggerAction(Castle target, int val)
    {
        target.GetComponent<HealthController>().Heal(val);
    }
}
