using System;
using System.Collections.Generic;
using System.Text;

namespace SV.Builder.Mobile.ViewModels.Shared
{
    public class BusyStatus : IDisposable
    {
        private bool disposedValue;
        private readonly IBusyStatus _busyStatus;

        public BusyStatus(IBusyStatus busyStatus)
        {
            _busyStatus = busyStatus;
            if (_busyStatus.IsBusy == false)
            {
                _busyStatus.IsBusy = true;
            }
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _busyStatus.IsBusy = false;
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
           // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
