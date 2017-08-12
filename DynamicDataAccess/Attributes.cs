using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccessManagementService.DynamicDataAccess 
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class TablePermissionsAttribute : System.Attribute
    {
        // this property is required to work with "AllowMultiple = true" ref David Ebbo
        // As implemented, this identifier is merely the Type of the attribute. However,
        // it is intended that the unique identifier be used to identify two
        // attributes of the same type.
        public override object TypeId { get { return this; } }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="permission"></param>
        /// <param name="roles"></param>
        public TablePermissionsAttribute(Permissions permission, params String[] roles)
        {
            this._permission = permission;
            this._roles = roles;
        }

        private String[] _roles;
        public String[] Roles
        {
            get { return this._roles; }
            set { this._roles = value; }
        }

        private Permissions _permission;
        public Permissions Permission
        {
            get { return this._permission; }
            set { this._permission = value; }
        }

        /// <summary>
        /// helper method to check for roles in this attribute
        /// the comparison is case insensitive
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        //public Boolean HasRole(String role)
        //{
        //    // call extension method to convert array to lower case for compare
        //    String[] rolesLower = _roles.AllToLower();
        //    return rolesLower.Contains(role.ToLower());
        //}

        /// <summary>
        /// helper method to check for roles in this attribute
        /// the comparison is case insensitive
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        //public Boolean HasAnyRole(String[] roles)
        //{
        //    // call extension method to convert array to lower case for compare
        //    foreach (var role in roles.AllToLower())
        //    {
        //        if (_roles.AllToLower().Contains(role.ToLower()))
        //            return true;
        //    }
        //    return false;
        //}

        /// <summary>
        /// list of Deny permissions as the default is read write on everything
        /// this model apply the most severe permission restriction
        /// </summary>

        public enum Permissions
        {
            DenyRead,
            DenyEdit,
            DenyInserts,
            DenyDelete,
            DenyDetails,
            DenySelectItem, // Don't know wether this will be any use???
        }
    }
}