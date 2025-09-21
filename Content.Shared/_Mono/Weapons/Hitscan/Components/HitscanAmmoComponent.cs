// SPDX-FileCopyrightText: 2025 beck-thompson
//
// SPDX-License-Identifier: MIT

using Content.Shared.Weapons.Ranged;
using Robust.Shared.GameStates;

namespace Content.Shared._Mono.Weapons.Hitscan.Components; 
//This is the first of many namespaces i had to move over to _Mono
//This is before i even had to update all files requesting that namespace
//For the record, MonoCoders, I hate you, I hope your dog barfs this christmas
//Also fuck you especially for putting stuff in main namespace, especially BitCrushing, please help a sister out just put it in a namespace :pray:
//-ShieldAcrados

/// <summary>
/// This component is used to indicate an entity is shootable from a hitscan weapon.
/// This is placed on the laser entity being shot, not the gun itself.
/// </summary>
[RegisterComponent, NetworkedComponent]
public sealed partial class HitscanAmmoComponent : Component, IShootable;
