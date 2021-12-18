using UnityEngine;

[CreateAssetMenu(fileName = "Armor Action",menuName = "Create Castle Action/Armor action")]
public class ArmorAction : CastleAction
{
    public override void TriggerAction(Castle target, int val)
    {
        target.GetComponent<ArmorController>()?.GainArmor(val);
    }
}
