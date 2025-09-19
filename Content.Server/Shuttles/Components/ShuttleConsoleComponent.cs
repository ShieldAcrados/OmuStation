// SPDX-FileCopyrightText: 2022 metalgearsloth <metalgearsloth@gmail.com>
// SPDX-FileCopyrightText: 2022 mirrorcult <lunarautomaton6@gmail.com>
// SPDX-FileCopyrightText: 2022 wrexbe <81056464+wrexbe@users.noreply.github.com>
// SPDX-FileCopyrightText: 2023 DrSmugleaf <DrSmugleaf@users.noreply.github.com>
// SPDX-FileCopyrightText: 2023 TemporalOroboros <TemporalOroboros@gmail.com>
// SPDX-FileCopyrightText: 2023 metalgearsloth <31366439+metalgearsloth@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 0x6273 <0x40@keemail.me>
// SPDX-FileCopyrightText: 2024 SlamBamActionman <83650252+SlamBamActionman@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 metalgearsloth <comedian_vs_clown@hotmail.com>
// SPDX-FileCopyrightText: 2025 Aiden <28298836+Aidenkrz@users.noreply.github.com>
//
// SPDX-License-Identifier: MIT

using System.Numerics;
using Content.Shared._NF.Shuttles.Events;
using Content.Shared.DeviceLinking;
using Content.Shared.Shuttles.Components;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom;

namespace Content.Server.Shuttles.Components
{
    [RegisterComponent]
    public sealed partial class ShuttleConsoleComponent : SharedShuttleConsoleComponent
    {
        [ViewVariables]
        public readonly List<EntityUid> SubscribedPilots = new();

        /// <summary>
        /// How much should the pilot's eye be zoomed by when piloting using this console?
        /// </summary>
        [DataField("zoom")]
        public Vector2 Zoom = new(1.5f, 1.5f);

        /// <summary>
        /// Should this console have access to restricted FTL destinations?
        /// </summary>
        [ViewVariables(VVAccess.ReadWrite), DataField("whitelistSpecific")]
        public List<EntityUid> FTLWhitelist = new List<EntityUid>();

        // Frontier: EMP-related state
        /// <summary>
        /// For EMP to allow keeping the shuttle off
        /// </summary>
        [DataField("enabled")]
        public bool MainBreakerEnabled = true;

        /// <summary>
        ///     While disabled by EMP
        /// </summary>
        [DataField("timeoutFromEmp", customTypeSerializer: typeof(TimeOffsetSerializer))]
        public TimeSpan TimeoutFromEmp = TimeSpan.Zero;

        [DataField("disableDuration"), ViewVariables(VVAccess.ReadWrite)]
        public float DisableDuration = 60f;

        [DataField, ViewVariables(VVAccess.ReadWrite)]
        public InertiaDampeningMode DampeningMode = InertiaDampeningMode.Dampen;
        // End Frontier

        // Network Port Button Source Ports
        [DataField]
        public List<ProtoId<SourcePortPrototype>> SourcePorts = new()
        {
            "device-button-1",
            "device-button-2",
            "device-button-3",
            "device-button-4",
            "device-button-5",
            "device-button-6",
            "device-button-7",
            "device-button-8"
        };
    }
}