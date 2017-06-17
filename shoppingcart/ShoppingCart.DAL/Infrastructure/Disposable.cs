using System;

namespace ShoppingCart.DAL.Infrastructure
{
    public class Disposable : IDisposable
    {
        private bool _isDisposed;

        //~Disposable()
        //{
        //    Dispose(false);
        //}

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
       
        public virtual void Dispose(bool disposing)
        {
            if (!_isDisposed && disposing)
                DisposeObject();
            

            _isDisposed = true;
        }

        protected virtual void DisposeObject() { }
    }   
}
