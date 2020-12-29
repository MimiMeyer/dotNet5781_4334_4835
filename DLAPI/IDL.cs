using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;

namespace DLAPI
{
    public interface IDL//will use to make sure the code isn't empty
    {
        #region Line
        IEnumerable<DO.Line> getAllLines();
       
        IEnumerable<DO.Line> GetAllLinessBy(Predicate<DO.Line> predicate);
        DO.Line GetLine(int id);
        void AddLine(DO.Line line);
        void UpdateLine(DO.Line line);
        void DeleteLine(int id);

        #endregion 
        #region LineStation

       
        void AddLineStation();
        void UpdateLineStation();
        void DeleteLineStation();
        #endregion 
        #region LineTrip
        void AddLineTrip();
        void UpdateLineTrip();
        void DeleteLineTrip();
        #endregion 
        #region Station
        void AddStation();
        void UpdateStation();
        void DeleteStation();
        #endregion 
        #region Trip
        void AddTrip();
        void UpdateTrip();
        void DeleteTrip();
        #endregion 
        #region User
        void AddUser();
        void UpdateUser();
        void DeleteUser();
        #endregion 

    }
}
