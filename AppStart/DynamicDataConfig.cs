using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.DynamicData;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.Core.Objects;
using System.Web.DynamicData.ModelProviders;
namespace AccessManagementService.AppStart
{
    public class DynamicDataConfig 
    {
        static MetaModel _DefualtModel = new MetaModel();
      public static MetaModel AccessManagementModel
      {
          get
          {
              return _DefualtModel ?? new MetaModel();
          }
      }

        public static string GetContextName
        {
            get
            {
                return "AccessManagementService.Model.MPOEntities";
            }
        }
        public static ObjectContext GetObjectContext
        {
            get
            {

                Model.AccessEntities mpo = new Model.AccessEntities();
                return ((System.Data.Entity.Infrastructure.IObjectContextAdapter)mpo).ObjectContext;
            }
        }
        public static MetaTable GetMetaTable(string tablename)
        {
            return _DefualtModel.GetTable(tablename);
        }
        public static MetaTable GetMetaTable(Type entitytype)
        {
            return _DefualtModel.GetTable(entitytype);
        }
    }
}