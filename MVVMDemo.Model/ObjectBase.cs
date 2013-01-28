using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace MVVMDemo.Model
{
    public abstract class ObjectBase :INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected internal void OnPropertyChange(string propertyName)
        {
            if (this.PropertyChanged!=null)
            {
                this.PropertyChanged(this,new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
