// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace EFCoreExtensions.ChangeTracking
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
    using Microsoft.EntityFrameworkCore.Diagnostics;

    /// <summary>
    /// An extended change detector with support for hooks.
    /// </summary>
    public class ExtendedChangeDetector : ChangeDetector
    {
        private readonly ActionExecutor<IChangeDetectorHook> _executor;

        /// <summary>
        /// Initialises a new instance of <see cref="ExtendedChangeDetector"/>
        /// </summary>
        /// <param name="hooks">The set of change detector hooks.</param>
        /// <param name="logger">The logger</param>
        /// <param name="loggingOptions">The logging options</param>
        public ExtendedChangeDetector(
            IEnumerable<IChangeDetectorHook> hooks,
            IDiagnosticsLogger<DbLoggerCategory.ChangeTracking> logger,
            ILoggingOptions loggingOptions)
            : base(logger, loggingOptions)
        {
            _executor = new ActionExecutor<IChangeDetectorHook>(Ensure.NotNull(hooks, nameof(hooks)).ToArray());
        }

        /// <inheritdoc />
        public override void DetectChanges(InternalEntityEntry entry)
        {
            _executor.Execute(hook => hook.DetectingEntryChanges(this, entry.StateManager, entry));

            base.DetectChanges(entry);

            _executor.Execute(hook => hook.DetectedEntryChanges(this, entry.StateManager, entry));
        }

        /// <inheritdoc />
        public override void DetectChanges(IStateManager stateManager)
        {
            _executor.Execute(hook => hook.DetectingChanges(this, stateManager));

            base.DetectChanges(stateManager);

            _executor.Execute(hook => hook.DetectedChanges(this, stateManager));
        }

        /// <inheritdoc />
        public override void Resume()
        {
            _executor.Execute(hook => hook.Resuming(this));

            base.Resume();

            _executor.Execute(hook => hook.Resumed(this));
        }

        /// <inheritdoc />
        public override void Suspend()
        {
            _executor.Execute(hook => hook.Suspending(this));

            base.Suspend();

            _executor.Execute(hook => hook.Suspended(this));
        }
    }
}
