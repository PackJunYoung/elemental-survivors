using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager Instance { get; private set; }

    public void Init()
    {
        Instance = this;
    }

    public SkillItem GenerateSkillItem(SkillType skillType, Transform parent)
    {
        var prefab = Resources.Load<GameObject>($"Skills/{skillType.ToString().ToLower()}");
        var go = Instantiate(prefab, parent);

        return go.GetComponent<SkillItem>();
    }

    public SkillProjectile GenerateSkillProjectile(SkillType skillType, Vector3 position)
    {
        var prefab = Resources.Load<GameObject>($"Skills/{skillType.ToString().ToLower()}Projectile");
        var go = Instantiate(prefab);
        go.transform.position = position;

        return go.GetComponent<SkillProjectile>();
    }

    public void RemoveSkillProjectile(SkillProjectile skillProjectile)
    {
        Destroy(skillProjectile.gameObject);
    }
}
