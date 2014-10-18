using System;
using System.Diagnostics;

namespace Raging.Toolbox.Patterns
{
    /// <summary>
    ///     A disposable base class.
    /// </summary>
    /// <seealso cref="T:System.IDisposable"/>
    public abstract class DisposableBase : IDisposable
    {
        private bool disposed;

        /// <summary>
        ///     Finalizes an instance of the DisposableBase class.
        /// </summary>
        [DebuggerStepThrough]
        ~DisposableBase()
        {
            this.Dispose(true);
        }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged
        ///     resources.
        /// </summary>
        [DebuggerStepThrough]
        public void Dispose()
        {
            this.Dispose(false);
        }

        /// <summary>
        ///     Dispose resources.
        /// </summary>
        protected virtual void DisposeResources() { }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged
        ///     resources.
        /// </summary>
        /// <param name="isFinalizing">true if this DisposableBase is finalizing.</param>
        [DebuggerStepThrough]
        private void Dispose(bool isFinalizing)
        {
            if (this.disposed) return;

            this.DisposeResources();

            if(!isFinalizing) GC.SuppressFinalize(this);

            this.disposed = true;
        }
    }
}