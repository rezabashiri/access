using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccessManagementService.Access
{
    [Serializable]
    public class Settings
    {
        public Password Password
        {
            get;
            set;
        }
        public string Serialize()
        {
            tkv.Utility.XmlHelper _helper = new tkv.Utility.XmlHelper();
            return   _helper.SerializeEntity<Settings>(this);
        }
        public Settings DeSerialize(string SettingsInXml)
        {
            tkv.Utility.XmlHelper _helper=new tkv.Utility.XmlHelper();
            return _helper.DeserializeEntity(SettingsInXml,this);
        }
    }
}