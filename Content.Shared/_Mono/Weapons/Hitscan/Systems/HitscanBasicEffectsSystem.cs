// SPDX-FileCopyrightText: 2025 beck-thompson
//
// SPDX-License-Identifier: MIT

using Content.Shared.Damage;
using Content.Shared.Effects;
using Content.Shared._Mono.Weapons.Hitscan.Components;
using Content.Shared._Mono.Weapons.Hitscan.Events;
using Content.Shared.Weapons.Ranged.Systems;
using Robust.Shared.Player;

namespace Content.Shared._Mono.Weapons.Hitscan.Systems;

public sealed class HitscanBasicEffectsSystem : EntitySystem
{
    [Dependency] private readonly SharedColorFlashEffectSystem _color = default!;
    [Dependency] private readonly SharedGunSystem _gun = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<HitscanBasicEffectsComponent, HitscanDamageDealtEvent>(OnHitscanDamageDealt);
    }

    private void OnHitscanDamageDealt(Entity<HitscanBasicEffectsComponent> ent, ref HitscanDamageDealtEvent args)
    {
        if (Deleted(args.Target))
            return;

        if (ent.Comp.HitColor != null && args.DamageDealt.GetTotal() != 0)
        {
            _color.RaiseEffect(ent.Comp.HitColor.Value,
                new List<EntityUid> { args.Target },
                Filter.Pvs(args.Target, entityManager: EntityManager));
        }

        _gun.PlayImpactSound(args.Target, args.DamageDealt, ent.Comp.Sound, ent.Comp.ForceSound);
    }
}
