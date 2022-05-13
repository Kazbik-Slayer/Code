using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App2.ViewModel.BaseViewElements
{
    public class BaseView
    {
        protected virtual void Compose()
        {
            throw new NotImplementedException();
        }
        public virtual View GetView()
        {
            return null;
        }
    }
}
