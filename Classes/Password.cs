using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using tkv.Utility;
namespace AccessManagementService.Access
{
    [Serializable]
    public class Password
    {

        public bool LowerLtter
        {
            get;
            set;
        }
        public bool UpperLetter
        {
            get;
            set;
        }
        public bool Number
        {
            get;
            set;
        }
        public bool Signs
        {
            get;
            set;
        }
        public string MinimumChar
        {
            get;
            set;
        }
        public string Serialize()
        {
            tkv.Utility.XmlHelper _helper = new tkv.Utility.XmlHelper();
            return _helper.SerializeEntity<Password>(this);
        }
        public Password Deserialize(string PasswordinXml)
        {
            tkv.Utility.XmlHelper _helper = new tkv.Utility.XmlHelper();
            return _helper.DeserializeEntity<Password>(PasswordinXml, this);
        }
        public bool CheckPasswordPlocies(string password, int depid)
        {
            Model.Department _dep = new Model.Department();
            tkv.Utility.XmlHelper _xml = new tkv.Utility.XmlHelper();
    
            _dep = _dep.GetDepartments(null,depid).FirstOrDefault();
            if (_dep != null && _dep.Setting != null)
            {
                var settings = _dep.Setting;
                Settings _setting=_xml.DeserializeEntity<Settings>(_dep.Setting,new Settings());
                if (_setting != null)
                {
                    Password _pass = _setting.Password;
                    if (_pass == null)
                        return true;
                    bool retval=true;
                    //+ indicate one or more accurance 
                    if (_pass.LowerLtter)
                    {
                        retval =retval && Regex.IsMatch(password, "[a-z]+");
                    }
                    if (_pass.Number)
                    {
                        retval = retval && Regex.IsMatch(password, "[0-9]+");
                    }
                    if (_pass.UpperLetter)
                    {
                        retval = retval && Regex.IsMatch(password, "[A-Z]+");
                    }
                    if (_pass.Signs)
                    {
                        retval =retval && Regex.IsMatch(password, @"[^a-zA-Z0-9\s]+");//[] character group as single char OR CAN BE [^\w\s]
                    }
                    if (!string.IsNullOrEmpty(_pass.MinimumChar))
                    {
                        retval =retval && password.Length >= _pass.MinimumChar.ToInt32() ? true :false;
                    }
                    return retval;
                }
                else
                    return true;
            }
            return true;
        }
    }
}