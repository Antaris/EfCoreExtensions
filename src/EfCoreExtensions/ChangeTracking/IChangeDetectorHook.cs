﻿// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace EFCoreExtensions.ChangeTracking
{
    using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

    /// <summary>
    /// Defines the required contract for implementing a change detector hook.
    /// </summary>
    public interface IChangeDetectorHook
    {
        /// <summary>
        /// Fired when the change detector is determining changes to tracked entities.
        /// </summary>
        /// <param name="changeDetector">The change detector.</param>
        /// <param name="stateManager">The state manager.</param>
        void DetectingChanges(IChangeDetector changeDetector, IStateManager stateManager);

        /// <summary>
        /// Fired when the change detector has determined changes to tracked entities.
        /// </summary>
        /// <param name="changeDetector">The change detector.</param>
        /// <param name="stateManager">The state manager.</param>
        void DetectedChanges(IChangeDetector changeDetector, IStateManager stateManager);

        /// <summary>
        /// Fired when the change detector is determining changes to a tracked entity.
        /// </summary>
        /// <param name="changeDetector">The change detector.</param>
        /// <param name="stateManager">The state manager.</param>
        /// <param name="entry">The change tracking entry.</param>
        void DetectingEntryChanges(IChangeDetector changeDetector, IStateManager stateManager, InternalEntityEntry entry);

        /// <summary>
        /// Fired when the change detector has determined changes to a tracked entity.
        /// </summary>
        /// <param name="changeDetector">The change detector.</param>
        /// <param name="stateManager">The state manager.</param>
        /// <param name="entry">The change tracking entry.</param>
        void DetectedEntryChanges(IChangeDetector changeDetector, IStateManager stateManager, InternalEntityEntry entry);

        /// <summary>
        /// Fired when the change detector is resuming.
        /// </summary>
        /// <param name="changeDetector">The change detector.</param>
        void Resuming(IChangeDetector changeDetector);

        /// <summary>
        /// Fired when the change detector has finished resuming.
        /// </summary>
        /// <param name="changeDetector">The change detector.</param>
        void Resumed(IChangeDetector changeDetector);

        /// <summary>
        /// Fired when the change detector is suspending.
        /// </summary>
        /// <param name="changeDetector">The change detector.</param>
        void Suspending(IChangeDetector changeDetector);

        /// <summary>
        /// Fired when the change detector is suspended.
        /// </summary>
        /// <param name="changeDetector">The change detector.</param>
        void Suspended(IChangeDetector changeDetector);
    }
}
