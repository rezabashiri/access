using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modiriat_Gharardadha.AccessManagementService
{
   public interface IRightName
    {
       bool View
       {
           get;
           set;
       }
          bool Insert
          {
              get;
              set;
          }
          bool Edit
          {
              get;
              set;
          }
          bool Delete
          {
              get;
              set;
          }
          bool Print
          {
              get;
              set;
          }
          bool Attach
          {
              get;
              set;
          }
          bool WorkFlow
          {
              get;
              set;
          }

    }
}
