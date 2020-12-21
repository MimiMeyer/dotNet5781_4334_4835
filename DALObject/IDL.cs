using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLAPI;
using DS;
//using DO;
namespace DL
{
    class DALObject: IDL

    {
        #region singelton
        static readonly DALObject intance = new DALObject();
        static DALObject() { }//static constructor to make sure it is initiaized.
        DALObject() { }//default private
        public static DALObject Instance { get => intance; }//the public constructor
        #endregion
        //Implement IDL methods,CRUD
    }
}
