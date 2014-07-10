using System;
using System.Diagnostics;

namespace Raging.Toolbox.Patterns
{
    /// <summary>
    /// A disposable base class.
    /// </summary>
    ///
    /// <seealso cref="T:System.IDisposable"/>
    public abstract class DisposableBase : IDisposable
    {
        private bool _disposed;

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged
        /// resources.
        /// </summary>
        [DebuggerStepThrough]
        public void Dispose()
        {
            Dispose(false);
        }

        /// <summary>
        /// Finalizes an instance of the DisposableBase class.
        /// </summary>
        [DebuggerStepThrough]
        ~DisposableBase()
        {
            Dispose(true);
        }

        /// <summary>
        /// Dispose resources.
        /// </summary>
        protected virtual void DisposeResources() {}

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged
        /// resources.
        /// </summary>
        ///
        /// <param name="isFinalizing">true if this DisposableBase is finalizing.</param>
        [DebuggerStepThrough]
        private void Dispose(bool isFinalizing)
        {
            if (_disposed) return;

            DisposeResources();

            if(!isFinalizing) GC.SuppressFinalize(this);

            _disposed = true;
        }
    }
}